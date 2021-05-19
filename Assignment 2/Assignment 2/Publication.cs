using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public enum OutputType { Conference, Journal, Other };
    public class Publication
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public Type OutputType { get; set; }
        public string Cite { get; set; }
        public int DateAvailable { get; set; }
        public int Age { get; set; }

        // string DOI {
        //     get { return doi; }
        //     set { doi = value; }
        // }



        public Publication(string doi, string title, int year, string cite, int date_available, int age)
        {
            this.DOI = doi;
            this.Title = title;
            this.Year = year;
            this.Cite = cite;
            this.DateAvailable = date_available;
            this.Age = age;
        }

        static void Main(string[] args)
        {

            Publication publication = new Publication("idk", "title", 2021, "idk", 21, 21);

            Console.WriteLine(publication);

        }

        static string FormatYear(int year, string title)
        {

        }

        static string SortAlphabetically(string title)
        {

        }
    }
}
