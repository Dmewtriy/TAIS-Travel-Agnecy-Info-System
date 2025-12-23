using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Country : BaseEntity
    {
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        private string _name;

        [Required(ErrorMessage = "Название страны обязательно")]
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
    }
}
