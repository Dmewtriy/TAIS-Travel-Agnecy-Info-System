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
    public class Client : BaseEntity
    {
        public Client(int id, string firstName, string middleName, string lastName, DateTime birthDate, Gender gender,
                      string passportSeries, string passportNumber, DateTime passportIssueDate, string passportIssuedBy, string phone)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            PassportIssueDate = passportIssueDate;
            PassportIssuedBy = passportIssuedBy;
            Phone = phone;
        }

        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _passportSeries;
        private string _passportNumber;
        private string _passportIssuedBy;

        [Required(ErrorMessage = "Имя клиента обязательно")]
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

        [Required(ErrorMessage = "Фамилия клиента обязательна")]
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

        [Required(ErrorMessage = "Серия паспорта обязательна")]
        [StringLength(4)]
        public string PassportSeries
        {
            get => _passportSeries;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Серия паспорта не должна быть пусто", nameof(value));
                _passportSeries = value;
            }
        }

        [Required(ErrorMessage = "Номер паспорта обязателен")]
        [StringLength(6)]
        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер паспорта не должен быть пусто", nameof(value));
                _passportNumber = value;
            }
        }

        [Required(ErrorMessage = "Дата выдачи паспорта обязательна")]
        public DateTime PassportIssueDate { get; set; }

        [Required(ErrorMessage = "Кем выдан паспорт - обязательно")]
        [MinLength(1, ErrorMessage = "Кем выдан паспорт - не должно быть пусто")]
        public string PassportIssuedBy
        {
            get => _passportIssuedBy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Кем выдан паспорт - не должно быть пусто", nameof(value));
                _passportIssuedBy = value;
            }
        }

        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string Phone { get; set; }
    }
}
