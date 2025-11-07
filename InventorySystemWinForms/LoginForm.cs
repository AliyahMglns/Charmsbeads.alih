using System;
using System.Windows.Forms;
using InventoryBusinessDataLogic;
using InventorySystemWinForms;

namespace InventorySystemWinForms
{
    public partial class LoginForm : Form
    {
        private AccountService accountService = new AccountService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string accountNumber = tbxAccountNum.Text;
            string pin = tbxPin.Text;

            if (accountService.ValidateAccount(accountNumber, pin))
            {
                MessageBox.Show("Login successful!");
                this.Hide();

                MainForm mainForm = new MainForm(accountNumber);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Try again.");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
