using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Data.Interfase
{
    public interface IPosition
    {
        IEnumerable<Position> GetPositions { get; }

        Position GetOnePosition(int? id);
    }
}
