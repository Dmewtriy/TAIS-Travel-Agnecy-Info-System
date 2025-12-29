namespace GeographyModule
{
    partial class StreetEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;

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
            nameLabel = new System.Windows.Forms.Label();
            nameTextBox = new System.Windows.Forms.TextBox();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(59, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(12, 35);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(360, 23);
            nameTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(216, 70);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(297, 70);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // StreetEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 111);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Name = "StreetEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Улица";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}