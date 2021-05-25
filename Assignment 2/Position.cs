using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public enum EmploymentLevel { A, B, C, D, E , NULL};

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
            string Title;
            switch (Level)
            {
                case EmploymentLevel.A:
                    Title = "Postdoc";
                    break;
                case EmploymentLevel.B:
                    Title = "Lecturer";
                    break;
                case EmploymentLevel.C:
                    Title = "Senior Lecturer";
                    break;
                case EmploymentLevel.D:
                    Title = "Associate Professor";
                    break;
                case EmploymentLevel.E:
                    Title = "Professor";
                    break;
                default:
                    Title = "No Title";
                    break;
            }

            return Title;
        }
    }
}
