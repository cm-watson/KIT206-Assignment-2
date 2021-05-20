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
        // A list of authors that contributed to the Publication
        public List<string> Authors { get; set; }
        // The year the Publication was published
        public int Year { get; set; }
        // The type of publication the Publication is
        public Type OutputType { get; set; }
        // A string containing what the Publication should be cited as
        public string Cite { get; set; }
        // The year the Publication first became available
        public int DateAvailable { get; set; }
        // The time (in days elapsed) since the Publication became available
        public int Age { get; set; }

        // Publication Constructor
        public Publication(string doi, string title, int year, string cite, int date_available, int age)
        {
            this.DOI = doi;
            this.Title = title;
            this.Year = year;
            this.Cite = cite;
            this.DateAvailable = date_available;
            this.Age = age;
        }

        /* For testing
         *
        static void Main(string[] args)
        {

            Publication publication = new Publication("idk", "title", 2021, "idk", 21, 21);

            Console.WriteLine(publication);

        }
        */

        // Formats the year?
        static string FormatYear(int year, string title)
        {

        }

        // Sorts the Publications alphabetically
        static string SortAlphabetically(string title)
        {

        }
    }
}
