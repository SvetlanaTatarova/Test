using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.Models.InitializeDB;
using Test.ViewModels;

namespace Test.Data.Repository
{
    public class TeacherRepository : ITeacher
    {
        private readonly ApplicationContext Context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public TeacherRepository(ApplicationContext Context, IWebHostEnvironment hostingEnvironment)
        {
            this.Context = Context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<Teacher> GetTeacher => Context.Teachers.OrderBy(p => p.Name);


        public Teacher GetOneTeacher(int? id)
        {
            Teacher teacher = Context.Teachers.FirstOrDefault(p => p.Id == id);
            return teacher;
        }


        public Teacher CreateTeacherPost(Teacher teacher, IFormFile photo)
        {
            if (photo != null)
            {
                string filePath = $@"{hostingEnvironment.WebRootPath}\img\{photo.FileName}";
                using (FileStream fs = File.Create(filePath))
                {
                    photo.CopyTo(fs);
                    fs.Flush();
                }
                teacher.Img = "/img/" + photo.FileName;
            };
            Context.Teachers.Add(teacher);
            Context.SaveChanges();
            return teacher;           
        }


        public Teacher Delete(Teacher teacher)
        {
            Context.Teachers.Remove(teacher);
            Context.SaveChanges();
            return teacher;
        }


        public Teacher EditTeacherPost(Teacher teacher, IFormFile photo)
        {
            if (photo != null)
            {
                string filePath = $@"{hostingEnvironment.WebRootPath}\img\{photo.FileName}";
                using (FileStream fs = File.Create(filePath))
                {
                    photo.CopyTo(fs);
                    fs.Flush();
                }
                teacher.Img = "/img/" + photo.FileName;
            }
            Context.Teachers.Update(teacher);
            Context.SaveChanges();
            return teacher;
        }
    }
}
