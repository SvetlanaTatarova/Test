using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public static class PositionData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Positions.Any())
            {
                context.Positions.AddRange(
                    new Position { Name = "Преподаватель" },
                    new Position { Name = "Старший преподаватель" },
                    new Position { Name = "Доцент" },
                    new Position { Name = "Профессор" }
                    );
                context.SaveChanges();
            }
        }
    }
}
