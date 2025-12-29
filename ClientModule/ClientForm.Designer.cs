namespace ClientModule
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView clientsGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            clientsGridView = new DataGridView();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            colNo = new DataGridViewTextBoxColumn();
            colSurname = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPatronymic = new DataGridViewTextBoxColumn();
            colBirthDate = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)clientsGridView).BeginInit();
            SuspendLayout();
            // 
            // clientsGridView
            // 
            clientsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsGridView.Columns.AddRange(new DataGridViewColumn[] { colNo, colSurname, colName, colPatronymic, colBirthDate, colPhone });
            clientsGridView.Location = new Point(12, 12);
            clientsGridView.MultiSelect = false;
            clientsGridView.Name = "clientsGridView";
            clientsGridView.ReadOnly = true;
            clientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsGridView.Size = new Size(760, 400);
            clientsGridView.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addButton.Location = new Point(12, 420);
            addButton.Name = "addButton";
            addButton.Size = new Size(90, 30);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            editButton.Location = new Point(108, 420);
            editButton.Name = "editButton";
            editButton.Size = new Size(90, 30);
            editButton.TabIndex = 2;
            editButton.Text = "Редактировать";
            editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteButton.Location = new Point(204, 420);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(90, 30);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // colNo
            // 
            colNo.HeaderText = "№";
            colNo.Name = "colNo";
            colNo.ReadOnly = true;
            // 
            // colSurname
            // 
            colSurname.HeaderText = "Фамилия";
            colSurname.Name = "colSurname";
            colSurname.ReadOnly = true;
            // 
            // colName
            // 
            colName.HeaderText = "Имя";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPatronymic
            // 
            colPatronymic.HeaderText = "Отчество";
            colPatronymic.Name = "colPatronymic";
            colPatronymic.ReadOnly = true;
            // 
            // colBirthDate
            // 
            colBirthDate.HeaderText = "Дата рождения";
            colBirthDate.Name = "colBirthDate";
            colBirthDate.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "Телефон";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(clientsGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientForm";
            Text = "Клиенты";
            ((System.ComponentModel.ISupportInitialize)clientsGridView).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colSurname;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPatronymic;
        private DataGridViewTextBoxColumn colBirthDate;
        private DataGridViewTextBoxColumn colPhone;
    }
}