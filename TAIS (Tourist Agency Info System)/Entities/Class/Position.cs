using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class Position : BaseEntity
    {
        public Position(int id, string title, string okpdtrCode)
        {
            Id = id;
            Title = title;
            OkpdtrCode = okpdtrCode;
        }

        private string _title;
        private string _okpdtrCode;

        [Required(ErrorMessage = "Название должности обязательно")]
        [MinLength(1, ErrorMessage = "Название не должно быть пусто")]
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не должно быть пусто", nameof(value));
                _title = value;
            }
        }

        [Required(ErrorMessage = "Код ОКПДТР обязателен")]
        [MinLength(1, ErrorMessage = "Код не должен быть пусто")]
        public string OkpdtrCode
        {
            get => _okpdtrCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Код не должен быть пусто", nameof(value));
                _okpdtrCode = value;
            }
        }
    }
}
