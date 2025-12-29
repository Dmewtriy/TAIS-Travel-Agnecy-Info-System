using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class CountryForm : Form
    {
        private readonly InitRepos db;
        private List<Country> countries = new List<Country>();

        public CountryForm(InitRepos init)
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
            countries = db.countryRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            countriesGridView.Rows.Clear();
            int i = 1;
            foreach (var c in countries)
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
            using var form = new CountryEditForm();
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.countryRep.GetOrCreate(form.Result?.Name);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is Country c)
            {
                using var form = new CountryEditForm(c);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.countryRep.Update(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is Country c)
            {
                var res = MessageBox.Show($"Удалить страну {c.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.countryRep.Delete(c.Id);
                    LoadData();
                }
            }
        }
    }
}
