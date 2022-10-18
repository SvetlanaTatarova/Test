using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.Models.InitializeDB;

namespace Test.Data.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly ApplicationContext Context;

        public CourseRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }
        
        
        public IEnumerable<Course> GetCourse => Context.Courses.OrderBy(p => p.CourseNumber);

        public Course GetOneCourse(int? id)
        {
            Course course = Context.Courses.FirstOrDefault(p => p.Id == id);
            return course;
        }
    }
}
