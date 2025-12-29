using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class RoutepointEditForm : Form
    {
        public RoutePoint? Result { get; private set; }
        private RoutePoint? existing;
        private List<Employee> allEmployees = new List<Employee>();
        private List<Route> allRoutes = new List<Route>();
        private List<City> allCities = new List<City>();
        private List<Hotel> allHotels = new List<Hotel>();

        public RoutepointEditForm(List<Employee> allEmployees, List<Route> allRoutes,
            List<City> allCities, List<Hotel> allHotels)
        {
            InitializeComponent();
            this.allEmployees = allEmployees ?? new List<Employee>();
            this.allRoutes = allRoutes ?? new List<Route>();
            this.allCities = allCities ?? new List<City>();
            this.allHotels = allHotels ?? new List<Hotel>();

            routeCombo.Items.Clear();
            foreach (var r in this.allRoutes)
                routeCombo.Items.Add(r.Name);
            if (routeCombo.Items.Count > 0) routeCombo.SelectedIndex = 0;

            hotelCombo.Items.Clear();
            foreach (var h in this.allHotels)
                hotelCombo.Items.Add(h.Name);
            if (hotelCombo.Items.Count > 0) hotelCombo.SelectedIndex = 0;

            cityCombo.Items.Clear();
            foreach (var c in this.allCities)
                cityCombo.Items.Add(c.Name);
            if (cityCombo.Items.Count > 0) cityCombo.SelectedIndex = 0;

            employeeCombo.Items.Clear();
            foreach (var c in this.allEmployees)
                employeeCombo.Items.Add(c.GetFullName());
            if (employeeCombo.Items.Count > 0) employeeCombo.SelectedIndex = 0;

            

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public RoutepointEditForm(List<Employee> allEmployees, List<Route> allRoutes,
            List<City> allCities, List<Hotel> allHotels, RoutePoint Routepoint) : this(allEmployees, allRoutes, allCities, allHotels)
        {
            existing = Routepoint;
            routeCombo.SelectedItem = Routepoint.Route.Name;
            cityCombo.SelectedItem = Routepoint.City.Name;
            employeeCombo.SelectedItem = Routepoint.CreatedByEmployee?.GetFullName();
            hotelCombo.SelectedItem = Routepoint.Hotel.Name;
            excursionText.Text = Routepoint.ExcursionProgram;
            numberUD.Value = Routepoint.SequenceNumber.HasValue ? Routepoint.SequenceNumber.Value : 0;
            durationUD.Value = Routepoint.StayDuration.HasValue ? Routepoint.StayDuration.Value : 0;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {

            Employee? selectedEmp = null;
            City? selectedCity = null;
            Route? selectedRoute = null;
            Hotel? selectedHotel = null;

            if (employeeCombo.SelectedItem != null && cityCombo.SelectedItem != null
                && routeCombo.SelectedItem != null && hotelCombo.SelectedItem != null)
            {
                var selCName = employeeCombo.SelectedItem.ToString();
                selectedEmp = allEmployees.FirstOrDefault(x => x.GetFullName() == selCName);
                var selAName = cityCombo.SelectedItem.ToString();
                selectedCity = allCities.FirstOrDefault(x => x.Name == selAName);
                var selRName = routeCombo.SelectedItem.ToString();
                selectedRoute = allRoutes.FirstOrDefault(x => x.Name == selRName);
                var selHName = hotelCombo.SelectedItem.ToString();
                selectedHotel = allHotels.FirstOrDefault(x => x.Name == selHName);
            }

            if (existing != null)
            {
                existing.RouteId = selectedRoute?.Id ?? 0;
                existing.Route = selectedRoute;
                existing.CityId = selectedCity?.Id ?? 0;
                existing.City = selectedCity;
                existing.CreatedByEmployeeId = selectedEmp?.Id ?? 0;
                existing.CreatedByEmployee = selectedEmp;
                existing.HotelId = selectedHotel?.Id ?? 0;
                existing.Hotel = selectedHotel;
                existing.ExcursionProgram = excursionText.Text.Trim();
                existing.StayDuration = (int)durationUD.Value;
                existing.SequenceNumber = (int)numberUD.Value;
                Result = existing;
            }
            else
            {
                // create new Routepoint; constructor (id, name, countryId) - keep countryId if available
                Result = new RoutePoint(0, (int)numberUD.Value, (int)durationUD.Value,
                    excursionText.Text.Trim(), selectedRoute?.Id ?? 0, selectedCity?.Id ?? 0,
                    selectedHotel?.Id ?? 0, selectedEmp?.Id ?? 0);
                Result.CreatedByEmployee = selectedEmp;
                Result.City = selectedCity;
                Result.Hotel = selectedHotel;
                Result.Route = selectedRoute;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
