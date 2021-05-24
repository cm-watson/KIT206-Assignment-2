using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    // The campus at which the Researcher attends
    public enum Campus { Hobart, Launceston, CradleCoast };

    public class Researcher
    {
        // The Researcher's private ID
        private int ID { get; set; }

        // A string containing the type of researcher. Either 'Staff' or 'Student'.
        public Type CurrentType { get; set; }

        // The Researcher's first name
        public string GivenName { get; set; }

        // The Researcher's last name
        public string FamilyName { get; set; }

        // The Researcher's job title
        public string Title { get; set; }

        // The Researcher's school they work at
        public string Unit { get; set; }

        // The campus at which the Researcher works at
        public Campus CurrentCampus { get; set; }

        // The Researcher's email address
        public string Email { get; set; }

        // A link to a photo of the Researcher
        public string Photo { get; set; }

        // The Degree the Researcher is studying
        public string Degree { get; set; }

        // The Researcher's supervisor's ID
        public int SupervisorID { get; set; }

        // A list of the Researcher's Publications
        public List<Publication> Publications { get; set; }

        // A list of the Researcher's Positions
        public List<Position> Positions { get; set; }


        // Researcher Constructor
        public Researcher(int ID, Type RType, string GivenName, string FamilyName, string Title, string School, Campus Campus, string Email, string Photo, string Type, List<Publication> Publications, List<Position> Positions)
        {
            this.ID = ID;
            this.GivenName = GivenName;
            this.FamilyName = FamilyName;
            this.Title = Title;
            this.Unit = School;
            this.CurrentCampus = Campus;
            this.Email = Email;
            this.Photo = Photo;
            this.CurrentType = RType;
            this.Publications = Publications;
            this.Positions = Positions;
        }

        // Return the current Position of the Researcher
        public Position GetCurrentJob()
        {
            Position Position;  // placeholder Position
            int i = 0;  // incremental value

            // Look through List until you find the Position with end date NULL
            // This means that the Position is the Researcher's current Position
            while(Positions[i].End != NULL)
            {
                Position = Positions[i];
                i++;
            }
    
            return Position;
        }

        // Return the current job title of the Researcher
        public string CurrentJobTitle => GetCurrentJob().GetJobTitle();

        // Return the start date of the Researcher's current job
        public DateTime CurrentJobStart => GetCurrentJob().Start;

        // Return the earliest job of the Researcher
        public Position GetEarliestJob()
        {
            Position EarliestJob = Positions[0]; // return value

            for(int i=0; i<Positions.Count; i++)
            {
                Position Temp = Positions[i]; // temporary Position
                
                // If the temporary Position has an earlier starting date
                if(DateTime.LessThan(Temp.Start, EarliestJob.Start))
                {
                    // Replace the earliest job with the temporary Position
                    EarliestJob = Temp;
                }
            }

            // Return the Earliest Job in the List
            return EarliestJob;
        }

        // Return the start date of the Researcher's earliest job
        public DateTime EarliestStart => GetEarliestJob().Start;

        // Return the Researcher's tenure
        // Tenure is the time (in fractional years) since the Researcher commenced work
        public float Tenure() {
            // The date the Researchers commenced work
            DateTime EarliestStart = GetEarliestStart();
            // The current date and time
            DateTime CurrentDate = DateTime.Now;

            // The time in days, hours, and minutes since the Researcher commenced work
            TimeSpan Difference = CurrentDate.Subtract(EarliestStart);

            // Return the time (in fractional years) since the Researcher commenced work
            return Difference.Days / (float)365.0;
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