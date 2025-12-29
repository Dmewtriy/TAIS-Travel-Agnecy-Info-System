using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class HotelForm : Form
    {
        private readonly InitRepos db;
        private List<Hotel> hotels = new List<Hotel>();

        public HotelForm(InitRepos init)
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

            hotelsGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            hotels = db.hotelRep.GetAll();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            hotelsGridView.Rows.Clear();
            int i = 1;
            foreach (var h in hotels)
            {
                var idx = hotelsGridView.Rows.Add();
                var row = hotelsGridView.Rows[idx];
                row.Cells["colNo"].Value = i;
                row.Cells["colName"].Value = h.Name;
                row.Cells["colCity"].Value = h.City?.Name ?? "";
                row.Cells["colStars"].Value = h.Stars;
                row.Tag = h;
                i++;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using var form = new HotelEditForm(db.cityRep.GetAll());
            if (form.ShowDialog() == DialogResult.OK && form.Result != null)
            {
                db.hotelRep.Save(form.Result);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (hotelsGridView.SelectedRows.Count == 0) return;
            var row = hotelsGridView.SelectedRows[0];
            if (row.Tag is Hotel h)
            {
                using var form = new HotelEditForm(db.cityRep.GetAll(), h);
                if (form.ShowDialog() == DialogResult.OK && form.Result != null)
                {
                    db.hotelRep.Save(form.Result);
                    LoadData();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (hotelsGridView.SelectedRows.Count == 0) return;
            var row = hotelsGridView.SelectedRows[0];
            if (row.Tag is Hotel h)
            {
                var res = MessageBox.Show($"Удалить гостиницу {h.Name}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    db.hotelRep.Delete(h.Id);
                    LoadData();
                }
            }
        }
    }
}
