using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class SpecialityViewModel: Speciality
    {
        public List<AcademicGroupViewModel> Groups { get; set; }
    }
}
