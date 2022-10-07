using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.InitializeDB
{
    public static class GroupData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Groups.Any())
            {
                context.Groups.AddRange(
                    new AcademicGroup
                    {
                        Name = "ФМ22ДР62МА",
                        ShortName = "102",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 1,
                        CuratorId = 1
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР62МА",
                        ShortName = "202",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 1,
                        CuratorId = 2
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ20ДР62МА",
                        ShortName = "302",
                        YearOfStudy = 2020,
                        CourseId = 3,
                        SpecialityId = 1,
                        CuratorId = 2
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ19ДР62МА",
                        ShortName = "402",
                        YearOfStudy = 2019,
                        CourseId = 4,
                        SpecialityId = 1,
                        CuratorId = 3
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР68МА",
                        ShortName = "502",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 2,
                        CuratorId = 4
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР68МА",
                        ShortName = "602",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 2,
                        CuratorId = 5
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР62ПФ",
                        ShortName = "103",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 3,
                        CuratorId = 6
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР62ПФ",
                        ShortName = "203",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 3,
                        CuratorId = 7
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ20ДР62ПФ",
                        ShortName = "303",
                        YearOfStudy = 2020,
                        CourseId = 3,
                        SpecialityId = 3,
                        CuratorId = 6
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ19ДР62ПФ",
                        ShortName = "403",
                        YearOfStudy = 2019,
                        CourseId = 4,
                        SpecialityId = 3,
                        CuratorId = 7
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР68ПФ",
                        ShortName = "503",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 4,
                        CuratorId = 8
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР68ПФ",
                        ShortName = "603",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 4,
                        CuratorId = 9
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР62ФИ",
                        ShortName = "107",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 5,
                        CuratorId = 10
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР62ФИ",
                        ShortName = "207",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 5,
                        CuratorId = 11
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ20ДР62ФИ",
                        ShortName = "307",
                        YearOfStudy = 2020,
                        CourseId = 3,
                        SpecialityId = 5,
                        CuratorId = 12
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ19ДР62ФИ",
                        ShortName = "407",
                        YearOfStudy = 2019,
                        CourseId = 4,
                        SpecialityId = 5,
                        CuratorId = 13
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР68ФИ",
                        ShortName = "507",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 6,
                        CuratorId = 14
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР68ФИ",
                        ShortName = "607",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 6,
                        CuratorId = 14
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР62МТ",
                        ShortName = "112",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 7,
                        CuratorId = 15
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР62МТ",
                        ShortName = "212",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 7,
                        CuratorId = 16
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ20ДР62МТ",
                        ShortName = "312",
                        YearOfStudy = 2020,
                        CourseId = 3,
                        SpecialityId = 7,
                        CuratorId = 17
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ19ДР62МТ",
                        ShortName = "412",
                        YearOfStudy = 2019,
                        CourseId = 4,
                        SpecialityId = 7,
                        CuratorId = 15
                    },

                    new AcademicGroup
                    {
                        Name = "ФМ22ДР68МТ",
                        ShortName = "512",
                        YearOfStudy = 2022,
                        CourseId = 1,
                        SpecialityId = 8,
                        CuratorId = 18
                    },
                    new AcademicGroup
                    {
                        Name = "ФМ21ДР68МТ",
                        ShortName = "612",
                        YearOfStudy = 2021,
                        CourseId = 2,
                        SpecialityId = 8,
                        CuratorId = 19
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
