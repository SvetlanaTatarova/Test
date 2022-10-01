using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } // ФИО преподавателя
        public string Position { get; set; } // Должность преподавателя
        public string PhoneNumber { get; set; } // Контактный номер телефона преподавателя
        public string Img { get; set; } // Фотография преподавателя
    }
}
