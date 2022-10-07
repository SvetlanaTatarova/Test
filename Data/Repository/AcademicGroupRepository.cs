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

        public IEnumerable<AcademicGroupViewModel> GetAcademicGroup()
        {
            //int n = Context.Groups.OrderBy(p => p.Id).Last().Id;
            int n = 0;
            foreach(AcademicGroup group in Context.Groups)
            { n++; }
            int i = 0;
            AcademicGroupViewModel[] academicGroupViews = new AcademicGroupViewModel[n];
            foreach (AcademicGroup group in Context.Groups.OrderBy(p => p.ShortName))
            {
                var groupViewModel = new AcademicGroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    ShortName = group.ShortName,
                    YearOfStudy = group.YearOfStudy,
                    SpecialityId = group.SpecialityId,
                    allSpecialities = Context.Specialities.ToList(),
                    CourseId = group.CourseId,
                    allCourses = Context.Courses.ToList(),
                    CuratorId = group.CuratorId,
                    allTeachers = Context.Teachers.ToList(),
                    allStudents = Context.Students.ToList()
                };
                if (groupViewModel != null)
                {
                    academicGroupViews[i] = groupViewModel;
                    i++;
                }
            }
           // AcademicGroupViewModel[] academicGroupViews1 = new AcademicGroupViewModel[n];
            return new List<AcademicGroupViewModel>(academicGroupViews);
            //return Context.Groups;
            
        }
        
        
        public AcademicGroup GetOneGroup(int? id)
        {
            AcademicGroup group = Context.Groups.FirstOrDefault(p => p.Id == id);
            return group;
        }
        
        
        public AcademicGroup CreateGroupPost(AcademicGroup group)
        {
            Context.Groups.Add(group);
            Context.SaveChanges();
            return group;
        }
        

        public AcademicGroup Delete(AcademicGroup group)
        {
            Context.Groups.Remove(group);
            Context.SaveChanges();
            return group;
        }
        
        
        public AcademicGroup EditGroupPost(AcademicGroup group)
        {
            Context.Groups.Update(group);
            Context.SaveChanges();
            return group;
        }

    }
}
