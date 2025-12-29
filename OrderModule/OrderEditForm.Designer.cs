namespace GeographyModule
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox tripCombo;
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
            countryLabel = new Label();
            tripCombo = new ComboBox();
            okButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            nameLabel = new Label();
            clientCombo = new ComboBox();
            label2 = new Label();
            datePick = new DateTimePicker();
            timePick = new DateTimePicker();
            SuspendLayout();
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new Point(12, 78);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(52, 15);
            countryLabel.TabIndex = 3;
            countryLabel.Text = "Поездка";
            // 
            // tripCombo
            // 
            tripCombo.Location = new Point(12, 96);
            tripCombo.Name = "tripCombo";
            tripCombo.Size = new Size(360, 23);
            tripCombo.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new Point(217, 262);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(298, 262);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 134);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Дата";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(46, 15);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Клиент";
            // 
            // clientCombo
            // 
            clientCombo.Location = new Point(12, 40);
            clientCombo.Name = "clientCombo";
            clientCombo.Size = new Size(360, 23);
            clientCombo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(217, 134);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Время";
            // 
            // datePick
            // 
            datePick.Format = DateTimePickerFormat.Short;
            datePick.Location = new Point(12, 152);
            datePick.Name = "datePick";
            datePick.Size = new Size(129, 23);
            datePick.TabIndex = 6;
            // 
            // timePick
            // 
            timePick.Format = DateTimePickerFormat.Time;
            timePick.Location = new Point(217, 152);
            timePick.Name = "timePick";
            timePick.Size = new Size(129, 23);
            timePick.TabIndex = 6;
            // 
            // OrderEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 299);
            Controls.Add(timePick);
            Controls.Add(datePick);
            Controls.Add(nameLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(clientCombo);
            Controls.Add(tripCombo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(countryLabel);
            Name = "OrderEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказ";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameLabel;
        private ComboBox clientCombo;
        private Label label2;
        private DateTimePicker datePick;
        private DateTimePicker timePick;
    }
}