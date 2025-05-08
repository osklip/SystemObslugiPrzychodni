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
            logoutMenuItem = new Button();
            SuspendLayout();
            // 
            // OpenAddUserFormButton
            // 
            OpenAddUserFormButton.Location = new Point(306, 108);
            OpenAddUserFormButton.Margin = new Padding(3, 4, 3, 4);
            OpenAddUserFormButton.Name = "OpenAddUserFormButton";
            OpenAddUserFormButton.Size = new Size(219, 55);
            OpenAddUserFormButton.TabIndex = 1;
            OpenAddUserFormButton.Text = "Dodaj użytkownika";
            OpenAddUserFormButton.UseVisualStyleBackColor = true;
            OpenAddUserFormButton.Click += OpenAddUserFormButton_Click;
            // 
            // OpenUserListFormButton
            // 
            OpenUserListFormButton.Location = new Point(306, 190);
            OpenUserListFormButton.Margin = new Padding(3, 4, 3, 4);
            OpenUserListFormButton.Name = "OpenUserListFormButton";
            OpenUserListFormButton.Size = new Size(219, 55);
            OpenUserListFormButton.TabIndex = 2;
            OpenUserListFormButton.Text = "Lista użytkowników";
            OpenUserListFormButton.UseVisualStyleBackColor = true;
            OpenUserListFormButton.Click += OpenUserListFormButton_Click;
            // 
            // btnViewForgottenUsers
            // 
            btnViewForgottenUsers.Location = new Point(306, 274);
            btnViewForgottenUsers.Name = "btnViewForgottenUsers";
            btnViewForgottenUsers.Size = new Size(219, 68);
            btnViewForgottenUsers.TabIndex = 3;
            btnViewForgottenUsers.Text = "Lista zapomnianych użytkowników";
            btnViewForgottenUsers.UseVisualStyleBackColor = true;
            btnViewForgottenUsers.Click += btnViewForgottenUsers_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(44, 9);
            label1.Name = "label1";
            label1.Size = new Size(736, 67);
            label1.TabIndex = 4;
            label1.Text = "System zarządzania przychodnią";
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Location = new Point(652, 400);
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Size = new Size(148, 34);
            logoutMenuItem.TabIndex = 5;
            logoutMenuItem.Text = "Wyloguj się";
            logoutMenuItem.UseVisualStyleBackColor = true;
            logoutMenuItem.Click += logoutMenuItem_Click;
            // 
            // AdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 446);
            Controls.Add(logoutMenuItem);
            Controls.Add(label1);
            Controls.Add(btnViewForgottenUsers);
            Controls.Add(OpenUserListFormButton);
            Controls.Add(OpenAddUserFormButton);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button logoutMenuItem;
    }
}
