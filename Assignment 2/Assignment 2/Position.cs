using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public enum EmploymentLevel { Student, A, B, C, D, E };
    public class Position
    {
        public EmploymentLevel level { get; set; }
        public Date start { get; set; }
        public Date end { get; set; }

        public string Title()
        {
            return;
        }

        public string ToTitle(EmploymentLevel l)
        {
            return;
        }
    }
}
