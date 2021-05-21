using System;
using System.Collections.Generic;

namespace Assignment_2
{
	abstract class PublicationController
	{
        // Return a list of Publications that the Researcher has published
        public List<Publication> LoadPublicationFor(Researcher Researcher) => Researcher.Publications;
    }
}
