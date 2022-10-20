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
        private readonly IPosition _position;
        public TeacherController(ITeacher teacher, IAcademicGroup group, IPosition position)
        {
            _teacher = teacher;
            _group = group;
            _position = position;
        }


        public IActionResult DetailsTeacher(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Информация о преподавателе";


                var teacher = _teacher.GetOneTeacher(id);

                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    PositionId = teacher.PositionId,
                    Position = teacher.Position,
                    Name = teacher.Name,
                    PhoneNumber = teacher.PhoneNumber,
                    Img = teacher.Img,
                    Groups = new List<AcademicGroupViewModel>()
                };

                var groups = _group.GetAcademicGroupByTecherId(id.Value);
                foreach (var group in groups)
                {
                    var groupViewModel = new AcademicGroupViewModel
                    {
                        Id = group.Id,
                        Name = group.Name,
                        ShortName = group.ShortName,
                        YearOfStudy = group.YearOfStudy
                    };

                    teacherViewModel.Groups.Add(groupViewModel);
                }
                return View(teacherViewModel);
            }
            return NotFound();
        }



        public IActionResult CreateTeacher()
        {
            ViewBag.Title = "Добавление преподавателя";

            var teacherViewModel = new TeacherViewModel
            {
                Positions = new List<PositionViewModel>()
            };
            
            var positions = _position.GetPositions;
            foreach (var position in positions)
            {

                var positionViewModel = new PositionViewModel
                {
                    Id = position.Id,
                    Name = position.Name
                };
                teacherViewModel.Positions.Add(positionViewModel);
            }

            return View(teacherViewModel);
        }
        [HttpPost]
        public IActionResult CreateTeacher(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var newTeacher = new Teacher
                    {
                        Name = model.Name,
                        PositionId = model.PositionId,
                        Img = model.Img,
                        PhoneNumber = model.PhoneNumber
                    };

                    var teacher = _teacher.CreateTeacherPost(newTeacher, model.Photo);
                    return RedirectToAction("DetailsTeacher", "Teacher", new { id = teacher.Id });
                }
                return NotFound();
            }
            else
            {
                ViewBag.Title = "Добавление преподавателя";

                var teacherViewModel = new TeacherViewModel
                {
                    Positions = new List<PositionViewModel>()
                };

                var positions = _position.GetPositions;
                foreach (var position in positions)
                {

                    var positionViewModel = new PositionViewModel
                    {
                        Id = position.Id,
                        Name = position.Name
                    };
                    teacherViewModel.Positions.Add(positionViewModel);
                }

                return View(teacherViewModel);
            }
        }



        public IActionResult DeleteTeacher(int? id)
        {
            if (id != null)
            {
                Teacher teacher = _teacher.GetOneTeacher(id);
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
            return View();
        }



        public IActionResult EditTeacher(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование информации о преподавателе";
                Teacher teacher = _teacher.GetOneTeacher(id);
                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    PositionId = teacher.PositionId,
                    Positions = new List<PositionViewModel>(),
                    Position = teacher.Position,
                    PhoneNumber = teacher.PhoneNumber,
                    Img = teacher.Img
                };
                var positions = _position.GetPositions;
                foreach (var position in positions)
                {

                    var positionViewModel = new PositionViewModel
                    {
                        Id = position.Id,
                        Name = position.Name
                    };
                    teacherViewModel.Positions.Add(positionViewModel);
                }
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
                    var upTeacher = new Teacher
                    {
                        Id = model.Id,
                        Name = model.Name,
                        PositionId = model.PositionId,
                        Position = model.Position,
                        PhoneNumber = model.PhoneNumber,
                        Img = model.Img
                    };
                    var teacher = _teacher.EditTeacherPost(upTeacher, model.Photo);
                    return RedirectToAction("DetailsTeacher", "Teacher", new { id = teacher.Id });
                }
                return NotFound();
            }
            else
            {
                ViewBag.Title = "Редактирование информации о преподавателе";
                Teacher teacher = _teacher.GetOneTeacher(model.Id);
                var teacherViewModel = new TeacherViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    PositionId = teacher.PositionId,
                    Positions = new List<PositionViewModel>(),
                    Position = teacher.Position,
                    PhoneNumber = teacher.PhoneNumber,
                    Img = teacher.Img
                };
                var positions = _position.GetPositions;
                foreach (var position in positions)
                {

                    var positionViewModel = new PositionViewModel
                    {
                        Id = position.Id,
                        Name = position.Name
                    };
                    teacherViewModel.Positions.Add(positionViewModel);
                }
                return View(teacherViewModel);
            }
        }

    }
}
