using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TripModule
{
    public partial class TripForm : Form
    {
        private readonly InitRepos db;
        private List<Trip> Trips = new List<Trip>();
        private List<Route> allRoutes = new List<Route>();
        private List<Employee> employees = new List<Employee>();
        private List<Flight> allFlights = new List<Flight>();

        public TripForm(InitRepos init)
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

            TripsGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            Trips = db.tripRep.GetAll();
            allRoutes = db.routeRep.GetAll();
            employees = db.employeeRep.GetAll();
            allFlights = db.flightRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            TripsGridView.Rows.Clear();
            int i = 1;
            foreach (var v in Trips)
            {
                var idx = TripsGridView.Rows.Add();
                var row = TripsGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colName"].Value = v.Route.Name;
                row.Cells["colCompRepr"].Value = v.RepresentativeEmployee.GetFullName();
                row.Cells["colFrom"].Value = v.OutboundFlight.Id;
                row.Cells["colTo"].Value = v.ReturnFlightId;
                row.Cells["colPrice"].Value = v.TripCost;
                row.Cells["colPenalty"].Value = v.Penalty;
                row.Cells["colDateFrom"].Value = v.DepartureDate.ToString("dd.MM.yyyy");
                row.Cells["colDateTo"].Value = v.ArrivalDate.ToString("dd.MM.yyyy");
                row.Tag = v;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new TripEditForm(allRoutes, employees, allFlights);
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.tripRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (TripsGridView.SelectedRows.Count == 0) return;
            var row = TripsGridView.SelectedRows[0];
            if (row.Tag is Trip v)
            {
                using var form = new TripEditForm(allRoutes, employees, allFlights, v);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.tripRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TripsGridView.SelectedRows.Count == 0) return;
            var row = TripsGridView.SelectedRows[0];
            if (row.Tag is Trip v)
            {
                var res = MessageBox.Show($"Удалить рейс {v.Route.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.tripRep.Delete(v.Id);
                    LoadData();
                }
            }
        }
    }
}
