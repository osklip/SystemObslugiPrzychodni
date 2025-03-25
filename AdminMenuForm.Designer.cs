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
            SuspendLayout();
            // 
            // OpenAddUserFormButton
            // 
            OpenAddUserFormButton.Location = new Point(376, 241);
            OpenAddUserFormButton.Name = "OpenAddUserFormButton";
            OpenAddUserFormButton.Size = new Size(192, 41);
            OpenAddUserFormButton.TabIndex = 1;
            OpenAddUserFormButton.Text = "Dodaj użytkownika";
            OpenAddUserFormButton.UseVisualStyleBackColor = true;
            OpenAddUserFormButton.Click += OpenAddUserFormButton_Click;
            // 
            // OpenUserListFormButton
            // 
            OpenUserListFormButton.Location = new Point(376, 298);
            OpenUserListFormButton.Name = "OpenUserListFormButton";
            OpenUserListFormButton.Size = new Size(192, 36);
            OpenUserListFormButton.TabIndex = 2;
            OpenUserListFormButton.Text = "Lista użytkowników";
            OpenUserListFormButton.UseVisualStyleBackColor = true;
            OpenUserListFormButton.Click += OpenUserListFormButton_Click;
            // 
            // AdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 571);
            Controls.Add(OpenUserListFormButton);
            Controls.Add(OpenAddUserFormButton);
            Name = "AdminMenuForm";
            Text = "Menu Administracyjne";
            ResumeLayout(false);
        }

        #endregion
        private Button OpenAddUserFormButton;
        private Button OpenUserListFormButton;
    }
}
