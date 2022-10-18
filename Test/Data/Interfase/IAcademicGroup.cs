using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.ViewModels;

namespace Test.Data.Interfase
{
     public interface IAcademicGroup
    {
       // IEnumerable<AcademicGroup> GetAcademicGroup { get; }

        IEnumerable<AcademicGroup> GetAcademicGroup();

        IEnumerable<AcademicGroup> GetAcademicGroupByTecherId(int id);

        AcademicGroup GetOneGroup(int? id);

        // Удаление группы
        AcademicGroup Delete(AcademicGroup group);

        // Изменение группы
        //AcademicGroup EditGroup(int? id);
        AcademicGroup EditGroupPost(AcademicGroup _Group);

        // Добавление группы
       // AcademicGroup CreateGroup();
        AcademicGroup CreateGroupPost(AcademicGroup group);
    }
}
