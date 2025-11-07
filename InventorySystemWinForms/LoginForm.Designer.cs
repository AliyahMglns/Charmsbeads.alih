namespace InventorySystemWinForms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            tbxAccountNum = new TextBox();
            tbxPin = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // tbxAccountNum
            // 
            tbxAccountNum.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxAccountNum.Location = new Point(257, 152);
            tbxAccountNum.Name = "tbxAccountNum";
            tbxAccountNum.Size = new Size(274, 30);
            tbxAccountNum.TabIndex = 0;
            tbxAccountNum.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxPin
            // 
            tbxPin.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxPin.Location = new Point(257, 210);
            tbxPin.Name = "tbxPin";
            tbxPin.Size = new Size(274, 30);
            tbxPin.TabIndex = 1;
            tbxPin.TextAlign = HorizontalAlignment.Center;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(331, 279);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(104, 37);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Log_In_Form;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(664, 387);
            Controls.Add(btnLogin);
            Controls.Add(tbxPin);
            Controls.Add(tbxAccountNum);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxAccountNum;
        private TextBox tbxPin;
        private Button btnLogin;
    }
}