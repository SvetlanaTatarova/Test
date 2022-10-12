using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class AcademicGroup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите номер группы!")]
        [MaxLength(50)]
        public string Name { get; set; } // Название (номер) группы

        [Required(ErrorMessage = "Введите сокращенный номер группы")]
        [MaxLength(50)]
        public string ShortName { get; set; } // Сокращенное название (номер) группы
        public int YearOfStudy { get; set; } // Год начала обучения


        public int CourseId { get; set; } // Id курса обучения группы
        public Course Course { get; set; }
       // public List<Course> Courses { get; set; }

        public int SpecialityId { get; set; } // Id специальности группы
        public Speciality Speciality { get; set; }
       // public List<Speciality> Specialities { get; set; }

        public int CuratorId { get; set; } //Id куратора группы
        public Teacher Curator { get; set; }
       // public List<Teacher> Teachers { get; set; }

       // public List<Student> Students { get; set; }
    }
}
