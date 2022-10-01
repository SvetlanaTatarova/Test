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

        public SpecialityRepository(ApplicationContext Context, IWebHostEnvironment HostEnvironment)
        {
            this.Context = Context;
        }
        public IEnumerable<Speciality> GetSpeciality => Context.Specialities;
    }
}
