using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите Ф.И.О. преподавателя!")]
        [MaxLength(50)]
        public string Name { get; set; } // ФИО преподавателя

        [Required(ErrorMessage = "Введите должность преподавателя!")]
        [MaxLength(50)]
        public string Position { get; set; } // Должность преподавателя
        public string PhoneNumber { get; set; } // Контактный номер телефона преподавателя
        public string Img { get; set; } // Фотография преподавателя
    }
}
