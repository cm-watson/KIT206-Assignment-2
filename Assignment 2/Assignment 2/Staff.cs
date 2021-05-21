using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Staff:Researcher
    {
        // A list of Students the Staff supervises
        List<Student> Students { get; set; }

        // The total number of publications in the last three years / 3
        public float ThreeYearAverage(List<Publication> Publications)
        {
            return Publications.Count / 3;
        }
        
        // The Researcher's ThreeYearAverage / expected number of Publications based on their EmploymentLevel
        public float Performance(List<Publication> Publications)
        {
            // The ThreeYearAverage of the Staff
            float ThreeYearAverage = ThreeYearAverage(Publications);
            // The EmploymentLevel of the Staff
            Position.EmploymentLevel Level = GetCurrentJob().GetEmploymentLevel();
            // The expected number of Publications
            float ExpectedNumber = 0;

            // Determine the expected number of Publications based on the Staff's EmploymentLevel
            switch(Level)
            {
                case A:
                    ExpectedNumber = 0.5;
                    break;
                case B:
                    ExpectedNumber = 1;
                    break;
                case C:
                    ExpectedNumber = 2;
                    break;
                case D:
                    ExpectedNumber = 3.2;
                    break;
                case E:
                    ExpectedNumber = 4;
                    break;
                default: 
                    ExpectedNumber = -1;
                    break;
            }

            // Return the Performance of the Staff
            return (ThreeYearAverage / ExpectedNumber);

        }
    }
}
