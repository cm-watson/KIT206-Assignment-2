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
        private int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public Campus Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public List<Publication> Publications;
        public Position Position { get; set; }

        public Position GetCurrentJob => Position;

        public string CurrentJobTitle => Position.Title();
        /*
        public string CurrentJobTitle
        {
            get { return "" + FamilyName + ", " + GivenName + " (" + Title + ")"; }
        }
        */

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