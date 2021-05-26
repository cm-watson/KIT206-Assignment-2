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
            /* MATTHEW'S TEST OBJECTS */

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

            // RESEARCHER CONTROLLER
            List<Researcher> TestResearchers = TestResearcherController.LoadResearchers;
            int LoadResearcherCount = 1;
            foreach( Researcher R in TestResearchers)
            {
                System.Diagnostics.Debug.WriteLine( LoadResearcherCount + ". " + R.FamilyName + ", " + R.GivenName + ", (" + R.Title + ")" );
                PrintResearcher( R, "\t" );
                LoadResearcherCount++;
            }

            TestResearcherController.LoadResearcherDetails( TestResearcher );
            List<Researcher> FilteredByLevel = TestResearcherController.FilterByLevel( TestResearchers, EmploymentLevel.B );
            List<Researcher> FilteredByName = TestResearcherController.FilterByName( TestResearchers, "Matthew" );



            System.Diagnostics.Debug.WriteLine( TestPositions[0].End );
            
            
            

            /* Xavier's Test Code */

            /*
            List<Researcher> Researchers = new List<Researcher>();

            //Researchers.Add(ERDAdapter.CompleteResearcherDetails(BasicResearchers[0]));
            //Researchers.Add(ERDAdapter.CompleteResearcherDetails(BasicResearchers[BasicResearchers.Count - 1]));
            Researchers.Add(ERDAdapter.FetchFullResearcherDetails(123461));

            PrintResearcher(Researchers[0], "\n");
            PrintResearcher(Researchers[1], "\n");
            PrintResearcher(Researchers[2], "\n");
            */
            
        }  
        
        public static void PrintResearcher(Researcher R)
        {
            System.Diagnostics.Debug.WriteLine(R.ID + " " + R.CurrentType + " " + R.GivenName + " " + R.FamilyName
            + " " + R.Title + ", Unit:" + R.Unit + ", Campus: " + R.CurrentCampus + ", Email: " + R.Email
            + ", Photo: " + R.Photo + ", Degree: " + R.Degree + ", SupervisorID: " + R.SupervisorID + ", Level: " + R.Positions[0].GetLevel());
        }

        public static void PrintResearcher(Researcher R, String Prefix)
        {
            System.Diagnostics.Debug.Write(Prefix);
            PrintResearcher(R);
        }
    }
}
