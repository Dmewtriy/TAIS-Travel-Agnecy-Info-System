using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class AircraftTypeForm : Form
    {
        private readonly InitRepos db;
        private List<AircraftType> AircraftTypes = new List<AircraftType>();

        public AircraftTypeForm(InitRepos init)
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
            AircraftTypes = db.aircraftRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            countriesGridView.Rows.Clear();
            int i = 1;
            foreach (var c in AircraftTypes)
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
            using var form = new AircraftTypeEditForm();
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.aircraftRep.GetOrCreate(form.Result?.Name);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is AircraftType c)
            {
                using var form = new AircraftTypeEditForm(c);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.aircraftRep.Update(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is AircraftType c)
            {
                var res = MessageBox.Show($"Удалить тип самолёта {c.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.aircraftRep.Delete(c.Id);
                    LoadData();
                }
            }
        }
    }
}
