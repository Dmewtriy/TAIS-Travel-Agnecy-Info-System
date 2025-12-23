using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Ticket : BaseEntity
    {
        public Ticket(int id, string ticketClass, string seatNumber, decimal? price, int clientId, int flightId)
        {
            Id = id;
            TicketClass = ticketClass;
            SeatNumber = seatNumber;
            Price = price;
            ClientId = clientId;
            FlightId = flightId;
        }

        private string _ticketClass;
        private string _seatNumber;
        private decimal? _price;
        private int _clientId;
        private int _flightId;

        [Required(ErrorMessage = "Класс билета обязателен")]
        [MinLength(1, ErrorMessage = "Класс билета не должен быть пусто")]
        public string TicketClass
        {
            get => _ticketClass;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Класс билета не должен быть пусто", nameof(value));
                _ticketClass = value;
            }
        }

        [Required(ErrorMessage = "Номер места обязателен")]
        [MinLength(1, ErrorMessage = "Номер места не должен быть пусто")]
        public string SeatNumber
        {
            get => _seatNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер места не должен быть пусто", nameof(value));
                _seatNumber = value;
            }
        }

        [Range(0, double.MaxValue, ErrorMessage = "Стоимость билета не может быть отрицательной")]
        public decimal? Price
        {
            get => _price;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("Стоимость билета не может быть отрицательной", nameof(value));
                _price = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "ClientId должен быть положительным")]
        public int ClientId
        {
            get => _clientId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "ClientId должен быть положительным");
                _clientId = value;
            }
        }
        public virtual Client Client { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "FlightId должен быть положительным")]
        public int FlightId
        {
            get => _flightId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "FlightId должен быть положительным");
                _flightId = value;
            }
        }
        public virtual Flight Flight { get; set; }
    }
}
