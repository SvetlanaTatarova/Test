using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public static class SpecialityData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Specialities.Any())
            {
                context.Specialities.AddRange(
                    new Speciality { Name = "01.03.01 Математика. Вычислительная математика и информатика в сфере образования." },
                    new Speciality { Name = "01.04.01 Математика. Преподавание математики и информатики." },
                    new Speciality { Name = "01.03.02 Прикладная математика и информатика. Системное программирование и компьютерные технологии." },
                    new Speciality { Name = "01.04.02 Прикладная математика и информатика. Математические и информационные технологии." },
                    new Speciality { Name = "03.03.02 Физика. Физическое образование в школе." },
                    new Speciality { Name = "03.04.02 Физика. Физическое образование в школе." },
                    new Speciality { Name = "11.03.04 Электроника и наноэлектроника. Промышленная электроника." },
                    new Speciality { Name = "11.04.04 Электроника и наноэлектроника. Микроэлектроника и твердотельная электроника" }
                        );
                context.SaveChanges();
            }
        }
    }
}
