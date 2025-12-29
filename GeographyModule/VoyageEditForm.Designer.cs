namespace GeographyModule
{
    partial class VoyageEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox carrierCombo;
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
            carrierCombo = new System.Windows.Forms.ComboBox();
            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            aircraftCombo = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(12, 13);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(73, 15);
            countryLabel.TabIndex = 3;
            countryLabel.Text = "Перевозчик";
            // 
            // carrierCombo
            // 
            carrierCombo.Location = new System.Drawing.Point(12, 33);
            carrierCombo.Name = "carrierCombo";
            carrierCombo.Size = new System.Drawing.Size(360, 23);
            carrierCombo.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(216, 121);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(297, 121);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 74);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 15);
            label1.TabIndex = 3;
            label1.Text = "Тип самолёта";
            // 
            // aircraftCombo
            // 
            aircraftCombo.Location = new System.Drawing.Point(12, 92);
            aircraftCombo.Name = "aircraftCombo";
            aircraftCombo.Size = new System.Drawing.Size(360, 23);
            aircraftCombo.TabIndex = 2;
            // 
            // VoyageEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 168);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(aircraftCombo);
            Controls.Add(carrierCombo);
            Controls.Add(label1);
            Controls.Add(countryLabel);
            Name = "VoyageEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Город";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox aircraftCombo;
    }
}