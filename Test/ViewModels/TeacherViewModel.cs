using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class TeacherViewModel//:Teacher
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


       // public List<AcademicGroup> allGroups { get; set; }
       
        public IFormFile Photo { get; set; }


        public List<AcademicGroupViewModel> Groups { get; set; }
    }
}
