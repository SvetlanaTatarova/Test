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
        private readonly IAcademicGroup Group;       

        public AcademicGroupController(IAcademicGroup _Group)
        {
            Group = _Group;
        }

        // Вывод подробной информации о группе
        public IActionResult DetailsGroup(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Подробная информация группы";
                return View(Group.GetOneGroup(id));
            }
            return NotFound();            
        }


        public IActionResult CreateGroup()
        {
            ViewBag.Title = "Добавление группы";
            return View(Group.CreateGroup());
        }

        [HttpPost]
        public IActionResult CreateGroup(AcademicGroupViewModel _Group)
        {
            if (_Group != null)
            {
                AcademicGroupViewModel GROUP;                
                GROUP = (AcademicGroupViewModel)Group.CreateGroupPost(_Group);
                return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = GROUP.Id });
            }    
                return NotFound();            
        }


        public IActionResult EditGroup(int? id)
        {
            if (id != null)
            {
                ViewBag.Title = "Редактирование группы";
                return View(Group.EditGroup(id));
            }                
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditGroup(AcademicGroupViewModel _Group)
        {
            if (_Group != null)
            { 
                Group.EditGroupPost(_Group);
                return RedirectToAction("DetailsGroup", "AcademicGroup", new { id = _Group.Id });
            }
                return NotFound();            
        }


        public IActionResult DeleteGroup(int? id)
        {
            if (id != null)
            {
                Group.Delete(id);
                return Redirect("/Home/Index");
            }
            return NotFound();
        }
    }
}
