namespace GeographyModule
{
    partial class HotelForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView hotelsGridView;
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
            hotelsGridView = new System.Windows.Forms.DataGridView();
            addButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colStars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)hotelsGridView).BeginInit();
            SuspendLayout();
            // 
            // hotelsGridView
            // 
            hotelsGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hotelsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            hotelsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNo, colName, colCity, colStars });
            hotelsGridView.Location = new System.Drawing.Point(12, 12);
            hotelsGridView.MultiSelect = false;
            hotelsGridView.Name = "hotelsGridView";
            hotelsGridView.ReadOnly = true;
            hotelsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            hotelsGridView.Size = new System.Drawing.Size(760, 400);
            hotelsGridView.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            addButton.Location = new System.Drawing.Point(12, 420);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(90, 30);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            editButton.Location = new System.Drawing.Point(108, 420);
            editButton.Name = "editButton";
            editButton.Size = new System.Drawing.Size(90, 30);
            editButton.TabIndex = 2;
            editButton.Text = "Редактировать";
            editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            deleteButton.Location = new System.Drawing.Point(204, 420);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(90, 30);
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
            // colName
            // 
            colName.HeaderText = "Название";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colCity
            // 
            colCity.HeaderText = "Город";
            colCity.Name = "colCity";
            colCity.ReadOnly = true;
            // 
            // colStars
            // 
            colStars.HeaderText = "Звёзды";
            colStars.Name = "colStars";
            colStars.ReadOnly = true;
            // 
            // HotelForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(hotelsGridView);
            Name = "HotelForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Гостиницы";
            ((System.ComponentModel.ISupportInitialize)hotelsGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStars;
    }
}