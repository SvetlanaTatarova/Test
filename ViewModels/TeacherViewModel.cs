using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class TeacherViewModel:Teacher
    {
        public List<AcademicGroupViewModel> allGroups { get; set; }
       
        public IFormFile Photo { get; set; }
    }
}
