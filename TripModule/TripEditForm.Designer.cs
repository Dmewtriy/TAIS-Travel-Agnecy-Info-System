namespace TripModule
{
    partial class TripEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.ComboBox routeCombo;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.ComboBox compReprCombo;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateToPicker;
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
            nameLabel = new Label();
            fromLabel = new Label();
            routeCombo = new ComboBox();
            toLabel = new Label();
            compReprCombo = new ComboBox();
            dateLabel = new Label();
            dateToPicker = new DateTimePicker();
            okButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            dateFromPicker = new DateTimePicker();
            priceUD = new NumericUpDown();
            label2 = new Label();
            penaltyUD = new NumericUpDown();
            label4 = new Label();
            toCombo = new ComboBox();
            label5 = new Label();
            fromCombo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)priceUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)penaltyUD).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 313);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(82, 15);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Цена поездки";
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.Location = new Point(12, 20);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(60, 15);
            fromLabel.TabIndex = 7;
            fromLabel.Text = "Маршрут";
            // 
            // routeCombo
            // 
            routeCombo.Location = new Point(12, 40);
            routeCombo.Name = "routeCombo";
            routeCombo.Size = new Size(360, 23);
            routeCombo.TabIndex = 2;
            // 
            // toLabel
            // 
            toLabel.AutoSize = true;
            toLabel.Location = new Point(12, 70);
            toLabel.Name = "toLabel";
            toLabel.Size = new Size(89, 15);
            toLabel.TabIndex = 6;
            toLabel.Text = "Представитель";
            // 
            // compReprCombo
            // 
            compReprCombo.Location = new Point(12, 90);
            compReprCombo.Name = "compReprCombo";
            compReprCombo.Size = new Size(360, 23);
            compReprCombo.TabIndex = 3;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(12, 390);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(106, 15);
            dateLabel.TabIndex = 5;
            dateLabel.Text = "Дата отправления";
            // 
            // dateToPicker
            // 
            dateToPicker.Location = new Point(12, 410);
            dateToPicker.Name = "dateToPicker";
            dateToPicker.Size = new Size(126, 23);
            dateToPicker.TabIndex = 4;
            // 
            // okButton
            // 
            okButton.Location = new Point(216, 464);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(297, 464);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 390);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 5;
            label1.Text = "Дата прибытия";
            // 
            // dateFromPicker
            // 
            dateFromPicker.Location = new Point(216, 410);
            dateFromPicker.Name = "dateFromPicker";
            dateFromPicker.Size = new Size(126, 23);
            dateFromPicker.TabIndex = 4;
            // 
            // priceUD
            // 
            priceUD.Location = new Point(12, 331);
            priceUD.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            priceUD.Name = "priceUD";
            priceUD.Size = new Size(120, 23);
            priceUD.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 313);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 8;
            label2.Text = "Размер неустойки";
            // 
            // penaltyUD
            // 
            penaltyUD.Location = new Point(216, 331);
            penaltyUD.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            penaltyUD.Name = "penaltyUD";
            penaltyUD.Size = new Size(120, 23);
            penaltyUD.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 136);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 6;
            label4.Text = "Перелёт туда";
            // 
            // toCombo
            // 
            toCombo.Location = new Point(12, 156);
            toCombo.Name = "toCombo";
            toCombo.Size = new Size(360, 23);
            toCombo.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 197);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 6;
            label5.Text = "Перелёт обратно";
            // 
            // fromCombo
            // 
            fromCombo.Location = new Point(12, 217);
            fromCombo.Name = "fromCombo";
            fromCombo.Size = new Size(360, 23);
            fromCombo.TabIndex = 3;
            // 
            // TripEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 501);
            Controls.Add(penaltyUD);
            Controls.Add(priceUD);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(dateFromPicker);
            Controls.Add(dateToPicker);
            Controls.Add(label1);
            Controls.Add(dateLabel);
            Controls.Add(fromCombo);
            Controls.Add(label5);
            Controls.Add(toCombo);
            Controls.Add(label4);
            Controls.Add(compReprCombo);
            Controls.Add(toLabel);
            Controls.Add(routeCombo);
            Controls.Add(fromLabel);
            Controls.Add(label2);
            Controls.Add(nameLabel);
            Name = "TripEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Рейс";
            ((System.ComponentModel.ISupportInitialize)priceUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)penaltyUD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private DateTimePicker dateFromPicker;
        private NumericUpDown priceUD;
        private Label label2;
        private NumericUpDown penaltyUD;
        private Label label4;
        private ComboBox toCombo;
        private Label label5;
        private ComboBox fromCombo;
    }
}