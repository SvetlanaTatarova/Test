using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.ViewModels;

namespace Test.Data.Interfase
{
    public interface ITeacher
    {
        IEnumerable<Teacher> GetTeacher { get; }

        //IEnumerable<Teacher> GetTeacher();

        Teacher GetOneTeacher(int? id);

        // Удаление преподавателя
        Teacher Delete (Teacher teacher);

        // Изменение преподавателя
        Teacher EditTeacherPost(Teacher teacher, IFormFile photo);

        // Добавление преподавателя
        Teacher CreateTeacherPost(Teacher teacher, IFormFile photo);
    }
}
