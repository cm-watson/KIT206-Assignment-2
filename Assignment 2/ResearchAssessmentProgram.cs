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
            // CONTROLLERS
            ResearcherController RController = new ResearcherController();
            PublicationController PController = new PublicationController();

            // Test Researcher
            List<Position> Positions = new List<Position>();
            Positions.Add( new Position( EmploymentLevel.A, DateTime.Now, DateTime.MinValue ) );

            System.Diagnostics.Debug.WriteLine( Positions[0].End );

            Researcher TestResearcher = new Researcher(000001, Type.Student, "Matthew", "McKeown",
                "Dr", "Digital Fabrication", Campus.Hobart, "matthewisawzome@gmail.com",
                "https://matthew.com.au/", "PhD", 123465, null, Positions);

            Position CurrentJob = TestResearcher.GetCurrentJob();
            EmploymentLevel Level = CurrentJob.Level;
            string Title = CurrentJob.GetJobTitle( Level );

            System.Diagnostics.Debug.WriteLine( Level );
            System.Diagnostics.Debug.WriteLine( Title );

            /*
            Console.WriteLine("Test");

            List<Researcher> Researchers = RController.LoadResearchers;
        	Researcher R;
        	
        	R = ERDAdapter.FetchFullResearcherDetails(123465);
            */
        }  
    }
}
