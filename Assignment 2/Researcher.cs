using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; // For Description of enum

namespace Assignment_2
{
    // The campus at which the Researcher attends
    public enum Campus { Hobart, Launceston, [Description("Cradle Coast")] Cradle_Coast };

    // The Type that a researcher is
    public enum Type { Staff, Student };

    public class Researcher
    {
        // The Researcher's private ID
        public int ID { get; set; }

        // The type of researcher. Either 'Staff' or 'Student'.
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
        public Researcher(int ID, Type ResearcherType, string GivenName, string FamilyName,
            string Title, string Unit, Campus Campus, string Email, string Photo,
            string Degree, int SupervisorID, List<Publication> Publications, List<Position> Positions)
        {
            this.ID = ID;
            this.CurrentType = ResearcherType;
            this.GivenName = GivenName;
            this.FamilyName = FamilyName;
            this.Title = Title;
            this.Unit = Unit;
            this.CurrentCampus = Campus;
            this.Email = Email;
            this.Photo = Photo;
            this.Degree = Degree;
            this.SupervisorID = SupervisorID;
            this.Publications = Publications;
            this.Positions = Positions;
        }

        // Return the current Position of the Researcher
        public Position GetCurrentJob()
        {
        	Position P = new Position(EmploymentLevel.A, DateTime.Now, DateTime.Now);  // placeholder Position
            int i = 0;  // incremental value

            // Look through List until you find the Position with end date DateTime.MinValue
            // This means that the Position is the Researcher's current Position
            while(Positions[i].End != DateTime.MinValue )
            {
                P = Positions[i];
                i++;
            }

            return P;
        }

        // Return the current job title of the Researcher
        public string CurrentJobTitle => GetCurrentJob().GetJobTitle(Positions[0].Level);

        // Return the start date of the Researcher's current job
        public DateTime CurrentJobStart => GetCurrentJob().Start;

        // Return the earliest job of the Researcher
        public Position EarliestJob()
        {
            Position EarliestJob = Positions[0]; // return value

            for(int i = 0; i < Positions.Count; i++)
            {
                Position Temp = Positions[i]; // temporary Position

                // If the temporary Position has an earlier starting date
                if(DateTime.Compare(Temp.Start, EarliestJob.Start) < 0)
                {
                    // Replace the earliest job with the temporary Position
                    EarliestJob = Temp;
                }
            }

            // Return the Earliest Job in the List
            return EarliestJob;
        }

        // Return the start date of the Researcher's earliest job
        public DateTime EarliestStart => EarliestJob().Start;

        // Return the Researcher's tenure
        // Tenure is the time (in fractional years) since the Researcher commenced work
        public float Tenure()
        {
            // The date the Researchers commenced work
            DateTime Start = EarliestStart;
            // The current date and time
            DateTime CurrentDate = DateTime.Now;

            // The time in days, hours, and minutes since the Researcher commenced work
            TimeSpan Difference = CurrentDate.Subtract(Start);

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