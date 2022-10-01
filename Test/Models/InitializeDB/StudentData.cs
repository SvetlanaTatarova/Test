using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public static class StudentData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                   new Student
                   {
                       Name = "Иванов Степан Федорович",
                       PhoneNumber = "0(777)00001",
                       Img = null,
                       GroupId = 1
                   },
                   new Student
                   {
                       Name = "Иванова Ирина Федоровна",
                       PhoneNumber = "0(777)00002",
                       Img = null,
                       GroupId = 1
                   },
                   new Student
                   {
                       Name = "Иванова Марина Федоровна",
                       PhoneNumber = "0(777)00003",
                       Img = null,
                       GroupId = 1
                   },
                   new Student
                   {
                       Name = "Иванов Дмитрий Андреевич",
                       PhoneNumber = "0(777)00004",
                       Img = null,
                       GroupId = 2
                   },
                   new Student
                   {
                       Name = "Иванова Татьяна Андреевна",
                       PhoneNumber = "0(777)00005",
                       Img = null,
                       GroupId = 2
                   },
                   new Student
                   {
                       Name = "Иванова Маргарита Андреевна",
                       PhoneNumber = "0(777)00006",
                       Img = null,
                       GroupId = 2
                   },
                   new Student
                   {
                       Name = "Иванов Максим Васильевич",
                       PhoneNumber = "0(777)00007",
                       Img = null,
                       GroupId = 3
                   },
                   new Student
                   {
                       Name = "Иванова Светлана Васильевна",
                       PhoneNumber = "0(777)00008",
                       Img = null,
                       GroupId = 3
                   },
                   new Student
                   {
                       Name = "Иванова Анна Васильевна",
                       PhoneNumber = "0(777)00009",
                       Img = null,
                       GroupId = 3
                   },
                   new Student
                   {
                       Name = "Иванов Николай Сергеевич",
                       PhoneNumber = "0(777)00010",
                       Img = null,
                       GroupId = 4
                   },
                   new Student
                   {
                       Name = "Иванова Галина Сергеевна",
                       PhoneNumber = "0(777)00011",
                       Img = null,
                       GroupId = 4
                   },
                   new Student
                   {
                       Name = "Иванова Юлия Сергеевна",
                       PhoneNumber = "0(777)00012",
                       Img = null,
                       GroupId = 4
                   },

                   new Student
                   {
                       Name = "Андреев Степан Федорович",
                       PhoneNumber = "0(777)00013",
                       Img = null,
                       GroupId = 5
                   },
                   new Student
                   {
                       Name = "Андреева Ирина Федоровна",
                       PhoneNumber = "0(777)00014",
                       Img = null,
                       GroupId = 5
                   },
                   new Student
                   {
                       Name = "Андреева Марина Федоровна",
                       PhoneNumber = "0(777)00015",
                       Img = null,
                       GroupId = 5
                   },
                   new Student
                   {
                       Name = "Андреев Дмитрий Андреевич",
                       PhoneNumber = "0(777)00016",
                       Img = null,
                       GroupId = 6
                   },
                   new Student
                   {
                       Name = "Андреева Татьяна Андреевна",
                       PhoneNumber = "0(777)00017",
                       Img = null,
                       GroupId = 6
                   },
                   new Student
                   {
                       Name = "Андреева Маргарита Андреевна",
                       PhoneNumber = "0(777)00018",
                       Img = null,
                       GroupId = 6
                   },

                   new Student
                   {
                       Name = "Петрова Юлия Анатольевна",
                       PhoneNumber = "0(777)00019",
                       Img = null,
                       GroupId = 7
                   },
                   new Student
                   {
                       Name = "Петров Денис Семёнович",
                       PhoneNumber = "0(777)00020",
                       Img = null,
                       GroupId = 7
                   },
                   new Student
                   {
                       Name = "Петрова Жанна Аркадьевна",
                       PhoneNumber = "0(777)00021",
                       Img = null,
                       GroupId = 7
                   },
                   new Student
                   {
                       Name = "Петрова Анна Сергеевна",
                       PhoneNumber = "0(777)00022",
                       Img = null,
                       GroupId = 8
                   },
                   new Student
                   {
                       Name = "Петров Анатолий Павлович",
                       PhoneNumber = "0(777)00023",
                       Img = null,
                       GroupId = 8
                   },
                   new Student
                   {
                       Name = "Петров Кирилл Валерьевич",
                       PhoneNumber = "0(777)00024",
                       Img = null,
                       GroupId = 8
                   },
                   new Student
                   {
                       Name = "Петров Алексей Дмитриевич",
                       PhoneNumber = "0(777)00025",
                       Img = null,
                       GroupId = 9
                   },
                   new Student
                   {
                       Name = "Петрова Татьяна Глебовна",
                       PhoneNumber = "0(777)00026",
                       Img = null,
                       GroupId = 9
                   },
                   new Student
                   {
                       Name = "Петров Максим Сергеевич",
                       PhoneNumber = "0(777)00027",
                       Img = null,
                       GroupId = 9
                   },
                   new Student
                   {
                       Name = "Петров Олег Дмитриевич",
                       PhoneNumber = "0(777)00028",
                       Img = null,
                       GroupId = 10
                   },
                   new Student
                   {
                       Name = "Петров Данила Олегович",
                       PhoneNumber = "0(777)00029",
                       Img = null,
                       GroupId = 10
                   },
                   new Student
                   {
                       Name = "Петров Александр Олегович",
                       PhoneNumber = "0(777)00030",
                       Img = null,
                       GroupId = 10
                   },

                   new Student
                   {
                       Name = "Васильев Александр Олегович",
                       PhoneNumber = "0(777)00031",
                       Img = null,
                       GroupId = 11
                   },
                   new Student
                   {
                       Name = "Васильева Анастасия Евгеньевна",
                       PhoneNumber = "0(777)00032",
                       Img = null,
                       GroupId = 11
                   },
                   new Student
                   {
                       Name = "Васильев Эдуард Иванович",
                       PhoneNumber = "0(777)00033",
                       Img = null,
                       GroupId = 11
                   },
                   new Student
                   {
                       Name = "Васильев Андрей Анатольевич",
                       PhoneNumber = "0(777)00034",
                       Img = null,
                       GroupId = 12
                   },
                   new Student
                   {
                       Name = "Васильев Константин Валерьевич",
                       PhoneNumber = "0(777)00035",
                       Img = null,
                       GroupId = 12
                   },
                   new Student
                   {
                       Name = "Васильев Даниил Николаевич",
                       PhoneNumber = "0(777)00036",
                       Img = null,
                       GroupId = 12
                   },

                   new Student
                   {
                       Name = "Николаев Степан Федорович",
                       PhoneNumber = "0(777)00037",
                       Img = null,
                       GroupId = 13
                   },
                   new Student
                   {
                       Name = "Николаева Ирина Федоровна",
                       PhoneNumber = "0(777)00038",
                       Img = null,
                       GroupId = 13
                   },
                   new Student
                   {
                       Name = "Николаева Марина Федоровна",
                       PhoneNumber = "0(777)00039",
                       Img = null,
                       GroupId = 13
                   },
                   new Student
                   {
                       Name = "Николаев Дмитрий Андреевич",
                       PhoneNumber = "0(777)00040",
                       Img = null,
                       GroupId = 14
                   },
                   new Student
                   {
                       Name = "Николаева Татьяна Андреевна",
                       PhoneNumber = "0(777)00041",
                       Img = null,
                       GroupId = 14
                   },
                   new Student
                   {
                       Name = "Николаева Маргарита Андреевна",
                       PhoneNumber = "0(777)00042",
                       Img = null,
                       GroupId = 14
                   },
                   new Student
                   {
                       Name = "Николаев Максим Васильевич",
                       PhoneNumber = "0(777)00043",
                       Img = null,
                       GroupId = 15
                   },
                   new Student
                   {
                       Name = "Николаева Светлана Васильевна",
                       PhoneNumber = "0(777)00044",
                       Img = null,
                       GroupId = 15
                   },
                   new Student
                   {
                       Name = "Николаева Анна Васильевна",
                       PhoneNumber = "0(777)00045",
                       Img = null,
                       GroupId = 15
                   },
                   new Student
                   {
                       Name = "Николаев Николай Сергеевич",
                       PhoneNumber = "0(777)00046",
                       Img = null,
                       GroupId = 16
                   },
                   new Student
                   {
                       Name = "Николаева Галина Сергеевна",
                       PhoneNumber = "0(777)00047",
                       Img = null,
                       GroupId = 16
                   },
                   new Student
                   {
                       Name = "Николаева Юлия Сергеевна",
                       PhoneNumber = "0(777)00048",
                       Img = null,
                       GroupId = 16
                   },

                   new Student
                   {
                       Name = "Руденко Александр Олегович",
                       PhoneNumber = "0(777)00049",
                       Img = null,
                       GroupId = 17
                   },
                   new Student
                   {
                       Name = "Руденко Анастасия Евгеньевна",
                       PhoneNumber = "0(777)00050",
                       Img = null,
                       GroupId = 17
                   },
                   new Student
                   {
                       Name = "Руденко Светлана Сергеевна",
                       PhoneNumber = "0(777)00051",
                       Img = null,
                       GroupId = 17
                   },
                   new Student
                   {
                       Name = "Руденко Вера Ивановна",
                       PhoneNumber = "0(777)00052",
                       Img = null,
                       GroupId = 18
                   },
                   new Student
                   {
                       Name = "Руденко Константин Валерьевич",
                       PhoneNumber = "0(777)00053",
                       Img = null,
                       GroupId = 18
                   },
                   new Student
                   {
                       Name = "Руденко Даниил Николаевич",
                       PhoneNumber = "0(777)00054",
                       Img = null,
                       GroupId = 18
                   },

                   new Student
                   {
                       Name = "Степанова Юлия Анатольевна",
                       PhoneNumber = "0(777)00055",
                       Img = null,
                       GroupId = 19
                   },
                   new Student
                   {
                       Name = "Степанов Денис Семёнович",
                       PhoneNumber = "0(777)00056",
                       Img = null,
                       GroupId = 19
                   },
                   new Student
                   {
                       Name = "Степанова Жанна Аркадьевна",
                       PhoneNumber = "0(777)00057",
                       Img = null,
                       GroupId = 19
                   },
                   new Student
                   {
                       Name = "Степанова Анна Сергеевна",
                       PhoneNumber = "0(777)00058",
                       Img = null,
                       GroupId = 20
                   },
                   new Student
                   {
                       Name = "Степанов Анатолий Павлович",
                       PhoneNumber = "0(777)00059",
                       Img = null,
                       GroupId = 20
                   },
                   new Student
                   {
                       Name = "Степанов Кирилл Валерьевич",
                       PhoneNumber = "0(777)00060",
                       Img = null,
                       GroupId = 20
                   },
                   new Student
                   {
                       Name = "Степанов Алексей Дмитриевич",
                       PhoneNumber = "0(777)0061",
                       Img = null,
                       GroupId = 21
                   },
                   new Student
                   {
                       Name = "Степанова Татьяна Глебовна",
                       PhoneNumber = "0(777)00062",
                       Img = null,
                       GroupId = 21
                   },
                   new Student
                   {
                       Name = "Степанов Максим Сергеевич",
                       PhoneNumber = "0(777)00063",
                       Img = null,
                       GroupId = 21
                   },
                   new Student
                   {
                       Name = "Степанов Олег Дмитриевич",
                       PhoneNumber = "0(777)00064",
                       Img = null,
                       GroupId = 22
                   },
                   new Student
                   {
                       Name = "Степанов Данила Олегович",
                       PhoneNumber = "0(777)00065",
                       Img = null,
                       GroupId = 22
                   },
                   new Student
                   {
                       Name = "Степанов Александр Олегович",
                       PhoneNumber = "0(777)00066",
                       Img = null,
                       GroupId = 22
                   },

                   new Student
                   {
                       Name = "Гущин Степан Федорович",
                       PhoneNumber = "0(777)00067",
                       Img = null,
                       GroupId = 23
                   },
                   new Student
                   {
                       Name = "Гущина Ирина Федоровна",
                       PhoneNumber = "0(777)00068",
                       Img = null,
                       GroupId = 23
                   },
                   new Student
                   {
                       Name = "Гущина Марина Федоровна",
                       PhoneNumber = "0(777)00069",
                       Img = null,
                       GroupId = 23
                   },
                   new Student
                   {
                       Name = "Гущин Дмитрий Андреевич",
                       PhoneNumber = "0(777)00070",
                       Img = null,
                       GroupId = 24
                   },
                   new Student
                   {
                       Name = "Гущина Татьяна Андреевна",
                       PhoneNumber = "0(777)00071",
                       Img = null,
                       GroupId = 24
                   },
                   new Student
                   {
                       Name = "Гущина Маргарита Андреевна",
                       PhoneNumber = "0(777)00072",
                       Img = null,
                       GroupId = 24
                   }
                    );
                context.SaveChanges();
            }
        }
    }
}
