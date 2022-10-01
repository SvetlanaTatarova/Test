using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class AcademicGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название (номер) группы
        public string ShortName { get; set; } // Сокращенное название (номер) группы
        public int YearOfStudy { get; set; } // Год начала обучения


        public int CourseId { get; set; } // Id курса обучения группы

        public int SpecialityId { get; set; } // Id специальности группы

        public int CuratorId { get; set; } //Id куратора группы
    }
}
