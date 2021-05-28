using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assignment_2
{
	public class PublicationController
	{

        // The main list of all Publications
        private List<Publication> MasterPublications;
        // The list of Researchers shown in the UI
        private ObservableCollection<Publication> ViewablePublications;

        // PublicationController constructor
        public PublicationController()
        {
            // Fill List with Publications
            MasterPublications = LoadBasicPublicationsFor( new Researcher(0, Type.Staff, "", "", "", "", Campus.Hobart, "", "", "", 0, null, null) );
            // Fill ObservableCollection with Publications in MasterPublications
            ViewablePublications = MakeObservable( MasterPublications );
        }

        // Sets the MasterPublications as LoadBasicPublicationsFor
        public void SetPublications(Researcher Researcher)
        {
            MasterPublications = LoadBasicPublicationsFor( Researcher );
        }

        // Return a list of Publications (with basic details) that the Researcher has published
        public List<Publication> LoadBasicPublicationsFor(Researcher Researcher) => Researcher.Publications;

        // Return a Publication (with all details) that the Researcher has published
        public Publication LoadCompletePublicationDetails(Publication Publication) => ERDAdapter.CompletePublicationDetails( Publication );
    
        // Convert the parsed List<Publication> into an ObservableCollection<Publication>
        public ObservableCollection<Publication> MakeObservable( List<Publication> Publications )
        {
            ObservableCollection<Publication> ShownPublications = new ObservableCollection<Publication>();
            for ( int i = 0; i < Publications.Count; i++ )
            {
                // Add each Publication in Publications to ShownPublications
                ShownPublications.Add( Publications[i] );
            }
            return ShownPublications;
        }
    
        // Return the ViewablePublciations ObservableCollection
        public ObservableCollection<Publication> GetList() => ViewablePublications;
    }
}
