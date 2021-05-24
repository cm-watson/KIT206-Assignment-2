using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    // The type of publication the Publication is
    public enum OutputType { Conference, Journal, Other };

    public class Publication
    {
        // A digital object identifier for the Publication
        public string DOI { get; set; }
        // The title of the Publication
        public string Title { get; set; }
        // A list of author names that contributed to the Publication
        public String Authors { get; set; }
        // The year the Publication was published
        public int Year { get; set; }
        // The type of publication the Publication is
        public OutputType Type { get; set; }
        // A string containing what the Publication should be cited as
        public string Cite { get; set; }
        // The year the Publication first became available
        public DateTime DateAvailable { get; set; }

        // Publication Constructor
        public Publication(string DOI, string Title, List<Researcher> Authors, int Year, string Cite, DateTime DateAvailable)
        {
            this.DOI = DOI;
            this.Title = Title;
            this.Year = Year;
            this.Cite = Cite;
            this.DateAvailable = DateAvailable;
        }

        // Returns the Age of the Publication
        public int Age()
        {
            // The current date
            DateTime CurrentDate = DateTime.Now;

            // The time since the Publication became available
            TimeSpan Difference = CurrentDate.Subtract(DateAvailable);

            // Return the days elapsed since the Publication became available
            return Difference.Days;
        }

    }

}
