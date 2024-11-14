using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgaveAndreasYosefLukas
{
    /// <summary>
    /// We used a subclass to define first and last name, then we placed an age property as an int. since we only need ages of the students.
    /// </summary>
    public class Student : IPerson
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
