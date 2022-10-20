using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfase;
using Test.Models;
using Test.Models.InitializeDB;

namespace Test.Data.Repository
{
    public class PositionRepository : IPosition
    {
        private readonly ApplicationContext Context;

        public PositionRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }
        public IEnumerable<Position> GetPositions => Context.Positions.OrderBy(p => p.Name);

        public Position GetOnePosition(int? id)
        {
            Position position = Context.Positions.FirstOrDefault(p => p.Id == id);
            return position;
        }
    }
}
