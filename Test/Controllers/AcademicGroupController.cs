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
                AcademicGroup group = _group.GetOneGroup(id);
                var groupViewModel = new AcademicGroupViewModel()
                {
                    Id = group.Id,
                    Name = group.Name,
                    ShortName = group.ShortName,
                    YearOfStudy = group.YearOfStudy,
                    CourseId = group.CourseId,
                    SpecialityId = group.SpecialityId,
                    CuratorId = group.CuratorId,
                    allCourses = _course.GetCourse.ToList(),
                    allSpecialities = _speciality.GetSpeciality.ToList(),
                    allTeachers = _teacher.GetTeacher.ToList(),
                    allStudents = _student.GetStudent.ToList()
                };
                return View(groupViewModel);
            }
            return NotFound();
        }


        public IActionResult CreateGroup()
        {
            ViewBag.Title = "Добавление группы";
            var group = new AcademicGroupViewModel()
            {
                allCourses = _course.GetCourse.ToList(),
                allSpecialities = _speciality.GetSpeciality.ToList(),
                allTeachers = _teacher.GetTeacher.ToList(),
                YearOfStudy = 2022
            };
            return View(group);
        }

        [HttpPost]
        public IActionResult CreateGroup(AcademicGroupViewModel model)
        {
            if (model != null)
            {
                var newGroup = new AcademicGroup()
                {
                    Name = model.Name,
                    ShortName = model.ShortName,
                    YearOfStudy = model.YearOfStudy,
                    CourseId = model.CourseId,
                    SpecialityId = model.SpecialityId,
                    CuratorId = model.CuratorId
                };
                if (ModelState.IsValid)
                {
                    AcademicGroup group = _group.CreateGroupPost(newGroup);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = group.Id });
                }
                return RedirectToAction("CreateGroup", "AcademicGroup");
            }    
                return NotFound();
        }


        public IActionResult EditGroup(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о группе";
                AcademicGroup group = _group.GetOneGroup(id);
                var groupViewModel = new AcademicGroupViewModel()
                {
                    Id = group.Id,
                    Name = group.Name,
                    ShortName = group.ShortName,
                    YearOfStudy = group.YearOfStudy,
                    CourseId = group.CourseId,
                    SpecialityId = group.SpecialityId,
                    CuratorId = group.CuratorId,
                    allCourses = _course.GetCourse.ToList(),
                    allSpecialities = _speciality.GetSpeciality.ToList(),
                    allTeachers = _teacher.GetTeacher.ToList()
                };
                return View(groupViewModel);
            }                
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditGroup(AcademicGroupViewModel model)
        {
            if (model != null)
            { 
                var upGroup = new AcademicGroup()
                {
                    Id = model.Id,
                    Name = model.Name,
                    ShortName = model.ShortName,
                    YearOfStudy = model.YearOfStudy,
                    CourseId = model.CourseId,
                    SpecialityId = model.SpecialityId,
                    CuratorId = model.CuratorId
                };
                if (ModelState.IsValid)
                {
                    var group = _group.EditGroupPost(upGroup);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = group.Id });
                }
                return RedirectToAction("EditGroup", "AcademicGroup");
            }
                return NotFound();
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
