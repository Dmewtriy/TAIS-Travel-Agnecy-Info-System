namespace GeographyModule
{
    partial class RoutepointEditForm
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
            cityCombo = new System.Windows.Forms.ComboBox();
            nameLabel = new System.Windows.Forms.Label();
            numberUD = new System.Windows.Forms.NumericUpDown();
            durationText = new System.Windows.Forms.Label();
            routeCombo = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            hotelCombo = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            durationUD = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            excursionText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)numberUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)durationUD).BeginInit();
            SuspendLayout();
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(12, 131);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(61, 15);
            countryLabel.TabIndex = 3;
            countryLabel.Text = "Добавлен";
            // 
            // employeeCombo
            // 
            employeeCombo.Location = new System.Drawing.Point(12, 149);
            employeeCombo.Name = "employeeCombo";
            employeeCombo.Size = new System.Drawing.Size(360, 23);
            employeeCombo.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(215, 520);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(297, 520);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 3;
            label1.Text = "Город";
            // 
            // cityCombo
            // 
            cityCombo.Location = new System.Drawing.Point(12, 93);
            cityCombo.Name = "cityCombo";
            cityCombo.Size = new System.Drawing.Size(360, 23);
            cityCombo.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(60, 15);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Маршрут";
            // 
            // numberUD
            // 
            numberUD.Location = new System.Drawing.Point(14, 273);
            numberUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberUD.Name = "numberUD";
            numberUD.Size = new System.Drawing.Size(120, 23);
            numberUD.TabIndex = 6;
            numberUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // durationText
            // 
            durationText.AutoSize = true;
            durationText.BackColor = System.Drawing.SystemColors.Control;
            durationText.Location = new System.Drawing.Point(13, 255);
            durationText.Name = "durationText";
            durationText.Size = new System.Drawing.Size(116, 15);
            durationText.TabIndex = 5;
            durationText.Text = "Порядковый номер";
            // 
            // routeCombo
            // 
            routeCombo.Location = new System.Drawing.Point(12, 40);
            routeCombo.Name = "routeCombo";
            routeCombo.Size = new System.Drawing.Size(360, 23);
            routeCombo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 187);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 3;
            label2.Text = "Гостиница";
            // 
            // hotelCombo
            // 
            hotelCombo.Location = new System.Drawing.Point(13, 205);
            hotelCombo.Name = "hotelCombo";
            hotelCombo.Size = new System.Drawing.Size(360, 23);
            hotelCombo.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.SystemColors.Control;
            label3.Location = new System.Drawing.Point(246, 255);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 15);
            label3.TabIndex = 5;
            label3.Text = "Срок пребывания";
            // 
            // durationUD
            // 
            durationUD.Location = new System.Drawing.Point(247, 273);
            durationUD.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            durationUD.Name = "durationUD";
            durationUD.Size = new System.Drawing.Size(120, 23);
            durationUD.TabIndex = 6;
            durationUD.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.SystemColors.Control;
            label4.Location = new System.Drawing.Point(12, 318);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(157, 15);
            label4.TabIndex = 5;
            label4.Text = "Экскурсионная программа";
            // 
            // excursionText
            // 
            excursionText.Location = new System.Drawing.Point(14, 346);
            excursionText.Multiline = true;
            excursionText.Name = "excursionText";
            excursionText.Size = new System.Drawing.Size(359, 168);
            excursionText.TabIndex = 7;
            // 
            // RoutepointEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 557);
            Controls.Add(excursionText);
            Controls.Add(durationUD);
            Controls.Add(numberUD);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(durationText);
            Controls.Add(nameLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(cityCombo);
            Controls.Add(routeCombo);
            Controls.Add(hotelCombo);
            Controls.Add(employeeCombo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(countryLabel);
            Name = "RoutepointEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Маршрут";
            ((System.ComponentModel.ISupportInitialize)numberUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)durationUD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cityCombo;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown numberUD;
        private System.Windows.Forms.Label durationText;
        private System.Windows.Forms.ComboBox routeCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hotelCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown durationUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox excursionText;
    }
}