using System;
using System.Collections.Generic;

namespace Assignment_2
{

    public class ResearcherController
    {
        // Return a list of Researchers with basic details
        public List<Researcher> LoadResearchers => ERDAdapter.FetchBasicResearcherDetails();

        // Complete the details of a Researcher
        public Researcher LoadResearcherDetails(Researcher Researcher) => ERDAdapter.CompleteResearcherDetails(Researcher);

        // Filter the Researchers by EmploymentLevel
        public List<Researcher> FilterByLevel(List<Researcher> Researchers, EmploymentLevel Level)
        {
            // The filtered by level list
            List<Researcher> FilteredList = new List<Researcher>();

            // Add all Researchers that have the correct EmploymentLevel
            for (int i = 0; i < Researchers.Count; i++)
            {
                // If the Researcher has the correct EmploymentLevel...
                if (Researchers[i].Positions[0].Level == Level)
                {
                    //... then add them to the FilteredList
                    FilteredList.Add(Researchers[i]);
                } 
            }

            // Return the FilteredList of Researchers (by level)
            return FilteredList;

        }

        // Filter the Researchers by Name
        public List<Researcher> FilterByName(List<Researcher> Researchers, string Name)
        {
            // The filtered by name list
            List<Researcher> FilteredList = new List<Researcher>();

            // Remove all Researchers that don't have the correct Name
            for (int i = 0; i < Researchers.Count; i++ )
            {
                string FirstName = Researchers[i].GivenName;
                string LastName = Researchers[i].FamilyName;

                // If the Researcher doesn't have the correct Name...
                if(FirstName.IndexOf( Name, 0, Name.Length ) != 0 || LastName.IndexOf( Name, 0, Name.Length ) != 0 )
                {
                    //... then remove them from the FilteredList
                    FilteredList.Add( Researchers[i] );
                }

            }

            // Return the FilteredList of Researchers (by name)
            return FilteredList;

        }

    }

}
