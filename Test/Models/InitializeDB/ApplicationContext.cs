using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AcademicGroup> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }
    }
}
