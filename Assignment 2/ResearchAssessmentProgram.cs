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

            // RESEARCHERS
            List<Researcher> TestBasicResearchers = new List<Researcher>();
            List<Researcher> TestDetailsResearchers = new List<Researcher>();

            // POSITIONS
            List<Position> TestPositions = new List<Position>();

            // PUBLICATIONS
            List<Publication> TestPublications = new List<Publication>();

            // STAFF
            List<Researcher> TestStaff = new List<Researcher>();
            
            // STUDENTS
            List<Researcher> TestStudents = new List<Researcher>();


            /* Testing methods */

            // RESEARCHER CONTROLLER

            TestBasicResearchers = TestResearcherController.LoadResearchers;
            foreach ( Researcher R in TestBasicResearchers )
            {
                //PrintBasicResearcher( R );
            }

            TestDetailsResearchers.Add( TestResearcherController.LoadResearcherDetails( TestBasicResearchers[0] ) );
            TestDetailsResearchers.Add( TestResearcherController.LoadResearcherDetails( TestBasicResearchers[ TestBasicResearchers.Count - 1 ] ) );
            foreach ( Researcher R in TestDetailsResearchers )
            {
                //PrintDetailsResearcher( R );
            }

            List<Researcher> FilteredByLevel = TestResearcherController.FilterByLevel( TestBasicResearchers, EmploymentLevel.B );
            foreach ( Researcher R in FilteredByLevel )
            {
                //PrintBasicResearcher( R );
            }

            List<Researcher> FilteredByName = TestResearcherController.FilterByName( TestBasicResearchers, "an" );
            foreach ( Researcher R in FilteredByName )
            {
                //PrintBasicResearcher( R );
            }

            // PUBLICATION CONTROLLER

            List<Publication> TestLoadPublications = TestPublicationController.LoadPublicationsFor( TestBasicResearchers[0] );
            foreach ( Publication P in TestLoadPublications )
            {
                System.Diagnostics.Debug.WriteLine( P.Title );
            }


            // POSITION

            foreach ( Researcher R in TestBasicResearchers )
            {
                TestPositions.Add( R.Positions[0] );
            }

            foreach ( Position P in TestPositions )
            {
                //System.Diagnostics.Debug.WriteLine( "Level: " + P.GetLevel() + ", Title: " + P.GetJobTitle(P.Level) );
            }  
            

            // PUBLICATION

            foreach ( Publication P in TestLoadPublications )
            {
                System.Diagnostics.Debug.WriteLine( P.DateAvailable + ", " + P.Age() );
            }

            // RESEARCHER

            foreach ( Researcher R in TestBasicResearchers )
            {
                //System.Diagnostics.Debug.WriteLine( R.GetCurrentJob().Level );
                //System.Diagnostics.Debug.WriteLine( R.CurrentJobTitle );
                //System.Diagnostics.Debug.WriteLine( R.CurrentJobStart );
                //System.Diagnostics.Debug.WriteLine( R.EarliestStart );
                //System.Diagnostics.Debug.WriteLine( R.Tenure() );
                //System.Diagnostics.Debug.WriteLine( R.PublicationsCount() );
            }

            // STAFF

            foreach ( Researcher R in TestBasicResearchers )
            {
                if( R.CurrentType == Type.Staff )
                {
                    TestStaff.Add( R );
                }

            }

            foreach ( Researcher R in TestStaff )
            {
                //System.Diagnostics.Debug.WriteLine( R.ThreeYearAverage( R.Publications ) );
            }

            foreach ( Researcher R in TestStaff )
            {
                //System.Diagnostics.Debug.WriteLine( R.Performance( R.Publications ) );
            }

        }  
        
        public static void PrintBasicResearcher(Researcher R)
        {
            System.Diagnostics.Debug.WriteLine( R.FamilyName + ", " + R.GivenName + " (" + R.Title + ")" );
        }

        public static void PrintDetailsResearcher(Researcher R)
        {
            System.Diagnostics.Debug.WriteLine( R.ID + " " + R.CurrentType + " " + R.GivenName + " " + R.FamilyName
            + " " + R.Title + ", Unit:" + R.Unit + ", Campus: " + R.CurrentCampus + ", Email: " + R.Email
            + ", Photo: " + R.Photo + ", Degree: " + R.Degree + ", SupervisorID: " + R.SupervisorID + ", Level: " + R.Positions[0].GetLevel() );
        }
    }
}
