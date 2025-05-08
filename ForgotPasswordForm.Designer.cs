namespace SystemObslugiPrzychodni
{
    partial class ForgotPasswordForm
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
            label1 = new Label();
            txtEmail = new TextBox();
            txtLogin = new TextBox();
            btnRecover = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 16);
            label1.Name = "label1";
            label1.Size = new Size(288, 15);
            label1.TabIndex = 3;
            label1.Text = "Podaj dane konta, w którym chcesz zresetować hasło:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(75, 115);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(204, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(75, 63);
            txtLogin.Margin = new Padding(3, 2, 3, 2);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Login";
            txtLogin.Size = new Size(204, 23);
            txtLogin.TabIndex = 5;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(110, 151);
            btnRecover.Margin = new Padding(3, 2, 3, 2);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(119, 22);
            btnRecover.TabIndex = 6;
            btnRecover.Text = "Odzyskaj hasło";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 98);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 33;
            label2.Text = "E-mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 46);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 34;
            label3.Text = "Login:";
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 192);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnRecover);
            Controls.Add(txtLogin);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ForgotPasswordForm";
            Text = "Odzyskaj hasło";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEmail;
        private TextBox txtLogin;
        private Button btnRecover;
        private Label label2;
        private Label label3;
    }
}