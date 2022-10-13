using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.ViewModels;

namespace Test.Data.Interfase
{
    public interface IStudent
    {
        //IEnumerable<Student> GetStudent { get; }

        IEnumerable<Student> GetStudent();

        Student GetOneStudent(int? id);

        // Удаление студента
        Student Delete(Student student);

        //Удаление студента с группой
        Student DeleteWithGroup(Student student);

        // Изменение студента
        Student EditStudentPost(Student student, IFormFile photo);

        // Добавление студента
        Student CreateStudentPost(Student student, IFormFile photo);

    }
}
