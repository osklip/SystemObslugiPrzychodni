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
            label1.Location = new Point(26, 21);
            label1.Name = "label1";
            label1.Size = new Size(359, 20);
            label1.TabIndex = 3;
            label1.Text = "Podaj dane konta, w którym chcesz zresetować hasło:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(86, 78);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(233, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(86, 141);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Login";
            txtLogin.Size = new Size(233, 27);
            txtLogin.TabIndex = 5;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(128, 189);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(136, 29);
            btnRecover.TabIndex = 6;
            btnRecover.Text = "Odzyskaj hasło";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 55);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 33;
            label2.Text = "E-mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 118);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 34;
            label3.Text = "Login:";
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 245);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnRecover);
            Controls.Add(txtLogin);
            Controls.Add(txtEmail);
            Controls.Add(label1);
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