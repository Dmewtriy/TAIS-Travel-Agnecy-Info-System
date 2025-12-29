namespace GeographyModule
{
    partial class VoyageForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView voyagesGridView;
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
            voyagesGridView = new System.Windows.Forms.DataGridView();
            addButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCarrier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAircraftType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)voyagesGridView).BeginInit();
            SuspendLayout();
            // 
            // voyagesGridView
            // 
            voyagesGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            voyagesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            voyagesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNo, colCarrier, colAircraftType });
            voyagesGridView.Location = new System.Drawing.Point(12, 12);
            voyagesGridView.MultiSelect = false;
            voyagesGridView.Name = "voyagesGridView";
            voyagesGridView.ReadOnly = true;
            voyagesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            voyagesGridView.Size = new System.Drawing.Size(760, 400);
            voyagesGridView.TabIndex = 0;
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
            // colCarrier
            // 
            colCarrier.HeaderText = "Перевозчик";
            colCarrier.Name = "colCarrier";
            colCarrier.ReadOnly = true;
            // 
            // colAircraftType
            // 
            colAircraftType.HeaderText = "Тип самолёта";
            colAircraftType.Name = "colAircraftType";
            colAircraftType.ReadOnly = true;
            // 
            // VoyageForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(voyagesGridView);
            Name = "VoyageForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Рейсы";
            ((System.ComponentModel.ISupportInitialize)voyagesGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarrier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAircraftType;
    }
}