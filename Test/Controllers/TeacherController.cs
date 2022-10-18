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

                //TeacherViewModel teacherViewModel = (TeacherViewModel)_teacher.GetOneTeacher(id);

                var teacher = _teacher.GetOneTeacher(id);

                var teacherViewModel = new TeacherViewModel();
                teacherViewModel.Position = teacher.Position;
                teacherViewModel.Name = teacher.Name;
                teacherViewModel.PhoneNumber = teacher.PhoneNumber;
                teacherViewModel.Img = teacher.Img;
                teacherViewModel.Groups = new List<AcademicGroupViewModel>();

                var groups = _group.GetAcademicGroupByTecherId(id.Value);

                foreach (var group in groups)
                {
                    var groupViewModel = new AcademicGroupViewModel();
                    groupViewModel.Name = group.Name;
                    groupViewModel.ShortName = group.ShortName;
                    groupViewModel.YearOfStudy = group.YearOfStudy;
                    groupViewModel.CourseId = group.CourseId;
                    groupViewModel.SpecialityId = group.SpecialityId;
                    groupViewModel.CuratorId = group.CuratorId;

                    teacherViewModel.Groups.Add(groupViewModel);
                }

                //int n = 0;
                //foreach (AcademicGroup group in _group.GetAcademicGroup().ToList())
                //{
                //    if (group.CuratorId == teacherViewModel.Id)
                //    {
                //        n++;
                //    }
                //}
                //int i = 0;
                //AcademicGroup[] academicGroup = new AcademicGroup[n];               
                //foreach (var group in _group.GetAcademicGroup().ToList() )
                //{
                //    if (group.CuratorId == teacherViewModel.Id)
                //    {
                //        academicGroup[i] =group;
                //        i++;
                //    }
                //};

                //teacherViewModel.Groups = academicGroup.ToList();

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
                    Teacher newTeacher = (Teacher)model;
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
            return View();
        }



        public IActionResult EditTeacher(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о преподавателе";
                TeacherViewModel teacherViewModel = (TeacherViewModel)_teacher.GetOneTeacher(id);
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
                    Teacher upTeacher = (Teacher)model;
                    var teacher = _teacher.EditTeacherPost(upTeacher, model.Photo);
                    return RedirectToAction("DetailsTeacher", "Teacher", new { id = teacher.Id });
                }
                return NotFound();
            }
            return View();
        }

    }
}
