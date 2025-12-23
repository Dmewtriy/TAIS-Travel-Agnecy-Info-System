using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Employee : BaseEntity
    {
        public Employee(int id, string firstName, string middleName, string lastName, DateTime birthDate, Gender gender,
                        decimal? workExperience, int streetId)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            WorkExperience = workExperience;
            StreetId = streetId;
        }

        private string _firstName;
        private string _middleName;
        private string _lastName;
        private decimal? _experience;
        private int _streetId;

        [Required(ErrorMessage = "Имя сотрудника обязательно")]
        [MinLength(1, ErrorMessage = "Имя не должно быть пусто")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не должно быть пусто", nameof(value));
                _firstName = value;
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set => _middleName = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }

        [Required(ErrorMessage = "Фамилия сотрудника обязательна")]
        [MinLength(1, ErrorMessage = "Фамилия не должна быть пусто")]
        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не должна быть пусто", nameof(value));
                _lastName = value;
            }
        }

        [Required(ErrorMessage = "Дата рождения обязательна")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Пол обязателен")]
        public Gender Gender { get; set; }

        [Range(1, 70, ErrorMessage = "Трудовой стаж должен быть от 1 до 70 лет")]
        public decimal? WorkExperience
        {
            get => _experience;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("Трудовой стаж должен быть от 1 до 70 лет", nameof(value));
                _experience = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "StreetId должен быть положительным")]
        public int StreetId
        {
            get => _streetId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "StreetId должен быть положительным");
                _streetId = value;
            }
        }
        public virtual Street Street { get; set; }
    }
}
