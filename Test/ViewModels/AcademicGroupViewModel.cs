using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class AcademicGroupViewModel: AcademicGroup
    {
        public List<CourseViewModel> Courses { get; set; }
        public List<SpecialityViewModel> Specialities { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<StudentViewModel> Students { get; set; }
    }
}
