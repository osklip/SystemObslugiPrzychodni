
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
            textBoxName = new TextBox();
            label5 = new Label();
            OpenUserDetailsForm2 = new Button();
            comboBoxPerms = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserList).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUserList
            // 
            dataGridViewUserList.AllowUserToAddRows = false;
            dataGridViewUserList.AllowUserToDeleteRows = false;
            dataGridViewUserList.AllowUserToOrderColumns = true;
            dataGridViewUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserList.Location = new Point(11, 113);
            dataGridViewUserList.Name = "dataGridViewUserList";
            dataGridViewUserList.ReadOnly = true;
            dataGridViewUserList.RowHeadersWidth = 51;
            dataGridViewUserList.Size = new Size(881, 425);
            dataGridViewUserList.TabIndex = 0;
            // 
            // OpenAdminMenuFormButton
            // 
            OpenAdminMenuFormButton.Location = new Point(817, 565);
            OpenAdminMenuFormButton.Name = "OpenAdminMenuFormButton";
            OpenAdminMenuFormButton.Size = new Size(75, 35);
            OpenAdminMenuFormButton.TabIndex = 1;
            OpenAdminMenuFormButton.Text = "Wyjdź";
            OpenAdminMenuFormButton.UseVisualStyleBackColor = true;
            OpenAdminMenuFormButton.Click += OpenAdminMenuFormButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(189, 20);
            label1.TabIndex = 2;
            label1.Text = "Wyszukiwanie użytkownika:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(11, 68);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(153, 27);
            textBoxLogin.TabIndex = 3;
            // 
            // SearchUserButton
            // 
            SearchUserButton.Location = new Point(817, 65);
            SearchUserButton.Name = "SearchUserButton";
            SearchUserButton.Size = new Size(75, 32);
            SearchUserButton.TabIndex = 4;
            SearchUserButton.Text = "Szukaj";
            SearchUserButton.UseVisualStyleBackColor = true;
            SearchUserButton.Click += SearchUserButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 40);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 5;
            label2.Text = "Login:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 40);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 6;
            label3.Text = "Nazwisko:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(473, 40);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 7;
            label4.Text = "PESEL:";
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(313, 68);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(153, 27);
            textBoxSurname.TabIndex = 8;
            // 
            // textBoxPESEL
            // 
            textBoxPESEL.Location = new Point(473, 68);
            textBoxPESEL.Name = "textBoxPESEL";
            textBoxPESEL.Size = new Size(153, 27);
            textBoxPESEL.TabIndex = 9;
            // 
            // ResetViewButton
            // 
            ResetViewButton.Location = new Point(817, 15);
            ResetViewButton.Name = "ResetViewButton";
            ResetViewButton.Size = new Size(75, 32);
            ResetViewButton.TabIndex = 10;
            ResetViewButton.Text = "Reset";
            ResetViewButton.UseVisualStyleBackColor = true;
            ResetViewButton.Click += ResetViewButton_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(171, 68);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(134, 27);
            textBoxName.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(171, 40);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 14;
            label5.Text = "Imię:";
            // 
            // OpenUserDetailsForm2
            // 
            OpenUserDetailsForm2.Location = new Point(11, 568);
            OpenUserDetailsForm2.Name = "OpenUserDetailsForm2";
            OpenUserDetailsForm2.Size = new Size(138, 31);
            OpenUserDetailsForm2.TabIndex = 15;
            OpenUserDetailsForm2.Text = "Wyświetl szczegóły";
            OpenUserDetailsForm2.UseVisualStyleBackColor = true;
            OpenUserDetailsForm2.Click += OpenUserDetailsForm2_Click_1;
            // 
            // comboBoxPerms
            // 
            comboBoxPerms.FormattingEnabled = true;
            comboBoxPerms.Location = new Point(633, 68);
            comboBoxPerms.Margin = new Padding(3, 4, 3, 4);
            comboBoxPerms.Name = "comboBoxPerms";
            comboBoxPerms.Size = new Size(153, 28);
            comboBoxPerms.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(633, 40);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 17;
            label6.Text = "Uprawnienia:";
            // 
            // UserListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 621);
            Controls.Add(label6);
            Controls.Add(comboBoxPerms);
            Controls.Add(OpenUserDetailsForm2);
            Controls.Add(label5);
            Controls.Add(textBoxName);
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
            Text = "Lista użytkowników";
            Load += UserListForm_Load;
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
        private TextBox textBoxName;
        private Label label5;
        private Button OpenUserDetailsForm2;
        private ComboBox comboBoxPerms;
        private Label label6;
    }
}