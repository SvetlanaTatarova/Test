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
            var SpecialityViewModelList = new List<SpecialityViewModel>();
            var specialities = _speciality.GetSpeciality;
            foreach (Speciality speciality in specialities)
            {
                var specialityViewModel = new SpecialityViewModel
                {
                    Id = speciality.Id,
                    Name = speciality.Name,                    
                    Groups = new List<AcademicGroupViewModel>()
                };

                var groups = _group.GetAcademicGroupBySpecialityId(specialityViewModel.Id);
                foreach (var group in groups)
                {
                    var groupViewModel = new AcademicGroupViewModel
                    {
                        Id = group.Id,
                        Name = group.Name,
                        ShortName = group.ShortName
                    };

                    specialityViewModel.Groups.Add(groupViewModel);
                }

                SpecialityViewModelList.Add(specialityViewModel);
            }
            ViewBag.Title = "Группы";
            return View(SpecialityViewModelList);
        }



        public IActionResult StudentList()
        {
            var StudentViewModelList = new List<StudentViewModel>();
            var students = _student.GetStudent;
            foreach (Student student in students)
            {
                var studentViewModel = new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    PhoneNumber = student.PhoneNumber,
                    Img = student.Img,
                    GroupId = student.GroupId,
                    Group = _group.GetOneGroup(student.GroupId)
                };

                StudentViewModelList.Add(studentViewModel);
            }

            ViewBag.Title = "Студенты";
            return View(StudentViewModelList);
        }

        public IActionResult TeacherList()
        {
            var TeacherViewModelList = new List<TeacherViewModel>();
            var teachers = _teacher.GetTeacher;
            foreach (Teacher teacher in teachers)
            {
                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    PhoneNumber = teacher.PhoneNumber,
                    Position = teacher.Position,
                    Img = teacher.Img,
                    Groups = new List<AcademicGroupViewModel>()
                };

                var groups = _group.GetAcademicGroupByTecherId(teacherViewModel.Id);
                foreach (var group in groups)
                {
                    var groupViewModel = new AcademicGroupViewModel
                    {
                        Id = group.Id,
                        Name = group.Name,
                        ShortName = group.ShortName
                    };

                    teacherViewModel.Groups.Add(groupViewModel);
                }

                TeacherViewModelList.Add(teacherViewModel);
            }

            ViewBag.Title = "Преподаватели";
            return View(TeacherViewModelList);
        }

    }
}
