namespace SystemObslugiPrzychodni
{
    partial class ChangePasswordForm
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
            label30 = new Label();
            lblLogin = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNew = new TextBox();
            txtConfirm = new TextBox();
            btnChange = new Button();
            button1 = new Button();
            validationPanel = new Panel();
            lblRuleSpecial = new Label();
            lblRuleDigit = new Label();
            lblRuleLower = new Label();
            lblRuleUpper = new Label();
            lblRuleLength = new Label();
            validationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(12, 23);
            label30.Name = "label30";
            label30.Size = new Size(49, 20);
            label30.TabIndex = 30;
            label30.Text = "Login:";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(84, 23);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(44, 20);
            lblLogin.TabIndex = 31;
            lblLogin.Text = "NULL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 87);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 33;
            label2.Text = "Nowe hasło:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 150);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 34;
            label3.Text = "Powtórz nowe hasło:";
            // 
            // txtNew
            // 
            txtNew.Location = new Point(12, 111);
            txtNew.Margin = new Padding(3, 4, 3, 4);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(226, 27);
            txtNew.TabIndex = 36;
            txtNew.UseSystemPasswordChar = true;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(12, 174);
            txtConfirm.Margin = new Padding(3, 4, 3, 4);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(226, 27);
            txtConfirm.TabIndex = 37;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(56, 222);
            btnChange.Margin = new Padding(3, 4, 3, 4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(137, 31);
            btnChange.TabIndex = 58;
            btnChange.Text = "Zmień hasło";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(411, 298);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(137, 31);
            button1.TabIndex = 59;
            button1.Text = "Wyjdź";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // validationPanel
            // 
            validationPanel.Controls.Add(lblRuleSpecial);
            validationPanel.Controls.Add(lblRuleDigit);
            validationPanel.Controls.Add(lblRuleLower);
            validationPanel.Controls.Add(lblRuleUpper);
            validationPanel.Controls.Add(lblRuleLength);
            validationPanel.Location = new Point(258, 67);
            validationPanel.Name = "validationPanel";
            validationPanel.Size = new Size(274, 186);
            validationPanel.TabIndex = 60;
            // 
            // lblRuleSpecial
            // 
            lblRuleSpecial.AutoSize = true;
            lblRuleSpecial.ForeColor = Color.DarkRed;
            lblRuleSpecial.Location = new Point(13, 147);
            lblRuleSpecial.Name = "lblRuleSpecial";
            lblRuleSpecial.Size = new Size(255, 20);
            lblRuleSpecial.TabIndex = 4;
            lblRuleSpecial.Text = "• Przynajmniej jeden znak (- _ ! * # $ &)";
            // 
            // lblRuleDigit
            // 
            lblRuleDigit.AutoSize = true;
            lblRuleDigit.ForeColor = Color.DarkRed;
            lblRuleDigit.Location = new Point(13, 114);
            lblRuleDigit.Name = "lblRuleDigit";
            lblRuleDigit.Size = new Size(180, 20);
            lblRuleDigit.TabIndex = 3;
            lblRuleDigit.Text = "• Przynajmniej jedna cyfra";
            // 
            // lblRuleLower
            // 
            lblRuleLower.AutoSize = true;
            lblRuleLower.ForeColor = Color.DarkRed;
            lblRuleLower.Location = new Point(13, 77);
            lblRuleLower.Name = "lblRuleLower";
            lblRuleLower.Size = new Size(219, 20);
            lblRuleLower.TabIndex = 2;
            lblRuleLower.Text = "• Przynajmniej jedna mała litera";
            // 
            // lblRuleUpper
            // 
            lblRuleUpper.AutoSize = true;
            lblRuleUpper.ForeColor = Color.DarkRed;
            lblRuleUpper.Location = new Point(13, 44);
            lblRuleUpper.Name = "lblRuleUpper";
            lblRuleUpper.Size = new Size(228, 20);
            lblRuleUpper.TabIndex = 1;
            lblRuleUpper.Text = "• Przynajmniej jedna wielka litera";
            // 
            // lblRuleLength
            // 
            lblRuleLength.AutoSize = true;
            lblRuleLength.FlatStyle = FlatStyle.Flat;
            lblRuleLength.ForeColor = Color.DarkRed;
            lblRuleLength.Location = new Point(13, 14);
            lblRuleLength.Name = "lblRuleLength";
            lblRuleLength.Size = new Size(105, 20);
            lblRuleLength.TabIndex = 0;
            lblRuleLength.Text = "• 8–15 znaków";
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 342);
            Controls.Add(validationPanel);
            Controls.Add(button1);
            Controls.Add(btnChange);
            Controls.Add(txtConfirm);
            Controls.Add(txtNew);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblLogin);
            Controls.Add(label30);
            Name = "ChangePasswordForm";
            Text = "Zmień hasło";
            validationPanel.ResumeLayout(false);
            validationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label30;
        private Label lblLogin;
        private Label label2;
        private Label label3;
        private TextBox txtNew;
        private TextBox txtConfirm;
        private Button btnChange;
        private Button button1;
        private Panel validationPanel;
        private Label lblRuleLower;
        private Label lblRuleUpper;
        private Label lblRuleLength;
        private Label lblRuleSpecial;
        private Label lblRuleDigit;
    }
}