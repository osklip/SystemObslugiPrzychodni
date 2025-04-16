namespace SystemObslugiPrzychodni
{
    partial class AdminMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OpenAddUserFormButton = new Button();
            OpenUserListFormButton = new Button();
            btnViewForgottenUsers = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // OpenAddUserFormButton
            // 
            OpenAddUserFormButton.Location = new Point(248, 202);
            OpenAddUserFormButton.Name = "OpenAddUserFormButton";
            OpenAddUserFormButton.Size = new Size(192, 41);
            OpenAddUserFormButton.TabIndex = 1;
            OpenAddUserFormButton.Text = "Dodaj użytkownika";
            OpenAddUserFormButton.UseVisualStyleBackColor = true;
            OpenAddUserFormButton.Click += OpenAddUserFormButton_Click;
            // 
            // OpenUserListFormButton
            // 
            OpenUserListFormButton.Location = new Point(248, 271);
            OpenUserListFormButton.Name = "OpenUserListFormButton";
            OpenUserListFormButton.Size = new Size(192, 36);
            OpenUserListFormButton.TabIndex = 2;
            OpenUserListFormButton.Text = "Lista użytkowników";
            OpenUserListFormButton.UseVisualStyleBackColor = true;
            OpenUserListFormButton.Click += OpenUserListFormButton_Click;
            // 
            // btnViewForgottenUsers
            // 
            btnViewForgottenUsers.Location = new Point(248, 338);
            btnViewForgottenUsers.Margin = new Padding(3, 2, 3, 2);
            btnViewForgottenUsers.Name = "btnViewForgottenUsers";
            btnViewForgottenUsers.Size = new Size(192, 51);
            btnViewForgottenUsers.TabIndex = 3;
            btnViewForgottenUsers.Text = "Lista zapomnianych użytkowników";
            btnViewForgottenUsers.UseVisualStyleBackColor = true;
            btnViewForgottenUsers.Click += btnViewForgottenUsers_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(47, 30);
            label1.Name = "label1";
            label1.Size = new Size(591, 54);
            label1.TabIndex = 4;
            label1.Text = "System zarządzania przychodnią";
            // 
            // AdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 450);
            Controls.Add(label1);
            Controls.Add(btnViewForgottenUsers);
            Controls.Add(OpenUserListFormButton);
            Controls.Add(OpenAddUserFormButton);
            Name = "AdminMenuForm";
            Text = "Menu Administracyjne";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button OpenAddUserFormButton;
        private Button OpenUserListFormButton;
        private Button btnViewForgottenUsers;
        private Label label1;
    }
}
