namespace GeographyModule
{
    partial class HotelEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.ComboBox cityCombo;
        private System.Windows.Forms.Label starsLabel;
        private System.Windows.Forms.ComboBox starsCombo;
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
            cityLabel = new System.Windows.Forms.Label();
            cityCombo = new System.Windows.Forms.ComboBox();
            starsLabel = new System.Windows.Forms.Label();
            starsCombo = new System.Windows.Forms.ComboBox();
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
            nameLabel.TabIndex = 6;
            nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(12, 35);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(360, 23);
            nameTextBox.TabIndex = 1;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(12, 65);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(40, 15);
            cityLabel.TabIndex = 5;
            cityLabel.Text = "Город";
            // 
            // cityCombo
            // 
            cityCombo.Location = new System.Drawing.Point(12, 85);
            cityCombo.Name = "cityCombo";
            cityCombo.Size = new System.Drawing.Size(360, 23);
            cityCombo.TabIndex = 2;
            // 
            // starsLabel
            // 
            starsLabel.AutoSize = true;
            starsLabel.Location = new System.Drawing.Point(12, 115);
            starsLabel.Name = "starsLabel";
            starsLabel.Size = new System.Drawing.Size(46, 15);
            starsLabel.TabIndex = 4;
            starsLabel.Text = "Звезды";
            // 
            // starsCombo
            // 
            starsCombo.Location = new System.Drawing.Point(12, 135);
            starsCombo.Name = "starsCombo";
            starsCombo.Size = new System.Drawing.Size(120, 23);
            starsCombo.TabIndex = 3;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(216, 170);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(297, 170);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // HotelEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 211);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(starsCombo);
            Controls.Add(starsLabel);
            Controls.Add(cityCombo);
            Controls.Add(cityLabel);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Name = "HotelEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Гостиница";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}