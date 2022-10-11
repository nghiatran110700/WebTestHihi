using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Student
    {
        public Guid Id { get; set; } 

        public string Name { get; set; } = String.Empty;

        public bool IsGraduated { get; set; }

        public List<string> Courses { get; set; }

        public string Gender { get; set; } = String.Empty;

        public int Age { get; set; }
    }
}