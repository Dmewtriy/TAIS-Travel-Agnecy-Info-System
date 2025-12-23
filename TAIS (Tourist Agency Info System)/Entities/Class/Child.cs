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
    public class Child : BaseEntity
    {
        public Child(int id, string firstName, string middleName, string lastName, DateTime birthDate, Gender gender, int clientId)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            ClientId = clientId;
        }

        private string _firstName;
        private string _middleName;
        private string _lastName;
        private int _clientId;

        [Required(ErrorMessage = "Имя ребенка обязательно")]
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

        [Required(ErrorMessage = "Фамилия ребенка обязательна")]
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
    }
}
