namespace GeographyModule
{
    partial class PositionEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
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
            titleLabel = new System.Windows.Forms.Label();
            titleTextBox = new System.Windows.Forms.TextBox();
            descLabel = new System.Windows.Forms.Label();
            descriptionTextBox = new System.Windows.Forms.TextBox();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(12, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(69, 15);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Должность";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new System.Drawing.Point(12, 35);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new System.Drawing.Size(360, 23);
            titleTextBox.TabIndex = 1;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new System.Drawing.Point(12, 65);
            descLabel.Name = "descLabel";
            descLabel.Size = new System.Drawing.Size(53, 15);
            descLabel.TabIndex = 3;
            descLabel.Text = "ОКПДТР";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new System.Drawing.Point(12, 85);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new System.Drawing.Size(360, 120);
            descriptionTextBox.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(216, 215);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(297, 215);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // PositionEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 251);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(descLabel);
            Controls.Add(titleTextBox);
            Controls.Add(titleLabel);
            Name = "PositionEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Должность";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}