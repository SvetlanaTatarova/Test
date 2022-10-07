using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public static class CourseData
    {
        public static void Initialize (ApplicationContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { CourseNumber = 1},
                    new Course { CourseNumber = 2},
                    new Course { CourseNumber = 3},
                    new Course { CourseNumber = 4}
                    );
                context.SaveChanges();
            }
        }
    }
}
