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
        private readonly ApplicationContext _context;

        public AcademicGroupRepository(ApplicationContext Context)
        {
            _context = Context;
        }

       // public IEnumerable<AcademicGroup> GetAcademicGroup => Context.Groups.OrderBy(p => p.ShortName);

        public IEnumerable<AcademicGroup> GetAcademicGroup()
        {
            int n = 0;
            foreach (AcademicGroup group in _context.Groups)
            { n++; }
            int i = 0;
            AcademicGroup[] academicGroup = new AcademicGroup[n];
            foreach (AcademicGroup group in _context.Groups.OrderBy(p => p.ShortName))
            {
                if (group != null)
                {
                    group.Speciality = _context.Specialities.FirstOrDefault(p => p.Id == group.SpecialityId);
                    //group.Specialities = Context.Specialities.ToList();
                    group.Course = _context.Courses.FirstOrDefault(p => p.Id == group.CourseId);
                    //group.Courses = Context.Courses.ToList();
                    group.Curator = _context.Teachers.FirstOrDefault(p => p.Id == group.CuratorId);
                    //group.Teachers = Context.Teachers.ToList();
                    //group.Students = Context.Students.ToList();
                    academicGroup[i] = group;
                    i++;
                }
            }
            
            return new List<AcademicGroup>(academicGroup);
        }


        public IEnumerable<AcademicGroup> GetAcademicGroupByTecherId(int id)
        {
            
            var groups = _context.Groups.Include(_=>_.Speciality).Include(_=>_.Course).Include(_=>_.Curator).Where(_=>_.CuratorId == id);
           
            return groups;
        }

        public AcademicGroup GetOneGroup(int? id)
        {
            AcademicGroup group = _context.Groups.FirstOrDefault(p => p.Id == id);
            group.Speciality = _context.Specialities.FirstOrDefault(p => p.Id == group.SpecialityId);
            group.Course = _context.Courses.FirstOrDefault(p => p.Id == group.CourseId);
            group.Curator = _context.Teachers.FirstOrDefault(p => p.Id == group.CuratorId);
            return group;
        }
        
        
        public AcademicGroup CreateGroupPost(AcademicGroup group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
            return group;
        }
        

        public AcademicGroup Delete(AcademicGroup group)
        {
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return group;
        }
        
        
        public AcademicGroup EditGroupPost(AcademicGroup group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
            return group;
        }

    }
}
