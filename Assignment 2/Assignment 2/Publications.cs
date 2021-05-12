using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Publications
    {
        string doi;
        string title;
        List<authors> authors;
        int year;
        type type;
        string cite;
        int date_available;
        int age;

        // string DOI {
        //     get { return doi; }
        //     set { doi = value; }
        // }



        public Publications(string doi, string title, int year, string cite, int date_available, int age)
        {
            this.doi = doi;
            this.title = title;
            this.year = year;
            this.cite = cite;
            this.date_available = date_available;
            this.age = age;
        }

        static void Main(string[] args)
        {

            Publications publication = new Publications("idk", "title", 2021, "idk", 21, 21);

            Console.WriteLine(publication);

        }

        static string formatYear(int year, string title)
        {

        }

        static string sortAlphabetically(string title)
        {

        }
    }
}
