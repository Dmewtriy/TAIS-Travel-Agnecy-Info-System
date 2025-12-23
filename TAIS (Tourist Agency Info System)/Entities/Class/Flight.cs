using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Flight : BaseEntity
    {
        public Flight(int id, DateTime departureDate, TimeSpan departureTime, int voyageId)
        {
            Id = id;
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            VoyageId = voyageId;
        }

        private int _voyageId;

        [Required(ErrorMessage = "Дата вылета обязательна")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Время вылета обязательно")]
        public TimeSpan DepartureTime { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "VoyageId должен быть положительным")]
        public int VoyageId
        {
            get => _voyageId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "VoyageId должен быть положительным");
                _voyageId = value;
            }
        }
        public virtual Voyage Voyage { get; set; }
    }
}

