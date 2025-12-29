using System;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class PositionEditForm : Form
    {
        public Position? Result { get; private set; }
        private Position? existing;

        public PositionEditForm()
        {
            InitializeComponent();

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public PositionEditForm(Position p) : this()
        {
            existing = p;
            titleTextBox.Text = p.Title;
            descriptionTextBox.Text = p.OkpdtrCode;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("¬ведите название должности", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existing != null)
            {
                existing.Title = titleTextBox.Text.Trim();
                existing.OkpdtrCode = descriptionTextBox.Text.Trim();
                Result = existing;
            }
            else
            {
                Result = new Position(0, titleTextBox.Text.Trim(), descriptionTextBox.Text.Trim());
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
