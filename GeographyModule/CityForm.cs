using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class CityForm : Form
    {
        private readonly InitRepos db;
        private List<City> cities = new List<City>();
        private List<Country> allCountries = new List<Country>();

        public CityForm(InitRepos init)
        {
            InitializeComponent();
            db = init;
            Setup();
            LoadData();
        }

        private void Setup()
        {
            // basic layout created in designer; attach handlers
            addButton.Click += AddButton_Click;
            editButton.Click += EditButton_Click;
            deleteButton.Click += DeleteButton_Click;

            citiesGridView.AutoGenerateColumns = false;
            // configure columns in designer or here
        }

        private void LoadData()
        {
            // Загрузка всех стран для передачи в форму редактирования
            try { allCountries = db.countryRep.GetAll(); } catch { allCountries = new List<Country>(); }

            cities = db.cityRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            citiesGridView.Rows.Clear();
            int i = 1;
            foreach (var c in cities)
            {
                var idx = citiesGridView.Rows.Add();
                var row = citiesGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colName"].Value = c.Name;
                row.Cells["colCountry"].Value = c.Country?.Name ?? "";
                row.Tag = c;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new CityEditForm(allCountries);
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.cityRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (citiesGridView.SelectedRows.Count == 0) return;
            var row = citiesGridView.SelectedRows[0];
            if (row.Tag is City c)
            {
                using var form = new CityEditForm(allCountries, c);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.cityRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (citiesGridView.SelectedRows.Count == 0) return;
            var row = citiesGridView.SelectedRows[0];
            if (row.Tag is City c)
            {
                var res = MessageBox.Show($"Удалить город {c.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.cityRep.Delete(c.Id);
                    LoadData();
                }
            }
        }
    }
}
