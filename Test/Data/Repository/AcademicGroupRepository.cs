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

        public IEnumerable<AcademicGroup> GetAcademicGroup ()
        {
            return Context.Groups.OrderBy(p => p.ShortName);
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
