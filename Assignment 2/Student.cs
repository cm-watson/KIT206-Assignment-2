using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Student:Researcher
    {
        // The name of the Student's degree 
        public string Degree { get; set; }
        // The Student's supervisor's ID
        public int SupervisorID { get; set; }

        // Student Constructor
        public Student(string Degree, int SupervisorID) : base(0, Type.Student, "", "", "", "", Campus.Hobart, "", "", "", 0, null, null)
        {
            this.Degree = Degree;
            this.SupervisorID = SupervisorID;
        }
    }
}
