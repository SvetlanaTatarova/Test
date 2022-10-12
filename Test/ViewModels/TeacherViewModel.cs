using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите Ф.И.О. преподавателя!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите должность преподавателя!")]
        [MaxLength(50)]
        public string Position { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Img { get; set; }
       


        public IFormFile Photo { get; set; }
        public List<AcademicGroup> Groups { get; set; }





        public static explicit operator TeacherViewModel(Teacher teacher )
        {
            var teacherViewModel = new TeacherViewModel
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Position = teacher.Position,
                PhoneNumber = teacher.PhoneNumber,
                Img = teacher.Img,
                Groups = teacher.Groups
            };
            return teacherViewModel;
        }

        public static explicit operator Teacher(TeacherViewModel teacherViewModel)
        {
            var teacher = new Teacher
            {
                Id = teacherViewModel.Id,
                Name = teacherViewModel.Name,
                Position = teacherViewModel.Position,
                PhoneNumber = teacherViewModel.PhoneNumber,
                Img = teacherViewModel.Img
            };
            return teacher;
        }
    }
}
