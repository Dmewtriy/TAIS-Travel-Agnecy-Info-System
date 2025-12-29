namespace GeographyModule
{
    partial class PositionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView positionsGridView;
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
            positionsGridView = new System.Windows.Forms.DataGridView();
            addButton = new System.Windows.Forms.Button();
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOKPDTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)positionsGridView).BeginInit();
            SuspendLayout();
            // 
            // positionsGridView
            // 
            positionsGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            positionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            positionsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNo, colTitle, colOKPDTR });
            positionsGridView.Location = new System.Drawing.Point(12, 12);
            positionsGridView.MultiSelect = false;
            positionsGridView.Name = "positionsGridView";
            positionsGridView.ReadOnly = true;
            positionsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            positionsGridView.Size = new System.Drawing.Size(760, 400);
            positionsGridView.TabIndex = 0;
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
            // colTitle
            // 
            colTitle.HeaderText = "Название";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colOKPDTR
            // 
            colOKPDTR.HeaderText = "ОКПДТР";
            colOKPDTR.Name = "colOKPDTR";
            colOKPDTR.ReadOnly = true;
            // 
            // PositionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(positionsGridView);
            Name = "PositionForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Должности";
            ((System.ComponentModel.ISupportInitialize)positionsGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOKPDTR;
    }
}