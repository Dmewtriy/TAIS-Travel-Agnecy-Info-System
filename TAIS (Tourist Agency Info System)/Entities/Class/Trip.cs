using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Trip : BaseEntity
    {
        public Trip(int id, DateTime departureDate, DateTime arrivalDate, decimal? tripCost, decimal? penalty,
                    int routeId, int representativeEmployeeId, int outboundFlightId, int? returnFlightId)
        {
            Id = id;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            TripCost = tripCost;
            Penalty = penalty;
            RouteId = routeId;
            RepresentativeEmployeeId = representativeEmployeeId;
            OutboundFlightId = outboundFlightId;
            ReturnFlightId = returnFlightId;
        }

        private decimal? _tripCost;
        private decimal? _penalty;
        private int _routeId;
        private int _representativeEmployeeId;
        private int _outboundFlightId;
        private int? _returnFlightId;

        [Required(ErrorMessage = "Дата убытия обязательна")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Дата прибытия обязательна")]
        public DateTime ArrivalDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Стоимость путевки не может быть отрицательной")]
        public decimal? TripCost
        {
            get => _tripCost;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("Стоимость путевки не может быть отрицательной", nameof(value));
                _tripCost = value;
            }
        }

        [Range(0, double.MaxValue, ErrorMessage = "Размер неустойки не может быть отрицательным")]
        public decimal? Penalty
        {
            get => _penalty;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("Размер неустойки не может быть отрицательным", nameof(value));
                _penalty = value;
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

        [Range(1, int.MaxValue, ErrorMessage = "RepresentativeEmployeeId должен быть положительным")]
        public int RepresentativeEmployeeId
        {
            get => _representativeEmployeeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "RepresentativeEmployeeId должен быть положительным");
                _representativeEmployeeId = value;
            }
        }
        public virtual Employee RepresentativeEmployee { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "OutboundFlightId должен быть положительным")]
        public int OutboundFlightId
        {
            get => _outboundFlightId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "OutboundFlightId должен быть положительным");
                _outboundFlightId = value;
            }
        }
        public virtual Flight OutboundFlight { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "ReturnFlightId должен быть положительным")]
        public int? ReturnFlightId
        {
            get => _returnFlightId;
            set
            {
                if (value.HasValue && value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "ReturnFlightId должен быть положительным");
                _returnFlightId = value;
            }
        }
        public virtual Flight ReturnFlight { get; set; }
    }
}
