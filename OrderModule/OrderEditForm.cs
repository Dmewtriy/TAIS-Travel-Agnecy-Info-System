using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class OrderEditForm : Form
    {
        public Order? Result { get; private set; }
        private Order? existing;
        private List<Client> allClients = new List<Client>();
        private List<Trip> allTrips = new List<Trip>();

        public OrderEditForm(List<Client> allClients, List<Trip> allTrips)
        {
            InitializeComponent();
            this.allClients = allClients ?? new List<Client>();
            this.allTrips = allTrips ?? new List<Trip>();
            clientCombo.Items.Clear();
            tripCombo.Items.Clear();
            foreach (var c in this.allClients)
                clientCombo.Items.Add(c.GetFullName());
            if (clientCombo.Items.Count > 0) clientCombo.SelectedIndex = 0;

            foreach (var c in this.allTrips)
                tripCombo.Items.Add(c.Route.Name);
            if (tripCombo.Items.Count > 0) tripCombo.SelectedIndex = 0;

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public OrderEditForm(List<Client> allClients, List<Trip> allTrips, Order Order) : this(allClients, allTrips)
        {
            existing = Order;
            clientCombo.SelectedItem = Order.Client.GetFullName();
            tripCombo.SelectedItem = Order.Trip.Route.Name;
            if (Order.Client != null && Order.Trip.Route != null)
            {
                clientCombo.SelectedItem = Order.Client.GetFullName();
                tripCombo.SelectedItem = Order.Trip.Route.Name;
            }

        }

        private void OkButton_Click(object? sender, EventArgs e)
        {

            Client? selectedClient = null;
            Trip? selectedTrip = null;
            if (tripCombo.SelectedItem != null && clientCombo.SelectedItem != null)
            {
                var selCName = tripCombo.SelectedItem.ToString();
                selectedTrip = allTrips.FirstOrDefault(x => x.Route.Name == selCName);
                var selAName = clientCombo.SelectedItem.ToString();
                selectedClient = allClients.FirstOrDefault(x => x.GetFullName() == selAName);
            }

            if (existing != null)
            {
                existing.Client = selectedClient;
                existing.Trip = selectedTrip;
                existing.OrderDate = datePick.Value;
                existing.OrderTime = timePick.Value.TimeOfDay;
                existing.ClientId = selectedClient?.Id ?? 0;
                existing.TripId = selectedTrip?.Id ?? 0;
                Result = existing;
            }
            else
            {
                // create new Order; constructor (id, name, countryId) - keep countryId if available
                Result = new Order(0, datePick.Value, timePick.Value.TimeOfDay, 
                    selectedClient?.Id ?? 0, selectedTrip?.Id ?? 0);
                Result.Client = selectedClient;
                Result.Trip = selectedTrip;
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
