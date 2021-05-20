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

        // Student Constructor
        public Student(string Degree)
        {
            this.Degree = Degree;
        }
    }
}
