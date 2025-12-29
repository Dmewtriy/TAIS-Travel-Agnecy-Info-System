using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class OrderForm : Form
    {
        private readonly InitRepos db;
        private List<Order> Orders = new List<Order>();
        private List<Client> allClients = new List<Client>();
        private List<Trip> allTrips = new List<Trip>();

        public OrderForm(InitRepos init)
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

            OrdersGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            try { allClients = db.clientRep.GetAll(); } catch { allClients = new List<Client>(); }
            try { allTrips = db.tripRep.GetAll(); } catch { allTrips = new List<Trip>(); }
            Orders = db.orderRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            OrdersGridView.Rows.Clear();
            int i = 1;
            foreach (var v in Orders)
            {
                var idx = OrdersGridView.Rows.Add();
                var row = OrdersGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colClient"].Value = v.Client.GetFullName();
                row.Cells["colTrip"].Value = v.Trip.Route.Name;
                row.Cells["colDate"].Value = v.OrderDate.ToShortDateString();
                row.Cells["colTime"].Value = v.OrderTime.ToString("hh\\:mm\\:ss");
                row.Tag = v;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new OrderEditForm(allClients, allTrips);
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.orderRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (OrdersGridView.SelectedRows.Count == 0) return;
            var row = OrdersGridView.SelectedRows[0];
            if (row.Tag is Order v)
            {
                using var form = new OrderEditForm(allClients, allTrips, v);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.orderRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (OrdersGridView.SelectedRows.Count == 0) return;
            var row = OrdersGridView.SelectedRows[0];
            if (row.Tag is Order v)
            {
                var res = MessageBox.Show($"Удалить маршрут {v.Trip.Route.Name} ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.orderRep.Delete(v.Id);
                    LoadData();
                }
            }
        }
    }
}
