namespace GeographyModule
{
    partial class AircraftTypeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView countriesGridView;
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
            countriesGridView = new System.Windows.Forms.DataGridView();
            addButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)countriesGridView).BeginInit();
            SuspendLayout();
            // 
            // countriesGridView
            // 
            countriesGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            countriesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            countriesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNo, colName });
            countriesGridView.Location = new System.Drawing.Point(12, 12);
            countriesGridView.MultiSelect = false;
            countriesGridView.Name = "countriesGridView";
            countriesGridView.ReadOnly = true;
            countriesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            countriesGridView.Size = new System.Drawing.Size(560, 320);
            countriesGridView.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            addButton.Location = new System.Drawing.Point(12, 340);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(90, 30);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            editButton.Location = new System.Drawing.Point(108, 340);
            editButton.Name = "editButton";
            editButton.Size = new System.Drawing.Size(90, 30);
            editButton.TabIndex = 2;
            editButton.Text = "Редактировать";
            editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            deleteButton.Location = new System.Drawing.Point(204, 340);
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
            // AircraftTypeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(584, 381);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(countriesGridView);
            Name = "AircraftTypeForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Типы самолётов";
            ((System.ComponentModel.ISupportInitialize)countriesGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}