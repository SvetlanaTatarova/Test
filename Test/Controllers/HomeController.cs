using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.Models.InitializeDB;
using Test.ViewModels;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAcademicGroup group;
        private readonly ISpeciality speciality;
        private readonly IStudent student;
        private readonly ITeacher teacher;
        private readonly ICourse course;

        public HomeController(IAcademicGroup _group, ISpeciality _speciality, IStudent _student, ITeacher _teacher, ICourse _course)
        {
            group = _group;
            speciality = _speciality;
            student = _student;
            teacher = _teacher;
            course = _course;
        }


        public ViewResult Index()
        {
            HomeViewModel obj = new HomeViewModel
            {
                GetAllGroups = group.GetAcademicGroup,
                GetAllSpecialities = speciality.GetSpeciality
            };
            ViewBag.Title = "Группы";
            return View(obj);
        }

        public IActionResult StudentList()
        {
            HomeViewModel obj = new HomeViewModel
            {
                GetAllGroups = group.GetAcademicGroup,
                GetAllStudents = student.GetStudent
            };
            ViewBag.Title = "Студенты";
            return View(obj);
        }

        public IActionResult TeacherList()
        {
            HomeViewModel obj = new HomeViewModel
            {
                GetAllGroups = group.GetAcademicGroup,
                GetAllTeachers = teacher.GetTeacher
            };
            ViewBag.Title = "Преподаватели";
            return View(obj);
        }

    }
}
