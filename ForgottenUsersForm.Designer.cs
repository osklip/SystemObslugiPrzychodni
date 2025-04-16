namespace SystemObslugiPrzychodni
{
    partial class ForgottenUsersForm
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
            dataGridViewForgottenUsers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewForgottenUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewForgottenUsers
            // 
            dataGridViewForgottenUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewForgottenUsers.Location = new Point(10, 9);
            dataGridViewForgottenUsers.Margin = new Padding(3, 2, 3, 2);
            dataGridViewForgottenUsers.Name = "dataGridViewForgottenUsers";
            dataGridViewForgottenUsers.RowHeadersWidth = 51;
            dataGridViewForgottenUsers.Size = new Size(666, 239);
            dataGridViewForgottenUsers.TabIndex = 0;
            // 
            // ForgottenUsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(dataGridViewForgottenUsers);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ForgottenUsersForm";
            Text = "Lista zapomnianych użytkowników";
            ((System.ComponentModel.ISupportInitialize)dataGridViewForgottenUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewForgottenUsers;
    }
}