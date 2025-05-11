namespace SystemObslugiPrzychodni
{
    partial class ForceChangePasswordForm
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
            btnSet = new Button();
            txtConfirm = new TextBox();
            txtNew = new TextBox();
            label3 = new Label();
            label2 = new Label();
            validationPanel = new Panel();
            lblRuleSpecial = new Label();
            lblRuleDigit = new Label();
            lblRuleLower = new Label();
            lblRuleUpper = new Label();
            lblRuleLength = new Label();
            validationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnSet
            // 
            btnSet.Location = new Point(125, 170);
            btnSet.Margin = new Padding(3, 4, 3, 4);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(137, 31);
            btnSet.TabIndex = 63;
            btnSet.Text = "Zmień hasło";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(81, 122);
            txtConfirm.Margin = new Padding(3, 4, 3, 4);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(226, 27);
            txtConfirm.TabIndex = 62;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // txtNew
            // 
            txtNew.Location = new Point(81, 59);
            txtNew.Margin = new Padding(3, 4, 3, 4);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(226, 27);
            txtNew.TabIndex = 61;
            txtNew.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 98);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 60;
            label3.Text = "Powtórz nowe hasło:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 35);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 59;
            label2.Text = "Nowe hasło:";
            // 
            // validationPanel
            // 
            validationPanel.Controls.Add(lblRuleSpecial);
            validationPanel.Controls.Add(lblRuleDigit);
            validationPanel.Controls.Add(lblRuleLower);
            validationPanel.Controls.Add(lblRuleUpper);
            validationPanel.Controls.Add(lblRuleLength);
            validationPanel.Location = new Point(331, 26);
            validationPanel.Name = "validationPanel";
            validationPanel.Size = new Size(274, 186);
            validationPanel.TabIndex = 64;
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
            // ForceChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 247);
            Controls.Add(validationPanel);
            Controls.Add(btnSet);
            Controls.Add(txtConfirm);
            Controls.Add(txtNew);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "ForceChangePasswordForm";
            Text = "Zmień hasło tymczasowe";
            validationPanel.ResumeLayout(false);
            validationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSet;
        private TextBox txtConfirm;
        private TextBox txtNew;
        private Label label3;
        private Label label2;
        private Panel validationPanel;
        private Label lblRuleSpecial;
        private Label lblRuleDigit;
        private Label lblRuleLower;
        private Label lblRuleUpper;
        private Label lblRuleLength;
    }
}