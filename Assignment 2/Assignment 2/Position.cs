using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public enum EmploymentLevel { Student, A, B, C, D, E };
    public class Position
    {
        public EmploymentLevel Level { get; set; }
        public Date Start { get; set; }
        public Date End { get; set; }

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
