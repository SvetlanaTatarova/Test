﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.ViewModels;

namespace Test.Data.Interfase
{
     public interface IAcademicGroup
    {
        IEnumerable<AcademicGroup> GetAcademicGroup { get; }

        AcademicGroup GetOneGroup(int? id);

        // Удаление группы
        AcademicGroup Delete(int? id);

        // Изменение группы
        AcademicGroup EditGroup(int? id);
        AcademicGroup EditGroupPost(AcademicGroupViewModel _Group);

        // Добавление группы
        AcademicGroup CreateGroup();
        AcademicGroup CreateGroupPost(AcademicGroupViewModel _Group);
    }
}
