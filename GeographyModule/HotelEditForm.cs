using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class HotelEditForm : Form
    {
        public Hotel? Result { get; private set; }
        private Hotel? existing;
        private List<City> cities = new List<City>();

        public HotelEditForm(List<City> cities)
        {
            InitializeComponent();
            this.cities = cities ?? new List<City>();
            cityCombo.Items.Clear();
            foreach (var c in this.cities)
                cityCombo.Items.Add(c.Name);
            if (cityCombo.Items.Count > 0) cityCombo.SelectedIndex = 0;

            // заполнить список звезд 1..5
            starsCombo.Items.Clear();
            for (int s = 1; s <= 5; s++) starsCombo.Items.Add(s.ToString());
            starsCombo.SelectedIndex = 0;

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public HotelEditForm(List<City> cities, Hotel hotel) : this(cities)
        {
            existing = hotel;
            nameTextBox.Text = hotel.Name;
            if (hotel.City != null)
                cityCombo.SelectedItem = hotel.City.Name;
            // установить звезды, если есть свойство
            try
            {
                var t = hotel.GetType();
                var prop = t.GetProperty("Stars") ?? t.GetProperty("Rating");
                if (prop != null)
                {
                    var val = prop.GetValue(hotel);
                    if (val != null && int.TryParse(val.ToString(), out int st) && st >= 1 && st <= 5)
                    {
                        starsCombo.SelectedItem = st.ToString();
                    }
                }
            }
            catch { }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("¬ведите название гостиницы", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            City? selectedCity = null;
            if (cityCombo.SelectedItem != null)
            {
                var sel = cityCombo.SelectedItem.ToString();
                selectedCity = cities.FirstOrDefault(x => x.Name == sel);
            }

            int stars = 0;
            if (starsCombo.SelectedItem != null)
                int.TryParse(starsCombo.SelectedItem.ToString(), out stars);

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                existing.City = selectedCity;
                // попытка установить свойство Stars
                try
                {
                    var prop = existing.GetType().GetProperty("Stars");
                    if (prop != null && prop.CanWrite)
                    {
                        prop.SetValue(existing, stars);
                    }
                }
                catch { }
                Result = existing;
            }
            else
            {
                Result = new Hotel(0, nameTextBox.Text.Trim(), selectedCity?.Id ?? 0, 3);
                Result.City = selectedCity;
                try
                {
                    var prop = Result.GetType().GetProperty("Stars");
                    if (prop != null && prop.CanWrite)
                        prop.SetValue(Result, stars);
                }
                catch { }
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
