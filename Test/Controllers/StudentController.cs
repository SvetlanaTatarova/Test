using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        private readonly IAcademicGroup _group;

        public StudentController(IStudent student, IAcademicGroup group)
        {
            _student = student;
            _group = group;
        }


        public IActionResult DetailsStudent(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Информация о студенте";
                Student student = _student.GetOneStudent(id);

                var studentViewModel = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    PhoneNumber = student.PhoneNumber,
                    Img = student.Img,
                    GroupId = student.GroupId,
                    Group = student.Group
                };
                return View(studentViewModel);
            }
            return NotFound();
        }

        public IActionResult CreateStudent()
        {
            ViewBag.Title = "Добавление студента";

            int n = 0;
            foreach (AcademicGroup group in _group.GetAcademicGroup().ToList())
            {
                n++;
            }
            int i = 0;
            AcademicGroupViewModel[] academicGroupViews = new AcademicGroupViewModel[n];

            foreach (var group in _group.GetAcademicGroup().ToList())
            {
                var groupViewModel = new AcademicGroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    ShortName = group.ShortName,
                    YearOfStudy = group.YearOfStudy,
                    SpecialityId = group.SpecialityId,
                    CourseId = group.CourseId,
                    CuratorId = group.CuratorId,
                };


                if (groupViewModel != null)
                    {
                        academicGroupViews[i] = groupViewModel;
                        i++;
                    }
            };

            var student = new StudentViewModel()
            {
                Groups = academicGroupViews.ToList()
            };
            return View(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var newStudent = new Student()
                    {
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        GroupId = model.GroupId,
                        Group = _group.GetOneGroup(model.GroupId),
                        Img = model.Img
                    };

                    var student = _student.CreateStudentPost(newStudent, model.Photo);
                    return RedirectToAction("DetailsStudent", "Student", new { id = student.Id });
                }
                return NotFound();
            }
            return View();
            //return RedirectToAction("CreateStudent", "Student", new { model });
        }


        public IActionResult DeleteStudent(int? id)
        {
            if (id != null)
            {
                Student student = _student.GetOneStudent(id);
                if (student != null)
                {
                    _student.Delete(student);
                    return Redirect("/Home/StudentList");
                }
            }
            return NotFound();
        }

        public IActionResult DeleteGroupStudent(int? id)
        {
            if (id != null)
            {
                Student student = _student.GetOneStudent(id);
                if (student != null)
                {
                    int gId = student.GroupId;
                    _student.Delete(student);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = gId });
                }
            }
            return NotFound();
        }


        public IActionResult EditStudent(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о студенте";
                Student student = _student.GetOneStudent(id);

                int n = 0;
                foreach (AcademicGroup group in _group.GetAcademicGroup().ToList())
                {
                    n++;
                }
                int i = 0;
                AcademicGroupViewModel[] academicGroupViews = new AcademicGroupViewModel[n];

                foreach (var group in _group.GetAcademicGroup().ToList())
                {
                    var groupViewModel = new AcademicGroupViewModel
                    {
                        Id = group.Id,
                        Name = group.Name,
                        ShortName = group.ShortName,
                        YearOfStudy = group.YearOfStudy,
                        SpecialityId = group.SpecialityId,
                        CourseId = group.CourseId,
                        CuratorId = group.CuratorId,
                    };

                    if (groupViewModel != null)
                    {
                        academicGroupViews[i] = groupViewModel;
                        i++;
                    }
                };

                var studentViewModel = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    PhoneNumber = student.PhoneNumber,
                    Img = student.Img,
                    GroupId = student.GroupId,
                    Group = student.Group,
                    Groups = academicGroupViews.ToList()
                };
                return View(studentViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var upStudent = new Student()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        GroupId = model.GroupId,
                        Group = model.Group,
                        Img = model.Img
                    };
                    var student = _student.EditStudentPost(upStudent, model.Photo);
                    return RedirectToAction("DetailsStudent", "Student", new { id = student.Id });
                }
                return NotFound();
            }
            //return View();
            return RedirectToAction("EditStudent", "Student", new { model = model });
        }
    }

   


}
