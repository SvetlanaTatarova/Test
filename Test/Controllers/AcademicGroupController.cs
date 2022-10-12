using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class AcademicGroupController : Controller
    {

        private readonly IAcademicGroup _group;
        private readonly IStudent _student;
        private readonly ITeacher _teacher;
        private readonly ISpeciality _speciality;
        private readonly ICourse _course;

        public AcademicGroupController(IAcademicGroup group, IStudent student, ITeacher teacher, ISpeciality speciality, ICourse course)
        {
            _group = group;
            _course = course;
            _speciality = speciality;
            _student = student;
            _teacher = teacher;
        }

        // Вывод подробной информации о группе
        public IActionResult DetailsGroup(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Информация о группе";
                AcademicGroupViewModel groupViewModel = (AcademicGroupViewModel)_group.GetOneGroup(id);
                
                int n = 0;
                foreach (Student student in _student.GetStudent)
                {
                    if (student.GroupId == groupViewModel.Id)
                    {
                        n++;
                    }
                }
                int i = 0;
                Student[] studentViews = new Student[n];
                foreach (var student in _student.GetStudent)
                {
                    if (student.GroupId == groupViewModel.Id)
                    {
                        studentViews[i] = student;
                        i++;
                    }
                };

                groupViewModel.Students = studentViews.ToList();
                return View(groupViewModel);
            }
            return NotFound();
        }


        public IActionResult CreateGroup()
        {
            ViewBag.Title = "Добавление группы";
            var group = new AcademicGroupViewModel()
            {
                Courses = _course.GetCourse.ToList(),
                Specialities = _speciality.GetSpeciality.ToList(),
                Teachers = _teacher.GetTeacher.ToList(),
                YearOfStudy = 2022
            };
            return View(group);
        }

        [HttpPost]
        public IActionResult CreateGroup(AcademicGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    AcademicGroup newGroup = (AcademicGroup)model;
                    AcademicGroup group = _group.CreateGroupPost(newGroup);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = group.Id });
                }
                return NotFound();
            }
            //return View();
            return RedirectToAction("CreateGroup", "AcademicGroup");
        }


        public IActionResult EditGroup(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о группе";
                AcademicGroupViewModel groupViewModel = (AcademicGroupViewModel) _group.GetOneGroup(id);
                groupViewModel.Courses = _course.GetCourse.ToList();
                groupViewModel.Specialities = _speciality.GetSpeciality.ToList();
                groupViewModel.Teachers = _teacher.GetTeacher.ToList();
                return View(groupViewModel);
            }                
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditGroup(AcademicGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    AcademicGroup upGroup = (AcademicGroup)model;
                    var group = _group.EditGroupPost(upGroup);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = group.Id });
                }
                return NotFound();
            }
            //return View();
            return RedirectToAction("EditGroup", "AcademicGroup");
        }


        public IActionResult DeleteGroup(int? id)
        {
            if (id != null)
            {
                AcademicGroup group = _group.GetOneGroup(id);
                if (group != null)
                {
                    foreach (Student student in _student.GetStudent)
                    {
                        if (student.GroupId == group.Id)
                        {
                            _student.DeleteWithGroup(student);
                        }
                    }
                    _group.Delete(group);
                }
                return Redirect("/Home/Index");
            }
            return NotFound();
        }
    }
}
