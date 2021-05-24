using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class ResearchAssessmentProgram
    {
        static void Main(string[] args)
        {
            ResearcherController ResearcherController = new ResearcherController();
            List<Researcher> Researchers = ResearcherController.LoadResearchers();
        	Researcher R;
        	
        	Console.WriteLine("Test");
        	
        	R = FetchFullResearcherDetails(123465);
        }  
    }
}
