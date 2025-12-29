using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class StreetForm : Form
    {
        private readonly InitRepos db;
        private List<Street> Streets = new List<Street>();

        public StreetForm(InitRepos init)
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
            Streets = db.streetRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            countriesGridView.Rows.Clear();
            int i = 1;
            foreach (var c in Streets)
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
            using var form = new StreetEditForm();
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.streetRep.GetOrCreate(form.Result?.Name);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is Street c)
            {
                using var form = new StreetEditForm(c);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.streetRep.Update(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (countriesGridView.SelectedRows.Count == 0) return;
            var row = countriesGridView.SelectedRows[0];
            if (row.Tag is Street c)
            {
                var res = MessageBox.Show($"Удалить улицу {c.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.streetRep.Delete(c.Id);
                    LoadData();
                }
            }
        }
    }
}
