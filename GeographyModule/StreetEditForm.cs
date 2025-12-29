using System;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class StreetEditForm : Form
    {
        public Street? Result { get; private set; }
        private Street? existing;

        public StreetEditForm()
        {
            InitializeComponent();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            this.Text = "Добавить улицу";
        }

        public StreetEditForm(Street Street) : this()
        {
            existing = Street;
            nameTextBox.Text = Street.Name;
            this.Text = "Редактировать улицу";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название улицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                Result = existing;
            }
            else
            {
                Result = new Street(0, nameTextBox.Text.Trim());
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
