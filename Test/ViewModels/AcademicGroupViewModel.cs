using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class AcademicGroupViewModel
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
        


        public List<Course> Courses { get; set; }
        public List<Speciality> Specialities { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
       




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
                    //Specialities = academic.Specialities,
                    CourseId = academic.CourseId,
                    Course = academic.Course,
                    //Courses = academic.Courses,
                    CuratorId = academic.CuratorId,
                    Curator = academic.Curator,
                    //Teachers = academic.Teachers,
                    //Students = academic.Students
                };                
            return groupViewModel;
        }

        public static explicit operator AcademicGroup(AcademicGroupViewModel groupViewModel)
        {
            var academic = new AcademicGroup
            {
                Id = groupViewModel.Id,
                Name = groupViewModel.Name,
                ShortName = groupViewModel.ShortName,
                YearOfStudy = groupViewModel.YearOfStudy,
                SpecialityId = groupViewModel.SpecialityId,
                Speciality = groupViewModel.Speciality,
                CourseId = groupViewModel.CourseId,
                Course = groupViewModel.Course,
                CuratorId = groupViewModel.CuratorId,
                Curator = groupViewModel.Curator,
            };
            return academic;
        }

    }
}
