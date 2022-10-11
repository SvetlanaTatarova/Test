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
        private readonly IAcademicGroup _group;
        private readonly ISpeciality _speciality;
        private readonly IStudent _student;
        private readonly ITeacher _teacher;

        public HomeController(IAcademicGroup group, ISpeciality speciality, IStudent student, ITeacher teacher)
        {
            _group = group;
            _speciality = speciality;
            _student = student;
            _teacher = teacher;
        }


        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                //allGroups = _group.GetAcademicGroup.ToList(),
                allGroups = _group.GetAcademicGroup().ToList(),
                allSpecialities = _speciality.GetSpeciality.ToList()
            };
            ViewBag.Title = "Группы";
            return View(homeViewModel);
        }

        public IActionResult StudentList()
        {
            var homeViewModel = new HomeViewModel()
            {
                //allGroups = _group.GetAcademicGroup.ToList(),
                allGroups = _group.GetAcademicGroup().ToList(),
                allStudents = _student.GetStudent.ToList()
            };
            ViewBag.Title = "Студенты";
            return View(homeViewModel);
        }

        public IActionResult TeacherList()
        {
            var homeViewModel = new HomeViewModel()
            {
                //allGroups = _group.GetAcademicGroup.ToList(),
                allGroups = _group.GetAcademicGroup().ToList(),
                allTeachers = _teacher.GetTeacher.ToList()
            };
            ViewBag.Title = "Преподаватели";
            return View(homeViewModel);
        }

    }
}
