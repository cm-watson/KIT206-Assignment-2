using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public enum Campus { Hobart, Launceston, CradleCoast };
    public enum JobTitle { PostDoc, Lecturer, SeniorLecturer, AssociateProf, Prof };

    public class Researcher
    {
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string title { get; set; }
        public string school { get; set; }
        public Campus campus { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public currentJobTitle JobTitle { get; set; }

        public List<Publication> publications;
        public Position position;

        public string getJobTitle
        {
            get
        }

        public string currentJobTitle
        {
            get { return "" + familyName + ", " + givenName + " (" + title + ")"; }
        }

        //The SkillCount out of 10, expressed as a percentage
        public double SkillPercent
        {
            //This is equivalent to SkillCount / 10.0 * 100
            get { return SkillCount * 10.0; }
        }

        //This is likely the solution you will have devised
        public DateTime MostRecentTraining
        {
            get
            {
                var skillDates = from TrainingSession s in Skills
                                 orderby s.Certified descending
                                 select s.Certified;
                return skillDates.First();
            }
        }

        //This is a more robust implementation, but requires the the return type be made 'nullable'
        //        public DateTime? MostRecentTraining
        //        {
        //            get
        //            {
        //                if (SkillCount > 0)
        //                {
        //                    var skillDates = from TrainingSession s in Skills
        //                                     orderby s.Certified descending
        //                                     select s.Certified;
        //                    return skillDates.First();
        //                }
        //                return null;
        //            }
        //        }

        public override string ToString()
        {
            //For the purposes of this week's demonstration this returns only the name
            return Name;
        }
    }
}