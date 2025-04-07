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
            SuspendLayout();
            // 
            // OpenAddUserFormButton
            // 
            OpenAddUserFormButton.Location = new Point(430, 321);
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
            OpenUserListFormButton.Location = new Point(430, 397);
            OpenUserListFormButton.Margin = new Padding(3, 4, 3, 4);
            OpenUserListFormButton.Name = "OpenUserListFormButton";
            OpenUserListFormButton.Size = new Size(219, 48);
            OpenUserListFormButton.TabIndex = 2;
            OpenUserListFormButton.Text = "Lista użytkowników";
            OpenUserListFormButton.UseVisualStyleBackColor = true;
            OpenUserListFormButton.Click += OpenUserListFormButton_Click;
            // 
            // btnViewForgottenUsers
            // 
            btnViewForgottenUsers.Location = new Point(430, 468);
            btnViewForgottenUsers.Name = "btnViewForgottenUsers";
            btnViewForgottenUsers.Size = new Size(219, 49);
            btnViewForgottenUsers.TabIndex = 3;
            btnViewForgottenUsers.Text = "Lista zapomnianych użytkowników";
            btnViewForgottenUsers.UseVisualStyleBackColor = true;
            btnViewForgottenUsers.Click += btnViewForgottenUsers_Click;
            // 
            // AdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 761);
            Controls.Add(btnViewForgottenUsers);
            Controls.Add(OpenUserListFormButton);
            Controls.Add(OpenAddUserFormButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminMenuForm";
            Text = "Menu Administracyjne";
            ResumeLayout(false);
        }

        #endregion
        private Button OpenAddUserFormButton;
        private Button OpenUserListFormButton;
        private Button btnViewForgottenUsers;
    }
}
