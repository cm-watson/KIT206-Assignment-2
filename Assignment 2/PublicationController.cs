using System;
using System.Collections.Generic;

namespace Assignment_2
{
	public class PublicationController
	{
        // Return a list of Publications (with basic details) that the Researcher has published
        public List<Publication> LoadBasicPublicationsFor(Researcher Researcher) => Researcher.Publications;

        // Return a Publication (with all details) that the Researcher has published
        public Publication LoadCompletePublicationDetails(Publication Publication) => ERDAdapter.CompletePublicationDetails( Publication );
    }
}
