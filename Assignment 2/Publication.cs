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
        public Publication(string DOI, string Title, List<Researcher> Authors, int Year, string Cite, DateTime DateAvailable, int Age)
        {
            this.DOI = DOI;
            this.Title = Title;
            this.Year = Year;
            this.Cite = Cite;
            this.DateAvailable = DateAvailable;
            this.Age = Age;
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

        /* TO BE REVIEWED
         *
        static void Main(string[] args)
        {

            Publication publication = new Publication("idk", "title", 2021, "idk", 21, 21);

            Console.WriteLine(publication);

        }

        // Formats the year
        static string FormatYear(int year, string title)
        {

        }

        // Sorts the Publications alphabetically
        static string SortAlphabetically(string title)
        {

        }
        */
    }
}
