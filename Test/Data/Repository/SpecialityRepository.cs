using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.Models.InitializeDB;

namespace Test.Data.Repository
{
    public class SpecialityRepository : ISpeciality
    {
        private readonly ApplicationContext Context;

        public SpecialityRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }


        public IEnumerable<Speciality> GetSpeciality => Context.Specialities.OrderBy(p => p.Name);

        public Speciality GetOneSpeciality(int? id)
        {
            Speciality speciality = Context.Specialities.FirstOrDefault(p => p.Id == id);
            return speciality;
        }
    }
}
