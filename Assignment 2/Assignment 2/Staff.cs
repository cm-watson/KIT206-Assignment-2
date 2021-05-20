using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Staff
    {
        // The total number of publications in the last three years / 3
        public float ThreeYearAverage(List<Publication> Publications)
        {
            return Publications.Count / 3;
        }
        // The Researcher's ThreeYearAverage / expected number of Publications based on their EmploymentLevel
        public float Performance(List<Publication> Publications)
        {
            float ThreeYearAverage = ThreeYearAverage(Publications);
            // ..... //
        }
    }
}
