namespace InventorySystemWinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tbxBeadName = new TextBox();
            tbxCharmName = new TextBox();
            tbxBeadQty = new TextBox();
            tbxCharmQty = new TextBox();
            btnAddBeads = new Button();
            btnRemoveBeads = new Button();
            btnAddCharms = new Button();
            btnRemoveCharms = new Button();
            label1 = new Label();
            label2 = new Label();
            listBoxBeads = new ListBox();
            listBoxCharms = new ListBox();
            SuspendLayout();
            // 
            // tbxBeadName
            // 
            tbxBeadName.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxBeadName.Location = new Point(262, 180);
            tbxBeadName.Name = "tbxBeadName";
            tbxBeadName.Size = new Size(288, 39);
            tbxBeadName.TabIndex = 0;
            tbxBeadName.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxCharmName
            // 
            tbxCharmName.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxCharmName.Location = new Point(262, 257);
            tbxCharmName.Name = "tbxCharmName";
            tbxCharmName.Size = new Size(272, 39);
            tbxCharmName.TabIndex = 1;
            tbxCharmName.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxBeadQty
            // 
            tbxBeadQty.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxBeadQty.Location = new Point(829, 180);
            tbxBeadQty.Name = "tbxBeadQty";
            tbxBeadQty.Size = new Size(90, 39);
            tbxBeadQty.TabIndex = 2;
            tbxBeadQty.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxCharmQty
            // 
            tbxCharmQty.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxCharmQty.Location = new Point(829, 257);
            tbxCharmQty.Name = "tbxCharmQty";
            tbxCharmQty.Size = new Size(90, 39);
            tbxCharmQty.TabIndex = 3;
            tbxCharmQty.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddBeads
            // 
            btnAddBeads.BackColor = Color.Transparent;
            btnAddBeads.BackgroundImage = Properties.Resources.ADD;
            btnAddBeads.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddBeads.Location = new Point(173, 328);
            btnAddBeads.Name = "btnAddBeads";
            btnAddBeads.Size = new Size(118, 45);
            btnAddBeads.TabIndex = 4;
            btnAddBeads.UseVisualStyleBackColor = false;
            // 
            // btnRemoveBeads
            // 
            btnRemoveBeads.BackgroundImage = Properties.Resources.del;
            btnRemoveBeads.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemoveBeads.Location = new Point(324, 328);
            btnRemoveBeads.Name = "btnRemoveBeads";
            btnRemoveBeads.Size = new Size(118, 45);
            btnRemoveBeads.TabIndex = 5;
            btnRemoveBeads.UseVisualStyleBackColor = true;
            // 
            // btnAddCharms
            // 
            btnAddCharms.BackgroundImage = Properties.Resources.ADD1;
            btnAddCharms.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddCharms.Location = new Point(647, 324);
            btnAddCharms.Name = "btnAddCharms";
            btnAddCharms.Size = new Size(118, 45);
            btnAddCharms.TabIndex = 6;
            btnAddCharms.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCharms
            // 
            btnRemoveCharms.BackgroundImage = Properties.Resources.del;
            btnRemoveCharms.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemoveCharms.Location = new Point(801, 324);
            btnRemoveCharms.Name = "btnRemoveCharms";
            btnRemoveCharms.Size = new Size(118, 45);
            btnRemoveCharms.TabIndex = 7;
            btnRemoveCharms.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Palatino Linotype", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 331);
            label1.Name = "label1";
            label1.Size = new Size(93, 38);
            label1.TabIndex = 8;
            label1.Text = "Beads";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Palatino Linotype", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(511, 331);
            label2.Name = "label2";
            label2.Size = new Size(116, 38);
            label2.TabIndex = 9;
            label2.Text = "Charms";
            // 
            // listBoxBeads
            // 
            listBoxBeads.FormattingEnabled = true;
            listBoxBeads.Location = new Point(22, 390);
            listBoxBeads.Name = "listBoxBeads";
            listBoxBeads.Size = new Size(391, 344);
            listBoxBeads.TabIndex = 10;
            // 
            // listBoxCharms
            // 
            listBoxCharms.FormattingEnabled = true;
            listBoxCharms.Location = new Point(556, 390);
            listBoxCharms.Name = "listBoxCharms";
            listBoxCharms.Size = new Size(391, 344);
            listBoxCharms.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.mainform;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(987, 756);
            Controls.Add(listBoxCharms);
            Controls.Add(listBoxBeads);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRemoveCharms);
            Controls.Add(btnAddCharms);
            Controls.Add(btnRemoveBeads);
            Controls.Add(btnAddBeads);
            Controls.Add(tbxCharmQty);
            Controls.Add(tbxBeadQty);
            Controls.Add(tbxCharmName);
            Controls.Add(tbxBeadName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxBeadName;
        private TextBox tbxCharmName;
        private TextBox tbxBeadQty;
        private TextBox tbxCharmQty;
        private Button btnAddBeads;
        private Button btnRemoveBeads;
        private Button btnAddCharms;
        private Button btnRemoveCharms;
        private Label label1;
        private Label label2;
        private ListBox listBoxBeads;
        private ListBox listBoxCharms;
    }
}