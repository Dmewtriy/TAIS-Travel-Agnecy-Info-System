using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Interfaces
{
    // Базовый класс для устранения дублирования ID
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
