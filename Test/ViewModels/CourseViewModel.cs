using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public int CourseNumber { get; set; }


        public static explicit operator CourseViewModel (Course course)
        {
            var courseViewModel = new CourseViewModel
            {
                Id = course.Id,
                CourseNumber = course.CourseNumber
            };
            return courseViewModel;
        }


        public static explicit operator Course(CourseViewModel courseViewModel)
        {
            var course = new Course
            {
                Id = courseViewModel.Id,
                CourseNumber = courseViewModel.CourseNumber
            };
            return course;
        }
    }
}
