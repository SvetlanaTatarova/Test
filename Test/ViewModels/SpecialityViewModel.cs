using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class SpecialityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AcademicGroup> Groups { get; set; }


        public static explicit operator SpecialityViewModel(Speciality speciality)
        {
            var specialityViewModel = new SpecialityViewModel
            {
                Id = speciality.Id,
                Name = speciality.Name
            };
            return specialityViewModel;
        }

        public static explicit operator Speciality(SpecialityViewModel specialityViewModel)
        {
            var speciality = new Speciality
            {
                Id = specialityViewModel.Id,
                Name = specialityViewModel.Name
            };
            return speciality;
        }
    }
}
