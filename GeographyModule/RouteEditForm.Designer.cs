namespace GeographyModule
{
    partial class RouteEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox employeeCombo;
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
            countryLabel = new System.Windows.Forms.Label();
            employeeCombo = new System.Windows.Forms.ComboBox();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            countryCombo = new System.Windows.Forms.ComboBox();
            nameTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            durationText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(13, 137);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(65, 15);
            countryLabel.TabIndex = 3;
            countryLabel.Text = "Составлен";
            // 
            // employeeCombo
            // 
            employeeCombo.Location = new System.Drawing.Point(13, 155);
            employeeCombo.Name = "employeeCombo";
            employeeCombo.Size = new System.Drawing.Size(360, 23);
            employeeCombo.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(217, 262);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(298, 262);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 196);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 3;
            label1.Text = "Страна";
            // 
            // countryCombo
            // 
            countryCombo.Location = new System.Drawing.Point(13, 214);
            countryCombo.Name = "countryCombo";
            countryCombo.Size = new System.Drawing.Size(360, 23);
            countryCombo.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(13, 40);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(360, 23);
            nameTextBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(59, 15);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Название";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(13, 100);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 23);
            numericUpDown1.TabIndex = 6;
            // 
            // durationText
            // 
            durationText.AutoSize = true;
            durationText.BackColor = System.Drawing.SystemColors.Control;
            durationText.Location = new System.Drawing.Point(12, 82);
            durationText.Name = "durationText";
            durationText.Size = new System.Drawing.Size(121, 15);
            durationText.TabIndex = 5;
            durationText.Text = "Продолжительность";
            // 
            // RouteEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 299);
            Controls.Add(numericUpDown1);
            Controls.Add(nameTextBox);
            Controls.Add(durationText);
            Controls.Add(nameLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(countryCombo);
            Controls.Add(employeeCombo);
            Controls.Add(label1);
            Controls.Add(countryLabel);
            Name = "RouteEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Маршрут";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox countryCombo;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label durationText;
    }
}