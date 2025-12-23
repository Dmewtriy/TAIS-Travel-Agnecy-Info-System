using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Route : BaseEntity
    {
        public Route(int id, string name, int? duration, int countryId, int createdByEmployeeId)
        {
            Id = id;
            Name = name;
            Duration = duration;
            CountryId = countryId;
            CreatedByEmployeeId = createdByEmployeeId;
        }

        private string _name;
        private int _countryId;
        private int _createdByEmployeeId;

        [Required(ErrorMessage = "Название маршрута обязательно")]
        [MinLength(1, ErrorMessage = "Название не должно быть пусто")]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не должно быть пусто", nameof(value));
                _name = value;
            }
        }

        private int? _duration;
        [Range(1, 365, ErrorMessage = "Срок маршрута должен быть от 1 до 365 дней")]
        public int? Duration
        {
            get => _duration;
            set
            {
                if (value.HasValue && (value < 1 || value > 365))
                    throw new ArgumentOutOfRangeException(nameof(value), "Срок маршрута должен быть от 1 до 365 дней");
                _duration = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "CountryId должен быть положительным")]
        public int CountryId
        {
            get => _countryId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "CountryId должен быть положительным");
                _countryId = value;
            }
        }
        public virtual Country Country { get; set; }

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
