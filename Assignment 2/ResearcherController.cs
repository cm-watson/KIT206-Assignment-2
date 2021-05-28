using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assignment_2
{

    public class ResearcherController
    {
        // The main list of all Researchers
        private List<Researcher> MasterResearchers;
        // The list of Researchers shown in the UI
        private ObservableCollection<Researcher> ViewableResearchers;

        // ResearcherController constructor
        public ResearcherController()
        {
            // Fill List with Researchers
            MasterResearchers = LoadResearchers;
            // Fill ObservableCollection with Researchers in MasterResearchers
            ViewableResearchers = MakeObservable( MasterResearchers );
        }

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
            for (int i = 0; i < Researchers.Count; i++)
            {
                string FirstName = Researchers[i].GivenName;
                string LastName = Researchers[i].FamilyName;

                // If the Researcher doesn't have the correct Name...
                if (FirstName.IndexOf(Name) >= 0 || LastName.IndexOf(Name) >= 0)
                {
                    //... then remove them from the FilteredList
                    FilteredList.Add(Researchers[i]);
                }

            }

            // Return the FilteredList of Researchers (by name)
            return FilteredList;

        }
    
        // Convert the parsed List<Researcher> into an ObservableCollection<Researcher> 
        public ObservableCollection<Researcher> MakeObservable( List<Researcher> Researchers)
        {
            ObservableCollection<Researcher> ShownResearchers = new ObservableCollection<Researcher>();
            for ( int i = 0; i < Researchers.Count; i++ )
            {
                // Add each Researcher in Researchers to ShownResearchers
                ShownResearchers.Add( Researchers[i] );
            }
            return ShownResearchers;
        }
    
        // Return the ViewableResearchers ObservableCollection
        public ObservableCollection<Researcher> GetList => ViewableResearchers;
    }
}