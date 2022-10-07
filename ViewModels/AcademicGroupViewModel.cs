using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class AcademicGroupViewModel: AcademicGroup
    {
        public List<Teacher> allTeachers { get; set; }
        public List<Course> allCourses { get; set; }
        public List<Speciality> allSpecialities { get; set; }
        public List<Student> allStudents { get; set; }
    }
}
