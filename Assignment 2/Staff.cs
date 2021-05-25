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
        public List<Student> Students { get; set; }
        // The Staff's phone number
        public int PhoneNumber { get; set; }
        // The Staff's room number
        public string Room { get; set; }
        // The Staff's category
        public string Category { get; set; }

        // Staff Constructor
        public Staff(int PhoneNumber, string Room, string Category) : base(0, Type.Staff, "", "", "", "", Campus.Hobart, "", "", "", 0, null, null)
        {
            this.PhoneNumber = PhoneNumber;
            this.Room = Room;
            this.Category = Category;
        }

        // The total number of publications in the last three years / 3
        public float ThreeYearAverage(List<Publication> Publications)
        {
            return Publications.Count / 3;
        }
        
        // The Researcher's ThreeYearAverage / expected number of Publications based on their EmploymentLevel
        public float Performance(List<Publication> Publications)
        {
            // The ThreeYearAverage of the Staff
            float TYA = ThreeYearAverage(Publications);
            // The EmploymentLevel of the Staff
            EmploymentLevel Level = GetCurrentJob().Level;
            // The expected number of Publications
            float ExpectedNumber = 0;

            // Determine the expected number of Publications based on the Staff's EmploymentLevel
            switch(Level)
            {
                case EmploymentLevel.A:
                    ExpectedNumber = 0.5F;
                    break;
                case EmploymentLevel.B:
                    ExpectedNumber = 1;
                    break;
                case EmploymentLevel.C:
                    ExpectedNumber = 2;
                    break;
                case EmploymentLevel.D:
                    ExpectedNumber = 3.2F;
                    break;
                case EmploymentLevel.E:
                    ExpectedNumber = 4;
                    break;
                default: 
                    ExpectedNumber = -1;
                    break;
            }

            // Return the Performance of the Staff
            return (TYA / ExpectedNumber);

        }
   
    }
}
