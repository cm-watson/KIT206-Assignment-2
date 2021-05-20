using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A comment

namespace Assignment_2
{
    // The campus at which the Researcher attends
    public enum Campus { Hobart, Launceston, CradleCoast };

    public class Researcher
    {
        // The Researcher's private ID
        private int ID { get; set; }
        // The Researcher's first name
        public string GivenName { get; set; }
        // The Researcher's last name
        public string FamilyName { get; set; }
        // The Researcher's job title
        public string Title { get; set; }
        // The Researcher's school they work at
        public string School { get; set; }
        // The campus at which the Researcher works at
        public Campus Campus { get; set; }
        // The Researcher's email address
        public string Email { get; set; }
        // A link to a photo of the Researcher
        public URL Photo { get; set; }
        // A string containing the type of researcher. Either 'Staff' or 'Student'
        public string Type { get; set; }
        // A list of the Researcher's Publications
        public List<Publication> Publications;
        // The Researcher's Position
        public Position Position { get; set; }

        // Researcher Constructor
        public Researcher(int ID, string GivenName, string FamilyName, string Title, string School, Campus Campus, string Email, URL Photo, string Type, List<Publication> Publications, Position Position)
        {
            this.ID = ID;
            this.GivenName = GivenName;
            this.FamilyName = FamilyName;
            this.Title = Title;
            this.School = School;
            this.Campus = Campus;
            this.Email = Email;
            this.Photo = Photo;
            this.Type = Type;
            this.Publications = Publications;
            this.Position = Position;
        }

        // Return the current Position of the Researcher
        public Position GetCurrentJob => Position;

        // Return the current job title of the Researcher
        public string CurrentJobTitle => Position.Title();

        // Return the start date of the Researcher's current job
        public Date CurrentJobStart() => Position.Start;

        // Return the earliest job of the Researcher
        public Position GetEarliestJob()
        {
            // Find the job with the earliest start in database
            // Return corresponding job
        }

        // Return the start date of the Researcher's earliest job
        public Date EarliestStart()
        {
            // Find the earliest start in database
        }

        // Return the Researcher's tenure
        public float Tenure() {
            // Tenure is the time (in fractional years) since the Researcher commenced work
            
        }

        // Return the publication count of the Researcher
        public int PublicationsCount()
        {
            // The number of publications is the length of the Publiations array
            int PublicationCount = Publications.Count;
            return PublicationCount;
        }
    }
}