using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Data.Interfase
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourse { get; }
    }
}
