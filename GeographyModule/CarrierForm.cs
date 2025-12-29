using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class CarrierForm : Form
    {
        private readonly InitRepos db;
        private List<Carrier> carriers = new List<Carrier>();

        public CarrierForm(InitRepos init)
        {
            InitializeComponent();
            db = init;
            Setup();
            LoadData();
        }

        private void Setup()
        {
            addButton.Click += AddButton_Click;
            editButton.Click += EditButton_Click;
            deleteButton.Click += DeleteButton_Click;

            countriesGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            carriers = db.carrierRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            countriesGridView.Rows.Clear();
            int i = 1;
            foreach (var c in carriers)
            {
                var idx = countriesGridView.Rows.Add();
                var row = countriesGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colName"].Value = c.Name;
                row.Tag = c;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new CarrierEditForm();
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.carrierRep.GetOrCreate(form.Result?.Name);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is Carrier c)
            {
                using var form = new CarrierEditForm(c);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.carrierRep.Update(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is Carrier c)
            {
                var res = MessageBox.Show($"Удалить перевозчика {c.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.carrierRep.Delete(c.Id);
                    LoadData();
                }
            }
        }
    }
}
