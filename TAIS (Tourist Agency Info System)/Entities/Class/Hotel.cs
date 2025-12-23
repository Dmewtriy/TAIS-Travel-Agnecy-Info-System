using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Hotel : BaseEntity
    {
        public Hotel(int id, string name, int cityId, int stars)
        {
            Id = id;
            Name = name;
            CityId = cityId;
            Stars = stars;
        }

        private int _stars;
        private string _name;
        private int _cityId;

        [Required(ErrorMessage = "Название отеля обязательно")]
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

        [Range(1, 5, ErrorMessage = "Рейтинг отеля должен быть от 1 до 5 звезд.")]
        public int Stars
        {
            get => _stars;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "Рейтинг отеля должен быть от 1 до 5 звезд.");
                _stars = value;
            }
        }
    }
}
