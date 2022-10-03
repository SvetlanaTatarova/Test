using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class HomeViewModel
    {
        public List<Speciality> allSpecialities { get; set; }
        public List<Teacher> allTeachers { get; set; }
        public List<AcademicGroup> allGroups { get; set; }
        public List<Student> allStudents { get; set; }

    }
}
