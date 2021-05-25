using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public enum EmploymentLevel { A, B, C, D, E };

    public class Position
    {
        // The Researcher's Position's EmploymentLevel
        public EmploymentLevel Level { get; set; }

        // The starting date of the Researcher's Position
        public DateTime Start { get; set; }

        // The end date of the Researcher's Position
        public DateTime End { get; set; }

        // Position Constructor
        public Position(EmploymentLevel Level, DateTime Start, DateTime End) 
        {
            this.Level = Level;
            this.Start = Start;
            this.End = End;
        }
        
        // Return the EmploymentLevel (Student, A, B, etc) of the Position
        public string GetLevel()
        { 
            return "" + Level;
        }
        
        // Return the JobTitle (Postdoc, Lecturer, Prof, etc) of the Position
        public string GetJobTitle(EmploymentLevel Level)
        { 
            switch(Level)
            {
                case EmploymentLevel.A:
                    return "Postdoc";
                case EmploymentLevel.B:
                    return "Lecturer";
                case EmploymentLevel.C:
                    return "Senior Lecturer";
                case EmploymentLevel.D:
                    return "Associate Professor";
                case EmploymentLevel.E:
                    return "Professor";
                default:
                    return "No Title";
            }
        }
    }
}
