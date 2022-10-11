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

       // public IEnumerable<AcademicGroup> GetAcademicGroup => Context.Groups.OrderBy(p => p.ShortName);

        public IEnumerable<AcademicGroup> GetAcademicGroup()
        {
            //int n = Context.Groups.OrderBy(p => p.Id).Last().Id;
            int n = 0;
            foreach (AcademicGroup group in Context.Groups)
            { n++; }
            int i = 0;
            AcademicGroup[] academicGroup = new AcademicGroup[n];
            foreach (AcademicGroup group in Context.Groups.OrderBy(p => p.ShortName))
            {
                if (group != null)
                {
                    group.Speciality = Context.Specialities.FirstOrDefault(p => p.Id == group.SpecialityId);
                    group.Course = Context.Courses.FirstOrDefault(p => p.Id == group.CourseId);
                    group.Curator = Context.Teachers.FirstOrDefault(p => p.Id == group.CuratorId);
                    academicGroup[i] = group;
                    i++;
                }
            }
            
            return new List<AcademicGroup>(academicGroup);
        }


        public AcademicGroup GetOneGroup(int? id)
        {
            AcademicGroup group = Context.Groups.FirstOrDefault(p => p.Id == id);
            group.Speciality = Context.Specialities.FirstOrDefault(p => p.Id == group.SpecialityId);
            group.Course = Context.Courses.FirstOrDefault(p => p.Id == group.CourseId);
            group.Curator = Context.Teachers.FirstOrDefault(p => p.Id == group.CuratorId);
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
