using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class ResearchAssessmentProgram
    {
        static void Main(string[] args)
        {
            /* TEST OBJECTS */

            // CONTROLLERS
            ResearcherController TestResearcherController = new ResearcherController();
            PublicationController TestPublicationController = new PublicationController();

            // POSITION
            Position TestPosition = new Position( EmploymentLevel.A, DateTime.Now, DateTime.MinValue );

            // POSITIONS
            List<Position> TestPositions = new List<Position>();
            TestPositions.Add( TestPosition );

            // PUBLICATION
            Publication TestPublication = new Publication( "10.1007/11504894_31", "Funny Llama Puns",
                "Matthew McKeown", 2021, "McKeown, M, 'Funny Llama Puns' ", DateTime.Now);

            // PUBLICATIONS
            List<Publication> TestPublications = new List<Publication>();
            TestPublications.Add( TestPublication );

            // RESEARCHER
            Researcher TestResearcher = new Researcher(000001, Type.Student, "Matthew", "McKeown",
                "Dr", "Digital Fabrication", Campus.Hobart, "matthewisawzome@gmail.com",
                "https://matthew.com.au/", "PhD", 123465, TestPublications, TestPositions);

            // STAFF
            Staff TestStaff = new Staff( 0412810317, "Ya Mum's", "Academic" );
            
            // STUDENT
            Student TestStudent = new Student( TestResearcher.Degree, TestResearcher.SupervisorID );


            /* Testing methods */

            // CONTROLLERS


            System.Diagnostics.Debug.WriteLine( TestPositions[0].End );

            /*
            Console.WriteLine("Test");

            List<Researcher> Researchers = RController.LoadResearchers;
        	Researcher R;
        	
        	R = ERDAdapter.FetchFullResearcherDetails(123465);
            */
        }  
    }
}
