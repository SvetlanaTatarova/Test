using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Введите Ф.И.О. студента!")]
        [MaxLength (50)]
        public string Name { get; set; } // ФИО студента
        public string PhoneNumber { get; set; } // Контактный номер телефона студента
        public string Img { get; set; } // Фотография студента

        public int GroupId { get; set; } // Id группы, в которой обучается студент
    }
}
