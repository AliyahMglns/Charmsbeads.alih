using System;
using System.Linq;
using System.Windows.Forms;
using Inventory_BusinessDataLogic;
using InventoryDataService;
using static InventorySupplies;
using InventoryBusinessDataLogic;

namespace InventorySystemWinForms
{
    public partial class MainForm : Form
    {
        private readonly string _accountNumber;
        private InventoryService inventoryService = new();
        private AccountService accountService = new();

        public MainForm(string accountNumber)
        {
            InitializeComponent();
            _accountNumber = accountNumber;
            LoadData();
        }

        private void LoadData()
        {
            ItemStock.BeadStocks.Clear();
            ItemStock.CharmStocks.Clear();

            var beads = BeadsStorage.Beads();
            var charms = BeadsStorage.Charms();

            foreach (var item in beads)
            {
                var parts = item.Split(':');
                ItemStock.BeadStocks.Add(new InventorySupplies(parts[0].Trim(), int.Parse(parts[1].Trim())));
            }

            foreach (var item in charms)
            {
                var parts = item.Split(':');
                ItemStock.CharmStocks.Add(new InventorySupplies(parts[0].Trim(), int.Parse(parts[1].Trim())));
            }

            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            listBoxBeads.Items.Clear();
            listBoxCharms.Items.Clear();

            foreach (var bead in ItemStock.BeadStocks)
                listBoxBeads.Items.Add($"{bead.Name}: {bead.Quantity}");

            foreach (var charm in ItemStock.CharmStocks)
                listBoxCharms.Items.Add($"{charm.Name}: {charm.Quantity}");
        }

        private void btnAddBeads_Click(object sender, EventArgs e)
        {
            string name = tbxBeadName.Text.Trim();
            int qty = int.Parse(tbxBeadQty.Text);

            inventoryService.AddItem("bead", name, qty);
            BeadsStorage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
            accountService.UpdateBeads(_accountNumber, ItemStock.BeadStocks.Sum(b => b.Quantity));

            LoadData(); 
            MessageBox.Show("Beads added successfully!");
        }

        private void btnAddCharms_Click(object sender, EventArgs e)
        {
            string name = tbxCharmName.Text.Trim();
            int qty = int.Parse(tbxCharmQty.Text);

            inventoryService.AddItem("charm", name, qty);
            BeadsStorage.SaveCharms(ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
            accountService.UpdateCharms(_accountNumber, ItemStock.CharmStocks.Sum(c => c.Quantity));

            LoadData();
            MessageBox.Show("Charms added successfully!");
        }
        private string ExtractItemName(string listItem)
        {
            return listItem.Split(':')[0].Trim();
        }

        private void btnRemoveBeads_Click(object sender, EventArgs e)
        {
            if (listBoxBeads.SelectedItem == null)
            {
                MessageBox.Show("Please select a bead to remove from.");
                return;
            }

            if (!int.TryParse(tbxBeadQty.Text, out int qtyToRemove) || qtyToRemove <= 0)
            {
                MessageBox.Show("Please enter a valid quantity to remove.");
                return;
            }

            string selected = listBoxBeads.SelectedItem.ToString();
            string nameToRemove = selected.Split(':')[0].Trim();

            var item = ItemStock.BeadStocks.FirstOrDefault(b => b.Name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                if (qtyToRemove >= item.Quantity)
                {
                    ItemStock.BeadStocks.Remove(item);
                    MessageBox.Show($"'{item.Name}' completely removed.");
                }
                else
                {
                    item.Quantity -= qtyToRemove;
                    MessageBox.Show($"Removed {qtyToRemove} from '{item.Name}'. Remaining: {item.Quantity}");
                }

                BeadsStorage.SaveBeads(ItemStock.BeadStocks
                    .Select(b => $"{b.Name}: {b.Quantity}")
                    .ToList());

                accountService.UpdateBeads(_accountNumber, ItemStock.BeadStocks.Sum(b => b.Quantity));
                LoadData();
            }
        }

        private void btnRemoveCharms_Click(object sender, EventArgs e)
        {
            if (listBoxCharms.SelectedItem == null)
            {
                MessageBox.Show("Please select a charm to remove from.");
                return;
            }

            if (!int.TryParse(tbxCharmQty.Text, out int qtyToRemove) || qtyToRemove <= 0)
            {
                MessageBox.Show("Please enter a valid quantity to remove.");
                return;
            }

            string selected = listBoxCharms.SelectedItem.ToString();
            string nameToRemove = selected.Split(':')[0].Trim();

            var item = ItemStock.CharmStocks.FirstOrDefault(c => c.Name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                if (qtyToRemove >= item.Quantity)
                {
                    ItemStock.CharmStocks.Remove(item);
                    MessageBox.Show($"'{item.Name}' completely removed from your charms!");
                }
                else
                {
                    item.Quantity -= qtyToRemove;
                    MessageBox.Show($"Removed {qtyToRemove} from '{item.Name}'. Remaining: {item.Quantity}");
                }

                BeadsStorage.SaveCharms(ItemStock.CharmStocks
                    .Select(c => $"{c.Name}: {c.Quantity}")
                    .ToList());

                accountService.UpdateCharms(_accountNumber, ItemStock.CharmStocks.Sum(c => c.Quantity));
                LoadData();
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm loginFrm = new LoginForm();
            loginFrm.Show();
            this.Hide();
        }

        private void listBoxBeads_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
