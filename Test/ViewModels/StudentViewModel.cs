﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class StudentViewModel: Student
    {
        public List<AcademicGroup> allGroups { get; set; }
        public IFormFile Photo { get; set; }
    }
}
