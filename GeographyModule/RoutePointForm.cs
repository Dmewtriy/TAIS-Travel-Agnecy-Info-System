using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class RoutepointForm : Form
    {
        private readonly InitRepos db;
        private List<RoutePoint> Routepoints = new List<RoutePoint>();
        private List<Employee> allEmployees = new List<Employee>();
        private List<Route> allRoutes = new List<Route>();
        private List<City> allCities = new List<City>();
        private List<Hotel> allHotels = new List<Hotel>();

        public RoutepointForm(InitRepos init)
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

            RoutepointsGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            try { allEmployees = db.employeeRep.GetAll(); } catch { allEmployees = new List<Employee>(); }
            try { allRoutes = db.routeRep.GetAll(); } catch { allRoutes = new List<Route>(); }
            try { allCities = db.cityRep.GetAll(); } catch { allCities = new List<City>(); }
            try { allHotels = db.hotelRep.GetAll(); } catch { allHotels = new List<Hotel>(); }
            Routepoints = db.routePointRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            RoutepointsGridView.Rows.Clear();
            int i = 1;
            foreach (var v in Routepoints)
            {
                var idx = RoutepointsGridView.Rows.Add();
                var row = RoutepointsGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colRoute"].Value = v.Route.Name;
                row.Cells["colCity"].Value = v.City.Name;
                row.Cells["colEmployee"].Value = v.CreatedByEmployee?.GetFullName();
                row.Cells["colHotel"].Value = v.Hotel.Name;
                row.Cells["colNumber"].Value = v.SequenceNumber ?? 0;
                row.Cells["colDur"].Value = v.StayDuration.HasValue ? v.StayDuration : 0;
                row.Cells["colExcursion"].Value = v.ExcursionProgram;
                row.Tag = v;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new RoutepointEditForm(allEmployees, allRoutes, allCities, allHotels);
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.routePointRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (RoutepointsGridView.SelectedRows.Count == 0) return;
            var row = RoutepointsGridView.SelectedRows[0];
            if (row.Tag is RoutePoint v)
            {
                using var form = new RoutepointEditForm(allEmployees, allRoutes, allCities, allHotels, v);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.routePointRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (RoutepointsGridView.SelectedRows.Count == 0) return;
            var row = RoutepointsGridView.SelectedRows[0];
            if (row.Tag is RoutePoint v)
            {
                var res = MessageBox.Show($"Удалить пункт маршрута?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.routePointRep.Delete(v.Id);
                    LoadData();
                }
            }
        }
    }
}
