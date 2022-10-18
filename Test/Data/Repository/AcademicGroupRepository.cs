using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<AcademicGroup> GetAcademicGroup => Context.Groups.OrderBy(p => p.ShortName);
        
        
        public IEnumerable<AcademicGroup> GetAcademicGroupByTecherId(int id)
        {
            
            var groups = Context.Groups.Include(_=>_.Speciality).Include(_=>_.Course).Include(_=>_.Curator).Where(_=>_.CuratorId == id);
           
            return groups.OrderBy(p => p.ShortName);
        }

        public IEnumerable<AcademicGroup> GetAcademicGroupBySpecialityId(int id)
        {
            var groups = Context.Groups.Include(_ => _.Speciality).Include(_ => _.Curator).Include(_ => _.Course).Where(_ => _.SpecialityId == id);

            return groups.OrderBy(p => p.ShortName);
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
