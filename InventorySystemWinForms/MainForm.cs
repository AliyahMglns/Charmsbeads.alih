using System;
using System.Linq;
using System.Windows.Forms;
using Inventory_BusinessDataLogic;
using InventoryDataService;
using static InventorySupplies;
using InventoryBusinessDataLogic;
using Microsoft.Extensions.DependencyInjection;
using Test;

namespace InventorySystemWinForms
{
    public partial class MainForm : Form
    {
        private readonly EmailService _emailService;
        private readonly string _accountNumber;
        private readonly string accountNumber;
        private InventoryService inventoryService = new();
        private AccountService accountService = new();

        public MainForm(string accountNumber)
        {
            InitializeComponent();
            _emailService = Program.ServiceProvider.GetRequiredService<EmailService>();
            _accountNumber = accountNumber;
            LoadData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            if (string.IsNullOrWhiteSpace(tbxBeadName.Text) || !int.TryParse(tbxBeadQty.Text, out int qty))
            {
                MessageBox.Show("Please enter valid bead name and quantity.");
                return;
            }

            inventoryService.AddItem("bead", tbxBeadName.Text.Trim(), qty);
            BeadsStorage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
            accountService.UpdateBeads(_accountNumber, ItemStock.BeadStocks.Sum(b => b.Quantity));

            _emailService.SendEmail(accountNumber);
            LoadData();
            MessageBox.Show("Beads added successfully!");
        }

        private void btnAddCharms_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxCharmName.Text) || !int.TryParse(tbxCharmQty.Text, out int qty))
            {
                MessageBox.Show("Please enter valid charm name and quantity.");
                return;
            }

            inventoryService.AddItem("charm", tbxCharmName.Text.Trim(), qty);
            BeadsStorage.SaveCharms(ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
            accountService.UpdateCharms(_accountNumber, ItemStock.CharmStocks.Sum(c => c.Quantity));

            _emailService.SendEmail(accountNumber);
            LoadData();
            MessageBox.Show("Charms added successfully!");
        }

        private void btnRemoveBeads_Click(object sender, EventArgs e)
        {
            if (listBoxBeads.SelectedItem == null)
            {
                MessageBox.Show("Please select a bead to remove.");
                return;
            }

            if (!int.TryParse(tbxBeadQty.Text, out int qtyToRemove) || qtyToRemove <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            string name = listBoxBeads.SelectedItem.ToString().Split(':')[0].Trim();
            var bead = ItemStock.BeadStocks.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (bead != null)
            {
                if (qtyToRemove >= bead.Quantity)
                    ItemStock.BeadStocks.Remove(bead);
                else
                    bead.Quantity -= qtyToRemove;

                BeadsStorage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
                accountService.UpdateBeads(_accountNumber, ItemStock.BeadStocks.Sum(b => b.Quantity));
                LoadData();
            }
        }

        private void btnRemoveCharms_Click(object sender, EventArgs e)
        {
            if (listBoxCharms.SelectedItem == null)
            {
                MessageBox.Show("Please select a charm to remove.");
                return;
            }

            if (!int.TryParse(tbxCharmQty.Text, out int qtyToRemove) || qtyToRemove <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            string name = listBoxCharms.SelectedItem.ToString().Split(':')[0].Trim();
            var charm = ItemStock.CharmStocks.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (charm != null)
            {
                if (qtyToRemove >= charm.Quantity)
                    ItemStock.CharmStocks.Remove(charm);
                else
                    charm.Quantity -= qtyToRemove;

                BeadsStorage.SaveCharms(ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
                accountService.UpdateCharms(_accountNumber, ItemStock.CharmStocks.Sum(c => c.Quantity));
                LoadData();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
