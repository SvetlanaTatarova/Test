using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class StudentViewModel//: Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите Ф.И.О. студента!")]
        [MaxLength(50)]
        public string Name { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Img { get; set; } 

        public int GroupId { get; set; } 
        public AcademicGroup Group { get; set; }


       // public List<AcademicGroup> allGroups { get; set; }
        public IFormFile Photo { get; set; }

        public List<AcademicGroupViewModel> Groups { get; set; }


        //public static implicit operator StudentViewModel(Student student)
        //{
        //   var studentViewModel = new StudentViewModel
        //    {
        //        Id = student.Id,
        //        Name = student.Name,
        //        PhoneNumber = student.PhoneNumber,
        //        Img = student.Img,
        //        GroupId = student.GroupId,
        //        Group = student.Group
        //    };
        //    return studentViewModel;
        //}
    }
}
