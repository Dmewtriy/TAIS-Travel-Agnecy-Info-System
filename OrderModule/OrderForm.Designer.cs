namespace GeographyModule
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView OrdersGridView;
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
            OrdersGridView = new DataGridView();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            colNo = new DataGridViewTextBoxColumn();
            colClient = new DataGridViewTextBoxColumn();
            colTrip = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)OrdersGridView).BeginInit();
            SuspendLayout();
            // 
            // OrdersGridView
            // 
            OrdersGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrdersGridView.Columns.AddRange(new DataGridViewColumn[] { colNo, colClient, colTrip, colDate, colTime });
            OrdersGridView.Location = new Point(12, 12);
            OrdersGridView.MultiSelect = false;
            OrdersGridView.Name = "OrdersGridView";
            OrdersGridView.ReadOnly = true;
            OrdersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            OrdersGridView.Size = new Size(760, 400);
            OrdersGridView.TabIndex = 0;
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
            // colClient
            // 
            colClient.HeaderText = "Клиент";
            colClient.Name = "colClient";
            colClient.ReadOnly = true;
            // 
            // colTrip
            // 
            colTrip.HeaderText = "Поездка";
            colTrip.Name = "colTrip";
            colTrip.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.HeaderText = "Дата";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.HeaderText = "Время";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(OrdersGridView);
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Маршруты";
            ((System.ComponentModel.ISupportInitialize)OrdersGridView).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colClient;
        private DataGridViewTextBoxColumn colTrip;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
    }
}