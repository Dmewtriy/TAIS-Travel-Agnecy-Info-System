namespace TripModule
{
    partial class TripForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView TripsGridView;
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
            TripsGridView = new DataGridView();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            colNo = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCompRepr = new DataGridViewTextBoxColumn();
            colFrom = new DataGridViewTextBoxColumn();
            colTo = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colPenalty = new DataGridViewTextBoxColumn();
            colDateFrom = new DataGridViewTextBoxColumn();
            colDateTo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)TripsGridView).BeginInit();
            SuspendLayout();
            // 
            // TripsGridView
            // 
            TripsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TripsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TripsGridView.Columns.AddRange(new DataGridViewColumn[] { colNo, colName, colCompRepr, colFrom, colTo, colPrice, colPenalty, colDateFrom, colDateTo });
            TripsGridView.Location = new Point(12, 12);
            TripsGridView.MultiSelect = false;
            TripsGridView.Name = "TripsGridView";
            TripsGridView.ReadOnly = true;
            TripsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TripsGridView.Size = new Size(948, 400);
            TripsGridView.TabIndex = 0;
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
            // colName
            // 
            colName.HeaderText = "Название";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colCompRepr
            // 
            colCompRepr.HeaderText = "Представитель";
            colCompRepr.Name = "colCompRepr";
            colCompRepr.ReadOnly = true;
            // 
            // colFrom
            // 
            colFrom.HeaderText = "Рейс вылета";
            colFrom.Name = "colFrom";
            colFrom.ReadOnly = true;
            // 
            // colTo
            // 
            colTo.HeaderText = "Рейс прилёта";
            colTo.Name = "colTo";
            colTo.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Цена";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colPenalty
            // 
            colPenalty.HeaderText = "Неустойка";
            colPenalty.Name = "colPenalty";
            colPenalty.ReadOnly = true;
            // 
            // colDateFrom
            // 
            colDateFrom.HeaderText = "Дата вылета";
            colDateFrom.Name = "colDateFrom";
            colDateFrom.ReadOnly = true;
            // 
            // colDateTo
            // 
            colDateTo.HeaderText = "Дата прилёта";
            colDateTo.Name = "colDateTo";
            colDateTo.ReadOnly = true;
            // 
            // TripForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(TripsGridView);
            Name = "TripForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Рейсы";
            ((System.ComponentModel.ISupportInitialize)TripsGridView).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCompRepr;
        private DataGridViewTextBoxColumn colFrom;
        private DataGridViewTextBoxColumn colTo;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colPenalty;
        private DataGridViewTextBoxColumn colDateFrom;
        private DataGridViewTextBoxColumn colDateTo;
    }
}