using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.ViewModels;
using Xceed.Wpf.Toolkit;

namespace Test.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacher _teacher;
        private readonly IAcademicGroup _group;
       

        public TeacherController(ITeacher teacher, IAcademicGroup group)
        {
            _teacher = teacher;
            _group = group;
        }


        public IActionResult DetailsTeacher(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Информация о преподавателе";
                Teacher teacher = _teacher.GetOneTeacher(id);

                int n = 0;
                foreach (AcademicGroup group in _group.GetAcademicGroup().ToList())
                {
                    if (group.CuratorId == teacher.Id)
                    {
                        n++;
                    }
                }
                int i = 0;
                AcademicGroupViewModel[] academicGroupViews = new AcademicGroupViewModel[n];
               
                foreach (var group in _group.GetAcademicGroup().ToList() )
                {
                    if (group.CuratorId == teacher.Id)
                    {
                        var groupViewModel = new AcademicGroupViewModel
                        {
                            Id = group.Id,
                            Name = group.Name,
                            ShortName = group.ShortName,
                            YearOfStudy = group.YearOfStudy,
                            SpecialityId = group.SpecialityId,
                            //allSpecialities = Context.Specialities.ToList(),
                            CourseId = group.CourseId,
                            //allCourses = Context.Courses.ToList(),
                            CuratorId = group.CuratorId,
                            //allTeachers = Context.Teachers.ToList(),
                            //allStudents = Context.Students.ToList()
                        };
                    
                        if (groupViewModel != null)
                        {
                            academicGroupViews[i] = groupViewModel;
                            i++;
                        }
                    }
                };

                var teacherViewModel = new TeacherViewModel()
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Position = teacher.Position,
                    PhoneNumber = teacher.PhoneNumber,
                    Img = teacher.Img,
                    Groups = academicGroupViews.ToList(),
                    //allGroups = _group.GetAcademicGroup.ToList()
                };
                return View(teacherViewModel);
            }
            return NotFound();
        }


        public IActionResult CreateTeacher()
        {
            ViewBag.Title = "Добавление преподавателя";
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeacher(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var newTeacher = new Teacher()
                    {
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        Position = model.Position,
                        Img = model.Img
                    };
                    var teacher = _teacher.CreateTeacherPost(newTeacher, model.Photo);
                    return RedirectToAction("DetailsTeacher", "Teacher", new { id = teacher.Id });
                }
                return NotFound();
            }
            return View();
        }

        
        public IActionResult DeleteTeacher(int? id)
        {
            if (id != null)
            {
                Teacher teacher = _teacher.GetOneTeacher(id);
                AcademicGroup group = _group.GetAcademicGroup().FirstOrDefault(p => p.CuratorId == id);
                if (teacher != null)
                {
                    if (group == null)
                    {
                        _teacher.Delete(teacher);
                        return Redirect("/Home/TeacherList");
                    }
                    else 
                    {
                        return View();
                    }
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteTeacher()
        {
            return Redirect("/Home/TeacherList");
        }
        
        public IActionResult EditTeacher(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о преподавателе";
                Teacher teacher = _teacher.GetOneTeacher(id);
                var teacherViewModel = new TeacherViewModel()
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Position = teacher.Position,
                    PhoneNumber = teacher.PhoneNumber,
                    Img = teacher.Img
                };
                return View(teacherViewModel);
            }
            return NotFound();
        }
       
        [HttpPost]
        public IActionResult EditTeacher(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var upTeacher = new Teacher()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        Position = model.Position,
                        Img = model.Img
                    };
                    var teacher = _teacher.EditTeacherPost(upTeacher, model.Photo);
                    return RedirectToAction("DetailsTeacher", "Teacher", new { id = teacher.Id });
                }
                return NotFound();
            }
            return View();
        }
    }
}
