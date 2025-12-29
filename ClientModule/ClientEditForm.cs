using System;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace ClientModule
{
    public partial class ClientEditForm : Form
    {
        public Client? Result { get; private set; }
        private Client? existing;

        public ClientEditForm()
        {
            InitializeComponent();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public ClientEditForm(Client c) : this()
        {
            existing = c;
            surnameTextBox.Text = c.LastName;
            nameTextBox.Text = c.FirstName;
            patronymicTextBox.Text = c.MiddleName ?? "";
            try { birthDatePicker.Value = c.BirthDate; } catch { }
            phoneTextBox.Text = c.Phone;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(surnameTextBox.Text) || string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("¬‚Â‰ËÚÂ ‘»Œ", "Œ¯Ë·Í‡", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existing != null)
            {
                existing.LastName = surnameTextBox.Text.Trim();
                existing.FirstName = nameTextBox.Text.Trim();
                existing.MiddleName = patronymicTextBox.Text.Trim();
                existing.BirthDate = birthDatePicker.Value;
                existing.Phone = phoneTextBox.Text.Trim();
                Result = existing;
            }
            else
            {
                // try create with available constructor; adjust if needed
                Result = new Client(0, nameTextBox.Text.Trim(), patronymicTextBox.Text.Trim(), surnameTextBox.Text.Trim(), birthDatePicker.Value, TAIS__Tourist_Agency_Info_System_.Entities.Enums.Gender.M, string.Empty, string.Empty, DateTime.MinValue, string.Empty, string.Empty);
                Result.Phone = phoneTextBox.Text.Trim();
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
