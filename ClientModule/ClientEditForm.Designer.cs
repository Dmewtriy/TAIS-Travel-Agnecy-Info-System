namespace ClientModule
{
    partial class ClientEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label patronymicLabel;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientEditForm));
            surnameLabel = new Label();
            surnameTextBox = new TextBox();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            patronymicLabel = new Label();
            patronymicTextBox = new TextBox();
            birthDateLabel = new Label();
            birthDatePicker = new DateTimePicker();
            phoneLabel = new Label();
            phoneTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(12, 15);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(58, 15);
            surnameLabel.TabIndex = 10;
            surnameLabel.Text = "Фамилия";
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(12, 35);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(360, 23);
            surnameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 65);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(31, 15);
            nameLabel.TabIndex = 9;
            nameLabel.Text = "Имя";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 85);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(360, 23);
            nameTextBox.TabIndex = 2;
            // 
            // patronymicLabel
            // 
            patronymicLabel.AutoSize = true;
            patronymicLabel.Location = new Point(12, 115);
            patronymicLabel.Name = "patronymicLabel";
            patronymicLabel.Size = new Size(58, 15);
            patronymicLabel.TabIndex = 8;
            patronymicLabel.Text = "Отчество";
            // 
            // patronymicTextBox
            // 
            patronymicTextBox.Location = new Point(12, 135);
            patronymicTextBox.Name = "patronymicTextBox";
            patronymicTextBox.Size = new Size(360, 23);
            patronymicTextBox.TabIndex = 3;
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new Point(12, 165);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new Size(90, 15);
            birthDateLabel.TabIndex = 7;
            birthDateLabel.Text = "Дата рождения";
            // 
            // birthDatePicker
            // 
            birthDatePicker.Location = new Point(12, 185);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(200, 23);
            birthDatePicker.TabIndex = 4;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(12, 215);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(55, 15);
            phoneLabel.TabIndex = 6;
            phoneLabel.Text = "Телефон";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(12, 235);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(360, 23);
            phoneTextBox.TabIndex = 5;
            // 
            // okButton
            // 
            okButton.Location = new Point(216, 270);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(297, 270);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // ClientEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 311);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(phoneTextBox);
            Controls.Add(phoneLabel);
            Controls.Add(birthDatePicker);
            Controls.Add(birthDateLabel);
            Controls.Add(patronymicTextBox);
            Controls.Add(patronymicLabel);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(surnameTextBox);
            Controls.Add(surnameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientEditForm";
            Text = "Клиент";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}