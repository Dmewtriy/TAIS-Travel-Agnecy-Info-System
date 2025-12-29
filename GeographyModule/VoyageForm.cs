using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class VoyageForm : Form
    {
        private readonly InitRepos db;
        private List<Voyage> voyages = new List<Voyage>();
        private List<Carrier> allCarrier = new List<Carrier>();
        private List<AircraftType> allAircraftTypes = new List<AircraftType>();

        public VoyageForm(InitRepos init)
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

            voyagesGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            try { allCarrier = db.carrierRep.GetAll(); } catch { allCarrier = new List<Carrier>(); }
            try { allAircraftTypes = db.aircraftRep.GetAll(); } catch { allAircraftTypes = new List<AircraftType>(); }
            voyages = db.voyageRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            voyagesGridView.Rows.Clear();
            int i = 1;
            foreach (var v in voyages)
            {
                var idx = voyagesGridView.Rows.Add();
                var row = voyagesGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colCarrier"].Value = v.Carrier?.Name;
                row.Cells["colAircraftType"].Value = v.AircraftType?.Name ?? "";
                row.Tag = v;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new VoyageEditForm(allAircraftTypes, allCarrier);
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.voyageRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (voyagesGridView.SelectedRows.Count == 0) return;
            var row = voyagesGridView.SelectedRows[0];
            if (row.Tag is Voyage v)
            {
                using var form = new VoyageEditForm(allAircraftTypes, allCarrier, v);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.voyageRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (voyagesGridView.SelectedRows.Count == 0) return;
            var row = voyagesGridView.SelectedRows[0];
            if (row.Tag is Voyage v)
            {
                var res = MessageBox.Show($"Удалить рейс ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.voyageRep.Delete(v.Id);
                    LoadData();
                }
            }
        }
    }
}
