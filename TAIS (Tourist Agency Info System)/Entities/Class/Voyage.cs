using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Voyage : BaseEntity
    {
        private int _carrierId;
        private int _aircraftTypeId;

        [Range(1, int.MaxValue, ErrorMessage = "CarrierId должен быть положительным")]
        public int CarrierId
        {
            get => _carrierId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "CarrierId должен быть положительным");
                _carrierId = value;
            }
        }
        public virtual Carrier Carrier { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "AircraftTypeId должен быть положительным")]
        public int AircraftTypeId
        {
            get => _aircraftTypeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "AircraftTypeId должен быть положительным");
                _aircraftTypeId = value;
            }
        }
        public virtual AircraftType AircraftType { get; set; }
    }
}
