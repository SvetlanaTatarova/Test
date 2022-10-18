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

                var group = _group.GetOneGroup(id);
                var groupViewModel = new AcademicGroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    ShortName = group.ShortName,
                    YearOfStudy = group.YearOfStudy,
                    SpecialityId = group.SpecialityId,
                    Speciality = _speciality.GetOneSpeciality(group.SpecialityId),
                    CourseId = group.CourseId,
                    Course = _course.GetOneCourse(group.CourseId),
                    CuratorId = group.CuratorId,
                    Curator = _teacher.GetOneTeacher(group.CuratorId),
                    Students = new List<StudentViewModel>()
                };

                var students = _student.GetStudentByGroupId(id);
                foreach (var student in students)
                {
                    var studentViewModel = new StudentViewModel
                    {
                        Id = student.Id,
                        Name = student.Name,
                        PhoneNumber = student.PhoneNumber,
                        Img = student.Img
                    };

                    groupViewModel.Students.Add(studentViewModel);
                }
                return View(groupViewModel);
            }
            return NotFound();
        }


        public IActionResult CreateGroup()
        {
            ViewBag.Title = "Добавление группы";
            var group = new AcademicGroupViewModel()
            {
                Courses = new List<CourseViewModel>(),
                Specialities = new List<SpecialityViewModel>(),
                Teachers = new List<TeacherViewModel>(),
                YearOfStudy = 2022
            };

            var courses = _course.GetCourse;
            foreach(var course in courses)
            {
                var courseViewModel = new CourseViewModel
                {
                    Id = course.Id,
                    CourseNumber = course.CourseNumber
                };
                group.Courses.Add(courseViewModel);
            }

            var specialities = _speciality.GetSpeciality;
            foreach(var speciality in specialities)
            {
                var specialityViewModel = new SpecialityViewModel
                {
                    Id = speciality.Id,
                    Name = speciality.Name
                };
                group.Specialities.Add(specialityViewModel);
            }

            var teachers = _teacher.GetTeacher;
            foreach(var teacher in teachers)
            {
                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name
                };
                group.Teachers.Add(teacherViewModel);
            }

            return View(group);
        }

        [HttpPost]
        public IActionResult CreateGroup(AcademicGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                   var newGroup = new AcademicGroup
                    {
                        Name = model.Name,
                        ShortName = model.ShortName,
                        SpecialityId = model.SpecialityId,
                        CourseId = model.CourseId,
                        YearOfStudy = model.YearOfStudy,
                        CuratorId = model.CuratorId
                    };
                    AcademicGroup group = _group.CreateGroupPost(newGroup);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = group.Id });
                }
                return NotFound();
            }
            else
            {
                ViewBag.Title = "Добавление группы";
                var group = new AcademicGroupViewModel()
                {
                    Courses = new List<CourseViewModel>(),
                    Specialities = new List<SpecialityViewModel>(),
                    Teachers = new List<TeacherViewModel>(),
                    YearOfStudy = 2022
                };

                var courses = _course.GetCourse;
                foreach (var course in courses)
                {
                    var courseViewModel = new CourseViewModel
                    {
                        Id = course.Id,
                        CourseNumber = course.CourseNumber
                    };
                    group.Courses.Add(courseViewModel);
                }

                var specialities = _speciality.GetSpeciality;
                foreach (var speciality in specialities)
                {
                    var specialityViewModel = new SpecialityViewModel
                    {
                        Id = speciality.Id,
                        Name = speciality.Name
                    };
                    group.Specialities.Add(specialityViewModel);
                }

                var teachers = _teacher.GetTeacher;
                foreach (var teacher in teachers)
                {
                    var teacherViewModel = new TeacherViewModel
                    {
                        Id = teacher.Id,
                        Name = teacher.Name
                    };
                    group.Teachers.Add(teacherViewModel);
                }

                return View(group);
            }
        }


        public IActionResult EditGroup(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о группе";
                var academicGroup = _group.GetOneGroup(id);
                var group = new AcademicGroupViewModel()
                {
                    Id = academicGroup.Id,
                    Name = academicGroup.Name,
                    ShortName = academicGroup.ShortName,
                    YearOfStudy = academicGroup.YearOfStudy,
                    CourseId = academicGroup.CourseId,
                    Course = _course.GetOneCourse(academicGroup.CourseId),
                    SpecialityId = academicGroup.SpecialityId,
                    Speciality = _speciality.GetOneSpeciality(academicGroup.SpecialityId),
                    CuratorId = academicGroup.CuratorId,
                    Curator = _teacher.GetOneTeacher(academicGroup.CuratorId),
                    Courses = new List<CourseViewModel>(),
                    Specialities = new List<SpecialityViewModel>(),
                    Teachers = new List<TeacherViewModel>()
                };

                var courses = _course.GetCourse;
                foreach (var course in courses)
                {
                    var courseViewModel = new CourseViewModel
                    {
                        Id = course.Id,
                        CourseNumber = course.CourseNumber
                    };
                    group.Courses.Add(courseViewModel);
                }

                var specialities = _speciality.GetSpeciality;
                foreach (var speciality in specialities)
                {
                    var specialityViewModel = new SpecialityViewModel
                    {
                        Id = speciality.Id,
                        Name = speciality.Name
                    };
                    group.Specialities.Add(specialityViewModel);
                }

                var teachers = _teacher.GetTeacher;
                foreach (var teacher in teachers)
                {
                    var teacherViewModel = new TeacherViewModel
                    {
                        Id = teacher.Id,
                        Name = teacher.Name
                    };
                    group.Teachers.Add(teacherViewModel);
                }

                return View(group);
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
                   var upGroup = new AcademicGroup
                    {
                       Id = model.Id,
                       Name = model.Name,
                       ShortName = model.ShortName,
                       SpecialityId = model.SpecialityId,
                       CourseId = model.CourseId,
                       YearOfStudy = model.YearOfStudy,
                       CuratorId = model.CuratorId
                   };
                    var group = _group.EditGroupPost(upGroup);
                    return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = group.Id });
                }
                return NotFound();
            }
            else
            {
                ViewBag.Title = "Редактирование информации о группе";
                var academicGroup = _group.GetOneGroup(model.Id);
                var group = new AcademicGroupViewModel()
                {
                    Id = academicGroup.Id,
                    Name = academicGroup.Name,
                    ShortName = academicGroup.ShortName,
                    YearOfStudy = academicGroup.YearOfStudy,
                    CourseId = academicGroup.CourseId,
                    Course = _course.GetOneCourse(academicGroup.CourseId),
                    SpecialityId = academicGroup.SpecialityId,
                    Speciality = _speciality.GetOneSpeciality(academicGroup.SpecialityId),
                    CuratorId = academicGroup.CuratorId,
                    Curator = _teacher.GetOneTeacher(academicGroup.CuratorId),
                    Courses = new List<CourseViewModel>(),
                    Specialities = new List<SpecialityViewModel>(),
                    Teachers = new List<TeacherViewModel>()
                };

                var courses = _course.GetCourse;
                foreach (var course in courses)
                {
                    var courseViewModel = new CourseViewModel
                    {
                        Id = course.Id,
                        CourseNumber = course.CourseNumber
                    };
                    group.Courses.Add(courseViewModel);
                }

                var specialities = _speciality.GetSpeciality;
                foreach (var speciality in specialities)
                {
                    var specialityViewModel = new SpecialityViewModel
                    {
                        Id = speciality.Id,
                        Name = speciality.Name
                    };
                    group.Specialities.Add(specialityViewModel);
                }

                var teachers = _teacher.GetTeacher;
                foreach (var teacher in teachers)
                {
                    var teacherViewModel = new TeacherViewModel
                    {
                        Id = teacher.Id,
                        Name = teacher.Name
                    };
                    group.Teachers.Add(teacherViewModel);
                }

                return View(group);
            }
        }


        public IActionResult DeleteGroup(int? id)
        {
            if (id != null)
            {
                AcademicGroup group = _group.GetOneGroup(id);
                if (group != null)
                {
                    var students = _student.GetStudent;
                    foreach (Student student in students)
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
