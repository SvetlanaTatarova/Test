using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class TeacherViewModel: Teacher
    {
        public IFormFile Photo { get; set; }
        public List<AcademicGroupViewModel> Groups { get; set; }
    }
}
