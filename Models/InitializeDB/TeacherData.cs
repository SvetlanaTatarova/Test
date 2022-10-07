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
                         Position = "Преподаватель",
                         PhoneNumber = "0(775)00001",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Иванова Ирина Ильинична",
                         Position = "Старший преподаватель",
                         PhoneNumber = "0(775)00002",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Иванова Галина Ивановна",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00003",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Андреев Иван Иванович",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00004",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Андреева Ирина Семёновна",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00005",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Петров Сергей Михайлович",
                         Position = "Старший преподаватель",
                         PhoneNumber = "0(775)00006",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Петрова Маргарита Алексеевна",
                         Position = "Преподаватель",
                         PhoneNumber = "0(775)00007",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Васильев Иван Николаевич",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00008",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Васильева Анастасия Викторовна",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00009",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаев Дмитрий Сергеевич",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00010",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаев Олег Михайлович",
                         Position = "Старший преподаватель",
                         PhoneNumber = "0(775)00011",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаева Олеся Владимировна",
                         Position = "Преподаватель",
                         PhoneNumber = "0(775)00012",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Николаев Евгений Дмитриевич",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00013",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Руденко Матрена Ивановна",
                         Position = "Профессор",
                         PhoneNumber = "0(775)00014",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Степанова Людмила Семёновна",
                         Position = "Старший преподаватель",
                         PhoneNumber = "0(775)00015",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Степанов Максим Фёдорович",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00016",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Степанова Оксана Николаевна",
                         Position = "Преподаватель",
                         PhoneNumber = "0(775)00017",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Яцко Иван Алексеевич",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00018",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Гущина Юлия Алексеевна",
                         Position = "Доцент",
                         PhoneNumber = "0(775)00019",
                         Img = null
                     },
                     new Teacher
                     {
                         Name = "Задорнов Михаил Николаевич",
                         Position = "Профессор",
                         PhoneNumber = "0(775)00020",
                         Img = null
                     }
                    );
                context.SaveChanges();
            }
        }
    }
}
