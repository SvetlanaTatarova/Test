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
            int n = 0;
            foreach (Speciality speciality in _speciality.GetSpeciality)
            {
                n++;
            }
            SpecialityViewModel[] specialityView = new SpecialityViewModel[n];
            int i = 0;
            foreach (Speciality speciality in _speciality.GetSpeciality)
            {
                int k = 0;
                foreach (AcademicGroup group in _group.GetAcademicGroup())
                {
                    if (group.SpecialityId == speciality.Id)
                    {
                        k++;
                        if (group.SpecialityId > speciality.Id) break;
                    }
                }
                AcademicGroup[] academicGroup = new AcademicGroup[k];
                int j = 0;
                foreach (AcademicGroup group in _group.GetAcademicGroup())
                {
                    if (group.SpecialityId == speciality.Id)
                    {
                        academicGroup[j] = group;
                        j++;
                        if (group.SpecialityId > speciality.Id) break;
                    }
                }

                SpecialityViewModel specialityViewModel = (SpecialityViewModel)speciality;
                specialityViewModel.Groups = academicGroup.ToList();
                specialityView[i] = specialityViewModel;
                i++;
            }
                ViewBag.Title = "Группы";
                return View(specialityView);
            }

        public IActionResult StudentList()
        {
            int n = 0;
            foreach(Student student in _student.GetStudent())
            {
                n++; 
            }
            StudentViewModel[] studentViewsModel = new StudentViewModel[n];
            int i = 0;
            foreach (Student student in _student.GetStudent())
            {
                studentViewsModel[i] = (StudentViewModel)student;
                i++;
            }
            ViewBag.Title = "Студенты";
            return View(studentViewsModel);
        }

        public IActionResult TeacherList()
        {

            //var homeViewModel = new HomeViewModel()
            //{
            //    //allGroups = _group.GetAcademicGroup.ToList(),
            //    allGroups = _group.GetAcademicGroup().ToList(),
            //    allTeachers = _teacher.GetTeacher.ToList()
            //};
            int n = 0;
            foreach (Teacher teacher in _teacher.GetTeacher)
            {
                n++;
            }
            TeacherViewModel[] TeacherView = new TeacherViewModel[n];
            int i = 0;
            foreach (Teacher teacher in _teacher.GetTeacher)
            {
                int k = 0;
                foreach (AcademicGroup group in _group.GetAcademicGroup())
                {
                    if (group.CuratorId == teacher.Id)
                    {
                        k++;
                        if (group.CuratorId > teacher.Id) break;
                    }
                }
                AcademicGroup[] academicGroup = new AcademicGroup[k];
                int j = 0; 
                foreach (AcademicGroup group in _group.GetAcademicGroup().OrderBy(p => p.CuratorId))
                {
                    if (group.CuratorId == teacher.Id)
                    {
                        academicGroup[j] = group;
                        j++;
                        if (group.CuratorId > teacher.Id) break;
                    }
                }

                TeacherViewModel TeacherViewModel = (TeacherViewModel)teacher;
                TeacherViewModel.Groups = academicGroup.ToList();
                TeacherView[i] = TeacherViewModel;
                i++;
            }
            
            ViewBag.Title = "Преподаватели";
            return View(TeacherView);
        }

    }
}
