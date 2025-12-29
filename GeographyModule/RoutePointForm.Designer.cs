namespace GeographyModule
{
    partial class RoutepointForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView RoutepointsGridView;
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
            RoutepointsGridView = new System.Windows.Forms.DataGridView();
            colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colExcursion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            addButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)RoutepointsGridView).BeginInit();
            SuspendLayout();
            // 
            // RoutepointsGridView
            // 
            RoutepointsGridView.AllowUserToAddRows = false;
            RoutepointsGridView.AllowUserToDeleteRows = false;
            RoutepointsGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RoutepointsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            RoutepointsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RoutepointsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNo, colRoute, colCity, colEmployee, colHotel, colNumber, colDur, colExcursion });
            RoutepointsGridView.Location = new System.Drawing.Point(12, 12);
            RoutepointsGridView.MultiSelect = false;
            RoutepointsGridView.Name = "RoutepointsGridView";
            RoutepointsGridView.ReadOnly = true;
            RoutepointsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            RoutepointsGridView.Size = new System.Drawing.Size(905, 400);
            RoutepointsGridView.TabIndex = 0;
            // 
            // colNo
            // 
            colNo.HeaderText = "№";
            colNo.Name = "colNo";
            colNo.ReadOnly = true;
            colNo.Width = 45;
            // 
            // colRoute
            // 
            colRoute.HeaderText = "Маршрут";
            colRoute.Name = "colRoute";
            colRoute.ReadOnly = true;
            colRoute.Width = 85;
            // 
            // colCity
            // 
            colCity.HeaderText = "Город";
            colCity.Name = "colCity";
            colCity.ReadOnly = true;
            colCity.Width = 65;
            // 
            // colEmployee
            // 
            colEmployee.HeaderText = "Добавлен";
            colEmployee.Name = "colEmployee";
            colEmployee.ReadOnly = true;
            colEmployee.Width = 86;
            // 
            // colHotel
            // 
            colHotel.HeaderText = "Гостиница";
            colHotel.Name = "colHotel";
            colHotel.ReadOnly = true;
            colHotel.Width = 90;
            // 
            // colNumber
            // 
            colNumber.HeaderText = "Порядковый номер";
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;
            colNumber.Width = 129;
            // 
            // colDur
            // 
            colDur.HeaderText = "Срок пребывания";
            colDur.Name = "colDur";
            colDur.ReadOnly = true;
            colDur.Width = 120;
            // 
            // colExcursion
            // 
            colExcursion.HeaderText = "Экскурсия";
            colExcursion.Name = "colExcursion";
            colExcursion.ReadOnly = true;
            colExcursion.Width = 89;
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
            // RoutepointForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(929, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(RoutepointsGridView);
            Name = "RoutepointForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Пункты маршрутов";
            ((System.ComponentModel.ISupportInitialize)RoutepointsGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDur;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExcursion;
    }
}