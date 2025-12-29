using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace ClientModule
{
    public partial class ClientForm : Form
    {
        private readonly InitRepos db;
        private List<Client> clients = new List<Client>();

        public ClientForm(InitRepos init)
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

            clientsGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            try { clients = db.clientRep.GetAll(); } catch { clients = new List<Client>(); }
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            clientsGridView.Rows.Clear();
            int i = 1;
            foreach (var c in clients)
            {
                var idx = clientsGridView.Rows.Add();
                var row = clientsGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colSurname"].Value = c.LastName;
                row.Cells["colName"].Value = c.FirstName;
                row.Cells["colPatronymic"].Value = c.MiddleName ?? "";
                row.Cells["colBirthDate"].Value = c.BirthDate.ToShortDateString();
                row.Cells["colPhone"].Value = c.Phone ?? "";
                row.Tag = c;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new ClientEditForm();
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.clientRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (clientsGridView.SelectedRows.Count == 0) return;
            var row = clientsGridView.SelectedRows[0];
            if (row.Tag is Client c)
            {
                using var form = new ClientEditForm(c);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.clientRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (clientsGridView.SelectedRows.Count == 0) return;
            var row = clientsGridView.SelectedRows[0];
            if (row.Tag is Client c)
            {
                var res = MessageBox.Show($"Удалить клиента {c.GetFullName()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.clientRep.Delete(c.Id);
                    LoadData();
                }
            }
        }
    }
}
