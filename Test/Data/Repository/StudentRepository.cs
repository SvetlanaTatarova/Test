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
    public class StudentRepository : IStudent
    {
        private readonly ApplicationContext Context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public StudentRepository(ApplicationContext Context, IWebHostEnvironment hostingEnvironment)
        {
            this.Context = Context;
            this.hostingEnvironment = hostingEnvironment;
        }


        //public IEnumerable<Student> GetStudent => Context.Students.OrderBy(p => p.Name);

        public IEnumerable<Student> GetStudent()
        {
            int n = 0;
            foreach (Student student in Context.Students)
            { n++; }
            int i = 0;
            Student[] students = new Student[n];
            foreach (Student student in Context.Students.OrderBy(p => p.Name))
            {
                if (student != null)
                {
                    student.Group = Context.Groups.FirstOrDefault(p => p.Id == student.GroupId);
                    students[i] = student;
                    i++;
                }
            }

            return new List<Student>(students);
        }


        public Student GetOneStudent(int? id)
        {
            Student student = Context.Students.FirstOrDefault(p => p.Id == id);
            student.Group = Context.Groups.FirstOrDefault(p => p.Id == student.GroupId);
            return student;
        }
        

        public Student CreateStudentPost(Student student, IFormFile photo)
        {
            if (photo != null)
            {
                string filePath = $@"{hostingEnvironment.WebRootPath}\img\{photo.FileName}";
                using (FileStream fs = File.Create(filePath))
                {
                    photo.CopyTo(fs);
                    fs.Flush();
                }
                student.Img = "/img/" + photo.FileName;
            };
            Context.Students.Add(student);
            Context.SaveChanges();
            return student;
        }


        public Student Delete(Student student)
        {
            Context.Students.Remove(student);
            Context.SaveChanges();
            return student;
        }


        public Student DeleteWithGroup(Student student)
        {
            Context.Students.Remove(student);
            return student;
        }
        
        
        public Student EditStudentPost(Student student, IFormFile photo)
        {
            if (photo != null)
            {
                string filePath = $@"{hostingEnvironment.WebRootPath}\img\{photo.FileName}";
                using (FileStream fs = File.Create(filePath))
                {
                    photo.CopyTo(fs);
                    fs.Flush();
                }
                student.Img = "/img/" + photo.FileName;
            }
            Context.Students.Update(student);
            Context.SaveChanges();
            return student;
        }
    }
}
