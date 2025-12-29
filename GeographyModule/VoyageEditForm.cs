using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace GeographyModule
{
    public partial class VoyageEditForm : Form
    {
        public Voyage? Result { get; private set; }
        private Voyage? existing;
        private List<AircraftType> aircraftTypes = new List<AircraftType>();
        private List<Carrier> carriers = new List<Carrier>();

        public VoyageEditForm(List<AircraftType> aircraftTypes, List<Carrier> carriers)
        {
            InitializeComponent();
            this.aircraftTypes = aircraftTypes ?? new List<AircraftType>();
            this.carriers = carriers ?? new List<Carrier>();
            aircraftCombo.Items.Clear();
            carrierCombo.Items.Clear();
            foreach (var c in this.carriers)
                carrierCombo.Items.Add(c.Name);
            if (carrierCombo.Items.Count > 0) carrierCombo.SelectedIndex = 0;

            foreach (var c in this.aircraftTypes)
                aircraftCombo.Items.Add(c.Name);
            if (aircraftCombo.Items.Count > 0) aircraftCombo.SelectedIndex = 0;

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        public VoyageEditForm(List<AircraftType> aircraftTypes, List<Carrier> carriers, Voyage Voyage) : this(aircraftTypes, carriers)
        {
            existing = Voyage;
            if (Voyage.AircraftType != null && Voyage.Carrier != null)
            {
                carrierCombo.SelectedItem = Voyage.Carrier.Name;
                aircraftCombo.SelectedItem = Voyage.AircraftType.Name;
            }

        }

        private void OkButton_Click(object? sender, EventArgs e)
        {

            Carrier? selectedCarrier = null;
            AircraftType? selaircraftType = null;
            if (carrierCombo.SelectedItem != null && aircraftCombo.SelectedItem != null)
            {
                var selCName = carrierCombo.SelectedItem.ToString();
                selectedCarrier = carriers.FirstOrDefault(x => x.Name == selCName);
                var selAName = aircraftCombo.SelectedItem.ToString();
                selaircraftType = aircraftTypes.FirstOrDefault(x => x.Name == selAName);
            }

            if (existing != null)
            {
                existing.CarrierId = selectedCarrier?.Id ?? 0;
                existing.AircraftTypeId = selaircraftType?.Id ?? 0;
                Result = existing;
            }
            else
            {
                // create new Voyage; constructor (id, name, countryId) - keep countryId if available
                Result = new Voyage(0, selectedCarrier?.Id ?? 0, selaircraftType?.Id ?? 0);
                Result.Carrier = selectedCarrier;
                Result.AircraftType = selaircraftType;
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
