
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
            BtnForgetUser = new Button();
            textBoxName = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserList).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUserList
            // 
            dataGridViewUserList.AllowUserToAddRows = false;
            dataGridViewUserList.AllowUserToDeleteRows = false;
            dataGridViewUserList.AllowUserToOrderColumns = true;
            dataGridViewUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserList.Location = new Point(12, 113);
            dataGridViewUserList.Name = "dataGridViewUserList";
            dataGridViewUserList.ReadOnly = true;
            dataGridViewUserList.RowHeadersWidth = 51;
            dataGridViewUserList.Size = new Size(768, 485);
            dataGridViewUserList.TabIndex = 0;
            // 
            // OpenAdminMenuFormButton
            // 
            OpenAdminMenuFormButton.Location = new Point(705, 618);
            OpenAdminMenuFormButton.Name = "OpenAdminMenuFormButton";
            OpenAdminMenuFormButton.Size = new Size(75, 23);
            OpenAdminMenuFormButton.TabIndex = 1;
            OpenAdminMenuFormButton.Text = "Wyjdź";
            OpenAdminMenuFormButton.UseVisualStyleBackColor = true;
            OpenAdminMenuFormButton.Click += OpenAdminMenuFormButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(153, 15);
            label1.TabIndex = 2;
            label1.Text = "Wyszukiwanie użytkownika:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(12, 68);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(153, 23);
            textBoxLogin.TabIndex = 3;
            // 
            // SearchUserButton
            // 
            SearchUserButton.Location = new Point(705, 69);
            SearchUserButton.Name = "SearchUserButton";
            SearchUserButton.Size = new Size(75, 23);
            SearchUserButton.TabIndex = 4;
            SearchUserButton.Text = "Szukaj";
            SearchUserButton.UseVisualStyleBackColor = true;
            SearchUserButton.Click += SearchUserButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Login:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(369, 40);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 6;
            label3.Text = "Nazwisko:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(546, 40);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 7;
            label4.Text = "PESEL:";
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(369, 68);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(153, 23);
            textBoxSurname.TabIndex = 8;
            // 
            // textBoxPESEL
            // 
            textBoxPESEL.Location = new Point(546, 68);
            textBoxPESEL.Name = "textBoxPESEL";
            textBoxPESEL.Size = new Size(153, 23);
            textBoxPESEL.TabIndex = 9;
            // 
            // ResetViewButton
            // 
            ResetViewButton.Location = new Point(705, 36);
            ResetViewButton.Name = "ResetViewButton";
            ResetViewButton.Size = new Size(75, 23);
            ResetViewButton.TabIndex = 10;
            ResetViewButton.Text = "Reset";
            ResetViewButton.UseVisualStyleBackColor = true;
            ResetViewButton.Click += ResetViewButton_Click;
            // 
            // OpenUserDetailsForm
            // 
            OpenUserDetailsForm.Location = new Point(12, 618);
            OpenUserDetailsForm.Name = "OpenUserDetailsForm";
            OpenUserDetailsForm.Size = new Size(153, 23);
            OpenUserDetailsForm.TabIndex = 11;
            OpenUserDetailsForm.Text = "Szczegóły użytkownika";
            OpenUserDetailsForm.UseVisualStyleBackColor = true;
            OpenUserDetailsForm.Click += OpenUserDetailsForm_Click;
            // 
            // BtnForgetUser
            // 
            BtnForgetUser.Location = new Point(184, 620);
            BtnForgetUser.Margin = new Padding(3, 2, 3, 2);
            BtnForgetUser.Name = "BtnForgetUser";
            BtnForgetUser.Size = new Size(158, 22);
            BtnForgetUser.TabIndex = 12;
            BtnForgetUser.Text = "Zapomij użytkownika";
            BtnForgetUser.UseVisualStyleBackColor = true;
            BtnForgetUser.Click += BtnForgetUser_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(189, 68);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(153, 23);
            textBoxName.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(189, 40);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 14;
            label5.Text = "Imię:";
            // 
            // UserListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 653);
            Controls.Add(label5);
            Controls.Add(textBoxName);
            Controls.Add(BtnForgetUser);
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
            Name = "UserListForm";
            Text = "UserListForm";
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
        private Button BtnForgetUser;
        private TextBox textBoxName;
        private Label label5;
    }
}