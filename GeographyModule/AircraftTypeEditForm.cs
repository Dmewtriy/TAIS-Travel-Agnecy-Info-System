using System;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class AircraftTypeEditForm : Form
    {
        public AircraftType? Result { get; private set; }
        private AircraftType? existing;

        public AircraftTypeEditForm()
        {
            InitializeComponent();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            this.Text = "Добавить тип самолёта";
        }

        public AircraftTypeEditForm(AircraftType AircraftType) : this()
        {
            existing = AircraftType;
            nameTextBox.Text = AircraftType.Name;
            this.Text = "Редактировать тип самолёта";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название типа самолёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                Result = existing;
            }
            else
            {
                Result = new AircraftType(0, nameTextBox.Text.Trim());
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
