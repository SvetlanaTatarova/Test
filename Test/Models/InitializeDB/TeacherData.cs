using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public static class TeacherData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Teachers.Any())

            {
                context.Teachers.AddRange(
                     new Teacher
                     {
                         Name = "Иванов Иван Иванович",
                         PositionId = 2,
                         PhoneNumber = "0(775)00001",                        
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Иванова Ирина Ильинична",
                         PositionId = 3,
                         PhoneNumber = "0(775)00002",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Иванова Галина Ивановна",
                         PositionId = 2,
                         PhoneNumber = "0(775)00003",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Андреев Иван Иванович",
                         PositionId = 2,
                         PhoneNumber = "0(775)00004",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Андреева Ирина Семёновна",
                         PositionId = 2,
                         PhoneNumber = "0(775)00005",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Петров Сергей Михайлович",
                         PositionId = 3,
                         PhoneNumber = "0(775)00006",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Петрова Маргарита Алексеевна",
                         PositionId = 4,
                         PhoneNumber = "0(775)00007",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Васильев Иван Николаевич",
                         PositionId = 2,
                         PhoneNumber = "0(775)00008",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Васильева Анастасия Викторовна",
                         PositionId = 2,
                         PhoneNumber = "0(775)00009",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаев Дмитрий Сергеевич",
                         PositionId = 2,
                         PhoneNumber = "0(775)00010",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаев Олег Михайлович",
                         PositionId = 3,
                         PhoneNumber = "0(775)00011",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаева Олеся Владимировна",
                         PositionId = 4,
                         PhoneNumber = "0(775)00012",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаев Евгений Дмитриевич",
                         PositionId = 2,
                         PhoneNumber = "0(775)00013",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Руденко Матрена Ивановна",
                         PositionId = 1,
                         PhoneNumber = "0(775)00014",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Степанова Людмила Семёновна",
                         PositionId = 3,
                         PhoneNumber = "0(775)00015",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Степанов Максим Фёдорович",
                         PositionId = 2,
                         PhoneNumber = "0(775)00016",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Степанова Оксана Николаевна",
                         PositionId = 4,
                         PhoneNumber = "0(775)00017",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Яцко Иван Алексеевич",
                         PositionId = 2,
                         PhoneNumber = "0(775)00018",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Гущина Юлия Алексеевна",
                         PositionId = 2,
                         PhoneNumber = "0(775)00019",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Задорнов Михаил Николаевич",
                         PositionId = 1,
                         PhoneNumber = "0(775)00020",
                         Img = null
                     }
                    );
                context.SaveChanges();
            }
        }
    }
}
