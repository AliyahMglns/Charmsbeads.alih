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
        private BeadsStorage storage = new();

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

            var beads = storage.LoadBeads();
            var charms = storage.LoadCharms();

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
            string name = tbxBeadName.Text;
            int qty = int.Parse(tbxBeadQty.Text);
            inventoryService.AddItem("bead", name, qty);

            storage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
            accountService.UpdateBeads(_accountNumber, ItemStock.BeadStocks.Sum(b => b.Quantity));
            RefreshDisplay();
        }

        private void btnAddCharms_Click(object sender, EventArgs e)
        {
            string name = tbxCharmName.Text;
            int qty = int.Parse(tbxCharmQty.Text);
            inventoryService.AddItem("charm", name, qty);

            storage.SaveCharms(ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
            accountService.UpdateCharms(_accountNumber, ItemStock.CharmStocks.Sum(c => c.Quantity));
            RefreshDisplay();
        }

        private void btnRemoveBeads_Click(object sender, EventArgs e)
        {
            string name = tbxBeadName.Text;
            int qty = int.Parse(tbxBeadQty.Text);
            if (inventoryService.RemoveItem("bead", name, qty))
            {
                storage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
                accountService.UpdateBeads(_accountNumber, ItemStock.BeadStocks.Sum(b => b.Quantity));
                RefreshDisplay();
            }
            else
            {
                MessageBox.Show("Error removing beads.");
            }
        }

        private void btnRemoveCharms_Click(object sender, EventArgs e)
        {
            string name = tbxCharmName.Text;
            int qty = int.Parse(tbxCharmQty.Text);
            if (inventoryService.RemoveItem("charm", name, qty))
            {
                storage.SaveCharms(ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
                accountService.UpdateCharms(_accountNumber, ItemStock.CharmStocks.Sum(c => c.Quantity));
                RefreshDisplay();
            }
            else
            {
                MessageBox.Show("Error removing charms.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Optional
        }
    }
}
