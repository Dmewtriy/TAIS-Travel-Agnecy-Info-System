namespace GeographyModule
{
    partial class CityEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox countryCombo;
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
            countryLabel = new System.Windows.Forms.Label();
            countryCombo = new System.Windows.Forms.ComboBox();
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
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(12, 35);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(360, 23);
            nameTextBox.TabIndex = 1;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(12, 65);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(46, 15);
            countryLabel.TabIndex = 3;
            countryLabel.Text = "Страна";
            // 
            // countryCombo
            // 
            countryCombo.Location = new System.Drawing.Point(12, 85);
            countryCombo.Name = "countryCombo";
            countryCombo.Size = new System.Drawing.Size(360, 23);
            countryCombo.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(216, 120);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(297, 120);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // CityEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 161);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(countryCombo);
            Controls.Add(countryLabel);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Name = "CityEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Город";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}