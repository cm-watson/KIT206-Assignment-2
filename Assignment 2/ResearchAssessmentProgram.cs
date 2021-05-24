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
            ResearcherController RController = new ResearcherController();
            List<Researcher> Researchers = RController.LoadResearchers;
        	Researcher R;

        	Console.WriteLine("Testicles");
        	
        	R = ERDAdapter.FetchFullResearcherDetails(123465);
        }  
    }
}
