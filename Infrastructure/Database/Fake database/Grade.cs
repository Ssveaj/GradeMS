﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Fake_database
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? StudentGrade {  get; set; }
    }
}
