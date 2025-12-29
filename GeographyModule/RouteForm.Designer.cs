namespace GeographyModule
{
    partial class RouteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView RoutesGridView;
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
            RoutesGridView = new System.Windows.Forms.DataGridView();
            addButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)RoutesGridView).BeginInit();
            SuspendLayout();
            // 
            // RoutesGridView
            // 
            RoutesGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RoutesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RoutesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNo, colName, colDur, colEmployee, colCountry });
            RoutesGridView.Location = new System.Drawing.Point(12, 12);
            RoutesGridView.MultiSelect = false;
            RoutesGridView.Name = "RoutesGridView";
            RoutesGridView.ReadOnly = true;
            RoutesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            RoutesGridView.Size = new System.Drawing.Size(760, 400);
            RoutesGridView.TabIndex = 0;
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
            // colDur
            // 
            colDur.HeaderText = "Продолжительность";
            colDur.Name = "colDur";
            colDur.ReadOnly = true;
            // 
            // colEmployee
            // 
            colEmployee.HeaderText = "Составлен";
            colEmployee.Name = "colEmployee";
            colEmployee.ReadOnly = true;
            // 
            // colCountry
            // 
            colCountry.HeaderText = "Страна";
            colCountry.Name = "colCountry";
            colCountry.ReadOnly = true;
            // 
            // RouteForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(RoutesGridView);
            Name = "RouteForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Маршруты";
            ((System.ComponentModel.ISupportInitialize)RoutesGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDur;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
    }
}