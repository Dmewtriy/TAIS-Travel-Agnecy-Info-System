using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TripModule
{
    public partial class TripEditForm : Form
    {
        public Trip? Result { get; private set; }
        private Trip? existing;
        private List<Route> routes = new List<Route>();
        private List<Employee> employees = new List<Employee>();
        private List<Flight> flights = new List<Flight>();

        public TripEditForm(List<Route> routes, List<Employee> employees,
            List<Flight> flights)
        {
            InitializeComponent();
            this.routes = routes ?? new List<Route>();
            this.employees = employees ?? new List<Employee>();
            this.flights = flights ?? new List<Flight>();
            routeCombo.Items.Clear();
            compReprCombo.Items.Clear();
            toCombo.Items.Clear();
            fromCombo.Items.Clear();

            foreach (var c in this.routes)
            {
                routeCombo.Items.Add(c.Name);
            }
            foreach (var e in this.employees)
            {
                compReprCombo.Items.Add(e.GetFullName());
            }
            foreach (var f in this.flights)
            {
                toCombo.Items.Add(f.Id);
                fromCombo.Items.Add(f.Id);
            }
            if (routeCombo.Items.Count > 0) routeCombo.SelectedIndex = 0;
            if (compReprCombo.Items.Count > 0) compReprCombo.SelectedIndex = 0;
            if (toCombo.Items.Count > 0)
            {
                toCombo.SelectedIndex = 0;
                fromCombo.SelectedIndex = 0;
            }

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public TripEditForm(List<Route> routes, List<Employee> employees,
            List<Flight> flights, Trip v) : this(routes, employees, flights)
        {
            existing = v;
            routeCombo.SelectedItem = v.Route;
            compReprCombo.SelectedItem = v.RepresentativeEmployee;
            toCombo.SelectedItem = v.OutboundFlight.Id;
            fromCombo.SelectedItem = v.ReturnFlightId;
            priceUD.Value = (int)v.TripCost;
            penaltyUD.Value = (int)v.Penalty;
            dateToPicker.Value = v.DepartureDate;
            dateFromPicker.Value = v.ArrivalDate;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Route? selectedRoute = null;
            Employee? selectedEmp = null;
            Flight? selectedFlightTo = null;
            Flight? selectedFlightFrom = null;
            if (routeCombo.SelectedItem != null && compReprCombo.SelectedItem != null && toCombo.SelectedItem != null)
            {
                var selR = routeCombo.SelectedItem.ToString();
                selectedRoute = routes.FirstOrDefault(x => x.Name == selR);
                var selC = compReprCombo.SelectedItem.ToString();
                selectedEmp = employees.FirstOrDefault(x => x.GetFullName() == selC);
                var selT = toCombo.SelectedItem;
                selectedFlightTo = flights.FirstOrDefault(x => x.Id == (int)selT);
                var selF = fromCombo.SelectedItem;
                selectedFlightFrom = flights.FirstOrDefault(x => x.Id == (int)selF);
            }

            if (existing != null)
            {
                existing.DepartureDate = dateToPicker.Value;
                existing.ArrivalDate = dateFromPicker.Value;
                existing.TripCost = priceUD.Value;
                existing.Penalty = penaltyUD.Value;
                existing.RouteId = selectedRoute?.Id ?? 0;
                existing.Route = selectedRoute;
                existing.RepresentativeEmployee = selectedEmp;
                existing.RepresentativeEmployeeId = selectedEmp?.Id ?? 0;
                existing.OutboundFlight = selectedFlightTo;
                existing.OutboundFlightId = selectedFlightTo?.Id ?? 0;
                existing.ReturnFlight = selectedFlightFrom;
                existing.ReturnFlightId = selectedFlightFrom?.Id ?? 0;
                Result = existing;
            }
            else
            {
                Result = new Trip(0, dateToPicker.Value, dateFromPicker.Value,
                    priceUD.Value, penaltyUD.Value, selectedRoute?.Id ?? 0, selectedEmp?.Id ?? 0,
                    selectedFlightTo?.Id ?? 0, selectedFlightFrom?.Id ?? 0);
                Result.Route = selectedRoute;
                Result.RepresentativeEmployee = selectedEmp;
                Result.OutboundFlight = selectedFlightTo;
                Result.ReturnFlight = selectedFlightFrom;
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
