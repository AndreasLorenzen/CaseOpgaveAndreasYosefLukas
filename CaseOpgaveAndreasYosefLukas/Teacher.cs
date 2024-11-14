using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgaveAndreasYosefLukas
{
    /// <summary>
    /// This is a subclass, where it implements IPerson's interfaces with the first and last name. 
    /// </summary>
    public class Teacher : IPerson
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Teacher(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
