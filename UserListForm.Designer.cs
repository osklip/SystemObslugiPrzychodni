
namespace SystemObslugiPrzychodni
{
    partial class UserListForm
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
            dataGridViewUserList = new DataGridView();
            OpenAdminMenuFormButton = new Button();
            label1 = new Label();
            textBoxLogin = new TextBox();
            SearchUserButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxSurname = new TextBox();
            textBoxPESEL = new TextBox();
            ResetViewButton = new Button();
            OpenUserDetailsForm = new Button();
            textBoxName = new TextBox();
            label5 = new Label();
            OpenUserDetailsForm2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserList).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUserList
            // 
            dataGridViewUserList.AllowUserToAddRows = false;
            dataGridViewUserList.AllowUserToDeleteRows = false;
            dataGridViewUserList.AllowUserToOrderColumns = true;
            dataGridViewUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserList.Location = new Point(10, 85);
            dataGridViewUserList.Margin = new Padding(3, 2, 3, 2);
            dataGridViewUserList.Name = "dataGridViewUserList";
            dataGridViewUserList.ReadOnly = true;
            dataGridViewUserList.RowHeadersWidth = 51;
            dataGridViewUserList.Size = new Size(702, 319);
            dataGridViewUserList.TabIndex = 0;
            // 
            // OpenAdminMenuFormButton
            // 
            OpenAdminMenuFormButton.Location = new Point(646, 424);
            OpenAdminMenuFormButton.Margin = new Padding(3, 2, 3, 2);
            OpenAdminMenuFormButton.Name = "OpenAdminMenuFormButton";
            OpenAdminMenuFormButton.Size = new Size(66, 26);
            OpenAdminMenuFormButton.TabIndex = 1;
            OpenAdminMenuFormButton.Text = "Wyjdź";
            OpenAdminMenuFormButton.UseVisualStyleBackColor = true;
            OpenAdminMenuFormButton.Click += OpenAdminMenuFormButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(153, 15);
            label1.TabIndex = 2;
            label1.Text = "Wyszukiwanie użytkownika:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(10, 51);
            textBoxLogin.Margin = new Padding(3, 2, 3, 2);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(134, 23);
            textBoxLogin.TabIndex = 3;
            // 
            // SearchUserButton
            // 
            SearchUserButton.Location = new Point(646, 49);
            SearchUserButton.Margin = new Padding(3, 2, 3, 2);
            SearchUserButton.Name = "SearchUserButton";
            SearchUserButton.Size = new Size(66, 24);
            SearchUserButton.TabIndex = 4;
            SearchUserButton.Text = "Szukaj";
            SearchUserButton.UseVisualStyleBackColor = true;
            SearchUserButton.Click += SearchUserButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 30);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Login:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 30);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 6;
            label3.Text = "Nazwisko:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(444, 30);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 7;
            label4.Text = "PESEL:";
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(291, 51);
            textBoxSurname.Margin = new Padding(3, 2, 3, 2);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(134, 23);
            textBoxSurname.TabIndex = 8;
            // 
            // textBoxPESEL
            // 
            textBoxPESEL.Location = new Point(444, 51);
            textBoxPESEL.Margin = new Padding(3, 2, 3, 2);
            textBoxPESEL.Name = "textBoxPESEL";
            textBoxPESEL.Size = new Size(134, 23);
            textBoxPESEL.TabIndex = 9;
            // 
            // ResetViewButton
            // 
            ResetViewButton.Location = new Point(646, 11);
            ResetViewButton.Margin = new Padding(3, 2, 3, 2);
            ResetViewButton.Name = "ResetViewButton";
            ResetViewButton.Size = new Size(66, 24);
            ResetViewButton.TabIndex = 10;
            ResetViewButton.Text = "Reset";
            ResetViewButton.UseVisualStyleBackColor = true;
            ResetViewButton.Click += ResetViewButton_Click;
            // 
            // OpenUserDetailsForm
            // 
            OpenUserDetailsForm.Location = new Point(10, 464);
            OpenUserDetailsForm.Margin = new Padding(3, 2, 3, 2);
            OpenUserDetailsForm.Name = "OpenUserDetailsForm";
            OpenUserDetailsForm.Size = new Size(134, 17);
            OpenUserDetailsForm.TabIndex = 11;
            OpenUserDetailsForm.Text = "Szczegóły użytkownika";
            OpenUserDetailsForm.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(160, 51);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(118, 23);
            textBoxName.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(160, 30);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 14;
            label5.Text = "Imię:";
            // 
            // OpenUserDetailsForm2
            // 
            OpenUserDetailsForm2.Location = new Point(12, 427);
            OpenUserDetailsForm2.Margin = new Padding(3, 2, 3, 2);
            OpenUserDetailsForm2.Name = "OpenUserDetailsForm2";
            OpenUserDetailsForm2.Size = new Size(121, 23);
            OpenUserDetailsForm2.TabIndex = 15;
            OpenUserDetailsForm2.Text = "Wyświetl szczegóły";
            OpenUserDetailsForm2.UseVisualStyleBackColor = true;
            OpenUserDetailsForm2.Click += OpenUserDetailsForm2_Click_1;
            // 
            // UserListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 461);
            Controls.Add(OpenUserDetailsForm2);
            Controls.Add(label5);
            Controls.Add(textBoxName);
            Controls.Add(OpenUserDetailsForm);
            Controls.Add(ResetViewButton);
            Controls.Add(textBoxPESEL);
            Controls.Add(textBoxSurname);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(SearchUserButton);
            Controls.Add(textBoxLogin);
            Controls.Add(label1);
            Controls.Add(OpenAdminMenuFormButton);
            Controls.Add(dataGridViewUserList);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserListForm";
            Text = "Lista użytkowników";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUserList;
        private Button OpenAdminMenuFormButton;
        private Label label1;
        private TextBox textBoxLogin;
        private Button SearchUserButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxSurname;
        private TextBox textBoxPESEL;
        private Button ResetViewButton;
        private Button OpenUserDetailsForm;
        private TextBox textBoxName;
        private Label label5;
        private Button OpenUserDetailsForm2;
    }
}