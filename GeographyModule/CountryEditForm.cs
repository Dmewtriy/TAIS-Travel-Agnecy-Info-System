using System;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class CountryEditForm : Form
    {
        public Country? Result { get; private set; }
        private Country? existing;

        public CountryEditForm()
        {
            InitializeComponent();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            this.Text = "Добавить страну";
        }

        public CountryEditForm(Country country) : this()
        {
            existing = country;
            nameTextBox.Text = country.Name;
            this.Text = "Редактировать страну";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название страны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                Result = existing;
            }
            else
            {
                Result = new Country(0, nameTextBox.Text.Trim());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
