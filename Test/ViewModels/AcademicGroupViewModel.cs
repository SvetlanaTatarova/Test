using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class AcademicGroupViewModel//: AcademicGroup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите номер группы!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите сокращенный номер группы")]
        [MaxLength(50)]
        public string ShortName { get; set; } 
        public int YearOfStudy { get; set; } 
        public int CourseId { get; set; } 
        public Course Course { get; set; }

        public int SpecialityId { get; set; } 
        public Speciality Speciality { get; set; }

        public int CuratorId { get; set; } 
        public Teacher Curator { get; set; }


        public List<TeacherViewModel> Teachers { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public List<SpecialityViewModel> Specialities { get; set; }
        public List<StudentViewModel> Students { get; set; }



        public List<Teacher> allTeachers { get; set; }
        public List<Course> allCourses { get; set; }
        public List<Speciality> allSpecialities { get; set; }
        public List<Student> allStudents { get; set; }



        public static explicit operator AcademicGroupViewModel(AcademicGroup academic)
        {
            var groupViewModel = new AcademicGroupViewModel
                {
                    Id = academic.Id,
                    Name = academic.Name,
                    ShortName = academic.ShortName,
                    YearOfStudy = academic.YearOfStudy,
                    SpecialityId = academic.SpecialityId,
                    Speciality = academic.Speciality,
                    CourseId = academic.CourseId,
                    Course = academic.Course,
                    CuratorId = academic.CuratorId,
                    Curator = academic.Curator,
                };                
            return groupViewModel;
        }

       
    }
}
