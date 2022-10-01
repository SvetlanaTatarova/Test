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
                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Position = teacher.Position,
                    PhoneNumber = teacher.PhoneNumber,
                    Img = teacher.Img,
                    allGroups = _group.GetAcademicGroup.ToList()
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

        
        public IActionResult DeleteTeacher(int? id)
        {
            if (id != null)
            {
                Teacher teacher = _teacher.GetOneTeacher(id);
                List<AcademicGroup> allGroups = _group.GetAcademicGroup.ToList();
                AcademicGroup group = _group.GetAcademicGroup.FirstOrDefault(p => p.CuratorId == id);
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
                ViewBag.Title = "Информация о преподавателе";
                Teacher teacher = _teacher.GetOneTeacher(id);
                var teacherViewModel = new TeacherViewModel
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
            if (model != null)
            {

                var newTeacher = new Teacher()
                {
                    Id = model.Id,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Position = model.Position,
                    Img = model.Img
                };
                var teacher = _teacher.EditTeacherPost(newTeacher, model.Photo);
                return RedirectToAction("DetailsTeacher", "Teacher", new { id = teacher.Id });
            }
            return NotFound();
        }
    }
}
