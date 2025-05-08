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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCurrent = new TextBox();
            txtNew = new TextBox();
            txtConfirm = new TextBox();
            btnChange = new Button();
            button1 = new Button();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 86);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 32;
            label1.Text = "Akutalne hasło:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 142);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 33;
            label2.Text = "Nowe hasło:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 205);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 34;
            label3.Text = "Powtórz nowe hasło:";
            // 
            // txtCurrent
            // 
            txtCurrent.Location = new Point(136, 110);
            txtCurrent.Margin = new Padding(3, 4, 3, 4);
            txtCurrent.Name = "txtCurrent";
            txtCurrent.Size = new Size(226, 27);
            txtCurrent.TabIndex = 35;
            txtCurrent.UseSystemPasswordChar = true;
            // 
            // txtNew
            // 
            txtNew.Location = new Point(136, 166);
            txtNew.Margin = new Padding(3, 4, 3, 4);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(226, 27);
            txtNew.TabIndex = 36;
            txtNew.UseSystemPasswordChar = true;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(136, 229);
            txtConfirm.Margin = new Padding(3, 4, 3, 4);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(226, 27);
            txtConfirm.TabIndex = 37;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(180, 277);
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
            button1.Location = new Point(362, 389);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(137, 31);
            button1.TabIndex = 59;
            button1.Text = "Wyjdź";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 433);
            Controls.Add(button1);
            Controls.Add(btnChange);
            Controls.Add(txtConfirm);
            Controls.Add(txtNew);
            Controls.Add(txtCurrent);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblLogin);
            Controls.Add(label30);
            Name = "ChangePasswordForm";
            Text = "Zmień hasło";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label30;
        private Label lblLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCurrent;
        private TextBox txtNew;
        private TextBox txtConfirm;
        private Button btnChange;
        private Button button1;
    }
}