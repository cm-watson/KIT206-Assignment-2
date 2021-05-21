using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public enum EmploymentLevel { Student, A, B, C, D, E };

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
        public string GetEmploymentLevel()
        { 
            return "" + Level;
        }
        
        // Return the JobTitle (Postdoc, Lecturer, Prof, etc) of the Position
        public string GetJobTitle(EmploymentLevel l)
        { 
            switch(l)
            {
                case A:
                    return "Postdoc";
                    break;
                case B:
                    return "Lecturer";
                    break;
                case C:
                    return "Senior Lecturer";
                    break;
                case D:
                    return "Associate Professor";
                    break;
                case E:
                    return "Professor";
                    break;
                default:
                    return "No Title";
                    break;
            }
        }
    }
}
