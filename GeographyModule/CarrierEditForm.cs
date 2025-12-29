using System;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class CarrierEditForm : Form
    {
        public Carrier? Result { get; private set; }
        private Carrier? existing;

        public CarrierEditForm()
        {
            InitializeComponent();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            this.Text = "Добавить перевозчика";
        }

        public CarrierEditForm(Carrier carrier) : this()
        {
            existing = carrier;
            nameTextBox.Text = carrier.Name;
            this.Text = "Редактировать перевозчика";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название перевозчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                Result = existing;
            }
            else
            {
                Result = new Carrier(0, nameTextBox.Text.Trim());
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
