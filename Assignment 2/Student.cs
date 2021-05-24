using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Student:Researcher
    {
        // The name of the Student's degree 
        public string Degree { get; set; }
        // The Student's supervisor's ID
        public int SupervisorID { get; set; }

        // Student Constructor
        public Student(string Degree, int SupervisorID)
        {
            this.Degree = Degree;
            this.SueprvisorID = SupervisorID;
        }
    }
}
