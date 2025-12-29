using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class RouteEditForm : Form
    {
        public Route? Result { get; private set; }
        private Route? existing;
        private List<Employee> allEmployees = new List<Employee>();
        private List<Country> allCountries = new List<Country>();

        public RouteEditForm(List<Employee> allEmployees, List<Country> allCountries)
        {
            InitializeComponent();
            this.allEmployees = allEmployees ?? new List<Employee>();
            this.allCountries = allCountries ?? new List<Country>();
            countryCombo.Items.Clear();
            employeeCombo.Items.Clear();
            foreach (var c in this.allEmployees)
                employeeCombo.Items.Add(c.GetFullName());
            if (employeeCombo.Items.Count > 0) employeeCombo.SelectedIndex = 0;

            foreach (var c in this.allCountries)
                countryCombo.Items.Add(c.Name);
            if (countryCombo.Items.Count > 0) countryCombo.SelectedIndex = 0;

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public RouteEditForm(List<Employee> allEmployees, List<Country> allCountries, Route Route) : this(allEmployees, allCountries)
        {
            existing = Route;
            nameTextBox.Text = Route.Name;
            numericUpDown1.Value = Route.Duration.HasValue ? Route.Duration.Value : 0;
            if (Route.CreatedByEmployee != null && Route.Country != null)
            {
                employeeCombo.SelectedItem = Route.CreatedByEmployee.GetFullName();
                countryCombo.SelectedItem = Route.Country.Name;
            }

        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("¬ведите название города", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee? selectedEmp = null;
            Country? selectedCountry = null;
            if (employeeCombo.SelectedItem != null && countryCombo.SelectedItem != null)
            {
                var selCName = employeeCombo.SelectedItem.ToString();
                selectedEmp = allEmployees.FirstOrDefault(x => x.GetFullName() == selCName);
                var selAName = countryCombo.SelectedItem.ToString();
                selectedCountry = allCountries.FirstOrDefault(x => x.Name == selAName);
            }

            if (existing != null)
            {
                existing.Name = nameTextBox.Text.Trim();
                existing.Duration = (int)numericUpDown1.Value;
                existing.CreatedByEmployeeId = selectedEmp?.Id ?? 0;
                existing.CreatedByEmployee = selectedEmp;
                existing.CountryId = selectedCountry?.Id ?? 0;
                existing.Country = selectedCountry;
                Result = existing;
            }
            else
            {
                // create new Route; constructor (id, name, countryId) - keep countryId if available
                Result = new Route(0, nameTextBox.Text.Trim(), (int)numericUpDown1.Value, selectedCountry?.Id ?? 0, selectedEmp?.Id ?? 0);
                Result.CreatedByEmployee = selectedEmp;
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
