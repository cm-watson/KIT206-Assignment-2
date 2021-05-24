using System;
using System.Collections.Generic;

namespace Assignment_2
{

    public class ResearcherController2:ERDAdapter
    {
        // Return a list of Researchers with basic details
        public List<Researcher> LoadResearchers => FetchBasicResearcherDetails();

        // Complete the details of a Researcher
        public void LoadResearcherDetails(Researcher Researcher) => CompleteResearcherDetails(Researcher);

        // Filter the Researchers by EmploymentLevel
        public List<Researcher> FilterByLevel(List<Researcher> Researchers, EmploymentLevel Level)
        {
            // The filtered by level list
            List<Researcher> FilteredList = Researchers;

            // Remove all Researchers that don't have the correct EmploymentLevel
            for (int i = 0; i < FilteredList.Count; i++)
            {
                // If the Researcher doesn't have the correct EmploymentLevel...
                if(FilteredList.Get(i).GetEmploymentLevel() != Level)
                {
                    //... then remove them from the FilteredList
                    FilteredList.Remove(i);
                }
            }

            // Return the FilteredList of Researchers (by level)
            return FilteredList;

        }

        // Filter the Researchers by Name
        public List<Researcher> FilterByName(List<Researcher> Researchers, string Name)
        {
            // The filtered by name list
            List<Researcher> FilteredList = Researchers;

            // Remove all Researchers that don't have the correct Name
            for (int i = 0; i < FilteredList.Count; i++ )
            {
                string FirstName = FilteredList.Get(i).GivenName;
                string LastName = FilteredList.Get(i).FamilyName;

                // If the Researcher doesn't have the correct Name...
                if(!FirstName.Contains(Name) || !LastName.Contains(Name))
                {
                    //... then remove them from the FilteredList
                    FilteredList.Remove(i);
                }

            }

            // Return the FilteredList of Researchers (by name)
            return FilteredList;

        }

    }

}