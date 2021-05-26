﻿using System;
using System.Collections.Generic;

namespace Assignment_2
{
	public class PublicationController
	{
        // Return a list of Publications that the Researcher has published
        public List<Publication> LoadPublicationsFor(Researcher Researcher) => Researcher.Publications;
    }
}
