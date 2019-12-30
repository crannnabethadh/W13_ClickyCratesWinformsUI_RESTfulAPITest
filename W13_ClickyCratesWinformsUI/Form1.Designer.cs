namespace W13_ClickyCratesWinformsUI
{
    partial class Form1
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
            this.UserEmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.NickNameTextBox = new System.Windows.Forms.TextBox();
            this.CityComboBox = new System.Windows.Forms.ComboBox();
            this.EditPlayerDataButton = new System.Windows.Forms.Button();
            this.SavePlayerDataButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserEmailTextBox
            // 
            this.UserEmailTextBox.Enabled = false;
            this.UserEmailTextBox.Location = new System.Drawing.Point(56, 70);
            this.UserEmailTextBox.Name = "UserEmailTextBox";
            this.UserEmailTextBox.Size = new System.Drawing.Size(168, 26);
            this.UserEmailTextBox.TabIndex = 0;
            this.UserEmailTextBox.Text = "a@b.c";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(56, 140);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(168, 26);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(144, 195);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(80, 35);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UserEmailTextBox);
            this.groupBox1.Controls.Add(this.LoginButton);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 244);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SavePlayerDataButton);
            this.groupBox2.Controls.Add(this.EditPlayerDataButton);
            this.groupBox2.Controls.Add(this.CityComboBox);
            this.groupBox2.Controls.Add(this.NickNameTextBox);
            this.groupBox2.Controls.Add(this.LastNameTextBox);
            this.groupBox2.Controls.Add(this.FirstNameTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(403, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 289);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "First Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Last Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "City:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nick Name:";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Enabled = false;
            this.FirstNameTextBox.Location = new System.Drawing.Point(125, 39);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(251, 26);
            this.FirstNameTextBox.TabIndex = 4;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Enabled = false;
            this.LastNameTextBox.Location = new System.Drawing.Point(125, 82);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(251, 26);
            this.LastNameTextBox.TabIndex = 5;
            // 
            // NickNameTextBox
            // 
            this.NickNameTextBox.Enabled = false;
            this.NickNameTextBox.Location = new System.Drawing.Point(125, 126);
            this.NickNameTextBox.Name = "NickNameTextBox";
            this.NickNameTextBox.Size = new System.Drawing.Size(251, 26);
            this.NickNameTextBox.TabIndex = 6;
            // 
            // CityComboBox
            // 
            this.CityComboBox.Enabled = false;
            this.CityComboBox.FormattingEnabled = true;
            this.CityComboBox.Items.AddRange(new object[] {
            "Alaró",
            "Binissalem",
            "Inca",
            "Lloseta",
            "Palma",
            "Pollença",
            "Selva",
            "Sineu"});
            this.CityComboBox.Location = new System.Drawing.Point(125, 171);
            this.CityComboBox.Name = "CityComboBox";
            this.CityComboBox.Size = new System.Drawing.Size(251, 28);
            this.CityComboBox.TabIndex = 7;
            // 
            // EditPlayerDataButton
            // 
            this.EditPlayerDataButton.Location = new System.Drawing.Point(30, 231);
            this.EditPlayerDataButton.Name = "EditPlayerDataButton";
            this.EditPlayerDataButton.Size = new System.Drawing.Size(155, 41);
            this.EditPlayerDataButton.TabIndex = 8;
            this.EditPlayerDataButton.Text = "Edit";
            this.EditPlayerDataButton.UseVisualStyleBackColor = true;
            // 
            // SavePlayerDataButton
            // 
            this.SavePlayerDataButton.Location = new System.Drawing.Point(222, 231);
            this.SavePlayerDataButton.Name = "SavePlayerDataButton";
            this.SavePlayerDataButton.Size = new System.Drawing.Size(154, 41);
            this.SavePlayerDataButton.TabIndex = 9;
            this.SavePlayerDataButton.Text = "Save";
            this.SavePlayerDataButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 362);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Test Clicky Crates RESTful API";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox UserEmailTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SavePlayerDataButton;
        private System.Windows.Forms.Button EditPlayerDataButton;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.TextBox NickNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

