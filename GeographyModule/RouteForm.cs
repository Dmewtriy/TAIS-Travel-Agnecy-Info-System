using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class RouteForm : Form
    {
        private readonly InitRepos db;
        private List<Route> Routes = new List<Route>();
        private List<Employee> allEmployees = new List<Employee>();
        private List<Country> allCountries = new List<Country>();

        public RouteForm(InitRepos init)
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

            RoutesGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            try { allEmployees = db.employeeRep.GetAll(); } catch { allEmployees = new List<Employee>(); }
            try { allCountries = db.countryRep.GetAll(); } catch { allCountries = new List<Country>(); }
            Routes = db.routeRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            RoutesGridView.Rows.Clear();
            int i = 1;
            foreach (var v in Routes)
            {
                var idx = RoutesGridView.Rows.Add();
                var row = RoutesGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colName"].Value = v.Name;
                row.Cells["colDur"].Value = v.Duration.HasValue ? v.Duration : 0;
                row.Cells["colEmployee"].Value = v.CreatedByEmployee?.GetFullName();
                row.Cells["colCountry"].Value = v.Country?.Name ?? "";
                row.Tag = v;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new RouteEditForm(allEmployees, allCountries);
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.routeRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (RoutesGridView.SelectedRows.Count == 0) return;
            var row = RoutesGridView.SelectedRows[0];
            if (row.Tag is Route v)
            {
                using var form = new RouteEditForm(allEmployees, allCountries, v);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.routeRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (RoutesGridView.SelectedRows.Count == 0) return;
            var row = RoutesGridView.SelectedRows[0];
            if (row.Tag is Route v)
            {
                var res = MessageBox.Show($"Удалить маршрут {v.Name} ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.routeRep.Delete(v.Id);
                    LoadData();
                }
            }
        }
    }
}
