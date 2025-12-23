using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class RoutePoint : BaseEntity
    {
        public RoutePoint(int id, int? sequenceNumber, int? stayDuration, string excursionProgram,
                          int routeId, int cityId, int? hotelId, int createdByEmployeeId)
        {
            Id = id;
            SequenceNumber = sequenceNumber;
            StayDuration = stayDuration;
            ExcursionProgram = excursionProgram;
            RouteId = routeId;
            CityId = cityId;
            HotelId = hotelId;
            CreatedByEmployeeId = createdByEmployeeId;
        }

        private string _excursionProgram;
        private int _routeId;
        private int _cityId;
        private int? _hotelId;
        private int _createdByEmployeeId;

        private int? _sequenceNumber;
        [Range(1, 1000, ErrorMessage = "Порядковый номер должен быть положительным")]
        public int? SequenceNumber
        {
            get => _sequenceNumber;
            set
            {
                if (value.HasValue && value < 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Порядковый номер должен быть положительным");
                _sequenceNumber = value;
            }
        }

        private int? _stayDuration;
        [Range(1, 365, ErrorMessage = "Срок пребывания должен быть от 1 до 365 дней")]
        public int? StayDuration
        {
            get => _stayDuration;
            set
            {
                if (value.HasValue && (value < 1 || value > 365))
                    throw new ArgumentOutOfRangeException(nameof(value), "Срок пребывания должен быть от 1 до 365 дней");
                _stayDuration = value;
            }
        }

        public string ExcursionProgram
        {
            get => _excursionProgram;
            set
            {
                if (!string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Программа экскурсии не должна быть пусто", nameof(value));
                _excursionProgram = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "RouteId должен быть положительным")]
        public int RouteId
        {
            get => _routeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "RouteId должен быть положительным");
                _routeId = value;
            }
        }
        public virtual Route Route { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CityId должен быть положительным")]
        public int CityId
        {
            get => _cityId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "CityId должен быть положительным");
                _cityId = value;
            }
        }
        public virtual City City { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "HotelId должен быть положительным")]
        public int? HotelId
        {
            get => _hotelId;
            set
            {
                if (value.HasValue && value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "HotelId должен быть положительным");
                _hotelId = value;
            }
        }
        public virtual Hotel Hotel { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CreatedByEmployeeId должен быть положительным")]
        public int CreatedByEmployeeId
        {
            get => _createdByEmployeeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "CreatedByEmployeeId должен быть положительным");
                _createdByEmployeeId = value;
            }
        }
        public virtual Employee CreatedByEmployee { get; set; }
    }
}
