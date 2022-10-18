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
                StudentViewModel studentViewModel = (StudentViewModel)_student.GetOneStudent(id);
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
            AcademicGroup[] academicGroup = new AcademicGroup[n];

            foreach (var group in _group.GetAcademicGroup().ToList())
            {
                if (group != null)
                {
                    academicGroup[i] = group;
                    i++;
                }
            };

            var student = new StudentViewModel()
            {
                Groups = new List<AcademicGroupViewModel>()//academicGroup.ToList()
            };
            //return View();
            return View(student);
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    Student newStudent = (Student)model;
                    var student = _student.CreateStudentPost(newStudent, model.Photo);
                    return RedirectToAction("DetailsStudent", "Student", new { id = student.Id });
                }
                return NotFound();
            }
            //return View();
            return RedirectToAction("CreateStudent", "Student", new { model });
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

                //int n = 0;
                //foreach (AcademicGroup group in _group.GetAcademicGroup().ToList())
                //{
                //    n++;
                //}
                //int i = 0;
                //AcademicGroupViewModel[] academicGroupViews = new AcademicGroupViewModel[n];

                //foreach (var group in _group.GetAcademicGroup().ToList())
                //{
                //    if (group != null)
                //    {
                //        academicGroupViews[i] = (AcademicGroupViewModel)group;
                //        i++;
                //    }
                //};

                StudentViewModel studentViewModel = (StudentViewModel)student;

                studentViewModel.Groups = new List<AcademicGroupViewModel>();
                //studentViewModel.Groups = _group.GetAcademicGroup().ToList();
                var groups = _group.GetAcademicGroup();
                foreach (var group in groups)
                {

                    var groupViewModel = new AcademicGroupViewModel();
                    groupViewModel.Name = group.Name;
                    groupViewModel.ShortName = group.ShortName;
                    groupViewModel.YearOfStudy = group.YearOfStudy;
                    groupViewModel.CourseId = group.CourseId;
                    groupViewModel.SpecialityId = group.SpecialityId;
                    groupViewModel.CuratorId = group.CuratorId;
                    groupViewModel.Id = group.Id;
                    studentViewModel.Groups.Add(groupViewModel);

                }

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
                    Student upStudent = (Student)model;
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
