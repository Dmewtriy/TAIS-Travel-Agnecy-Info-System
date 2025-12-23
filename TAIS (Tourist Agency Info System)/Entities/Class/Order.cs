using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Order : BaseEntity
    {
        public Order(int id, DateTime orderDate, TimeSpan orderTime, int clientId, int tripId)
        {
            Id = id;
            OrderDate = orderDate;
            OrderTime = orderTime;
            ClientId = clientId;
            TripId = tripId;
        }

        private int _clientId;
        private int _tripId;

        [Required(ErrorMessage = "Дата заказа обязательна")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Время заказа обязательно")]
        public TimeSpan OrderTime { get; set; }

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

        [Range(1, int.MaxValue, ErrorMessage = "TripId должен быть положительным")]
        public int TripId
        {
            get => _tripId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "TripId должен быть положительным");
                _tripId = value;
            }
        }
        public virtual Trip Trip { get; set; }
    }
}
