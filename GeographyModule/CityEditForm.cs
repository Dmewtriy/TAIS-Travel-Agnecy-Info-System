using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class CityEditForm : Form
    {
        public City? Result { get; private set; }
        private City? existing;
        private List<Country> countries = new List<Country>();

        public CityEditForm(List<Country> countries)
        {
            InitializeComponent();
            this.countries = countries ?? new List<Country>();
            countryCombo.Items.Clear();
            foreach (var c in this.countries)
                countryCombo.Items.Add(c.Name);
            if (countryCombo.Items.Count > 0) countryCombo.SelectedIndex = 0;

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public CityEditForm(List<Country> countries, City city) : this(countries)
        {
            existing = city;
            nameTextBox.Text = city.Name;
            if (city.Country != null)
                countryCombo.SelectedItem = city.Country.Name;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("¬ведите название города", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Country? selectedCountry = null;
            if (countryCombo.SelectedItem != null)
            {
                var selName = countryCombo.SelectedItem.ToString();
                selectedCountry = countries.FirstOrDefault(x => x.Name == selName);
            }

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                existing.CountryId = selectedCountry?.Id ?? 0;
                existing.Country = selectedCountry;
                Result = existing;
            }
            else
            {
                // create new city; constructor (id, name, countryId) - keep countryId if available
                Result = new City(0, nameTextBox.Text.Trim(), selectedCountry?.Id ?? 0);
                Result.Country = selectedCountry;
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
