using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public enum EmploymentLevel { Student, A, B, C, D, E };
    public class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Return the JobTitle (Postdoc,Lecturer,Prof) of the Position
        public string Title()
        {
                        
        }

        // Return the EmploymentLevel (A,B,C...) of the Position
        public string ToTitle(EmploymentLevel l)
        { 

        }
    }
}
