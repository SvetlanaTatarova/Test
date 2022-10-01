using Microsoft.AspNetCore.Hosting;
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
    public class AcademicGroupRepository : IAcademicGroup
    {
        private readonly ApplicationContext Context;

        public AcademicGroupRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }

        public IEnumerable<AcademicGroup> GetAcademicGroup => Context.Groups;

        public AcademicGroup CreateGroup()
        {
            AcademicGroupViewModel addGroup = new()
            { 
                allSpecialities = Context.Specialities.ToList(),
                allCourses = Context.Courses.ToList(),
                allTeachers = Context.Teachers.ToList(),
                YearOfStudy = 2022
            };
            return addGroup;
        }

        public AcademicGroup CreateGroupPost(AcademicGroupViewModel _Group)
        {
            AcademicGroupViewModel Group = new()
            {
                Id = _Group.Id,
                Name = _Group.Name,
                ShortName = _Group.ShortName,
                YearOfStudy = _Group.YearOfStudy,
                CourseId = _Group.CourseId,
                SpecialityId = _Group.SpecialityId,
                CuratorId = _Group.CuratorId
            };
            Context.Groups.Add(Group);
            Context.SaveChanges();
            return Group;
        }

        

        public AcademicGroup Delete(int? id)
        {
            AcademicGroup Group = Context.Groups.FirstOrDefault(p => p.Id == id);
            if (Group != null)
            {
                // Удаление студентов, состоящих в группе
                foreach(Student student in Context.Students)
                {
                    if (student.GroupId == Group.Id)
                    {
                        Context.Students.Remove(student);
                    }
                }

                // Удаление самой группы
                Context.Groups.Remove(Group);
                Context.SaveChanges();
            }
            return Group;
        }

        public AcademicGroup EditGroup(int? id)
        {
            AcademicGroup Group = Context.Groups.FirstOrDefault(p => p.Id == id);

            AcademicGroupViewModel _Group = new()
            {
                Id = Group.Id,
                Name = Group.Name,
                ShortName = Group.ShortName,
                YearOfStudy = Group.YearOfStudy,
                CourseId = Group.CourseId,
                SpecialityId = Group.SpecialityId,
                CuratorId = Group.CuratorId,
                allCourses = Context.Courses.ToList(),
                allSpecialities = Context.Specialities.ToList(),
                allTeachers = Context.Teachers.ToList()
            };
            return _Group;
        }

        public AcademicGroup EditGroupPost(AcademicGroupViewModel _Group)
        {
            AcademicGroupViewModel Group = new()
            {
                Id = _Group.Id,
                Name = _Group.Name,
                ShortName = _Group.ShortName,
                YearOfStudy = _Group.YearOfStudy,
                CourseId = _Group.CourseId,
                SpecialityId = _Group.SpecialityId,
                CuratorId = _Group.CuratorId,
            };
            Context.Groups.Update(Group);
            Context.SaveChanges();
            return Group;
        }


        public AcademicGroup GetOneGroup(int? id)
        {
            AcademicGroup Group = Context.Groups.FirstOrDefault(p => p.Id == id);

            AcademicGroupViewModel _Group = new()
            {
                Id = Group.Id,
                Name = Group.Name,
                ShortName = Group.ShortName,
                YearOfStudy = Group.YearOfStudy,
                CourseId = Group.CourseId,
                SpecialityId = Group.SpecialityId,
                CuratorId = Group.CuratorId,
                allCourses = Context.Courses.ToList(),
                allSpecialities = Context.Specialities.ToList(),
                allTeachers = Context.Teachers.ToList(),
                allStudents = Context.Students.ToList()
            };
            return _Group;
        }
    }
}
