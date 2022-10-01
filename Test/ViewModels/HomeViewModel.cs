using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class HomeViewModel
    {
        //public IEnumerable<Course> GetAllCourses { get; set; }

        public IEnumerable<Speciality> GetAllSpecialities { get; set; }

        public IEnumerable<Teacher> GetAllTeachers { get; set; }

        public IEnumerable<AcademicGroup> GetAllGroups { get; set; }

        public IEnumerable<Student> GetAllStudents { get; set; }
    }
}
