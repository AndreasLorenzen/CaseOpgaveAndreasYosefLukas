using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgaveAndreasYosefLukas
{
    /// <summary>
    /// This class (Subject) represents a subject, stores its name, adds/assign a teacher, and a list of students enrolled int the subject. 
    /// </summary>
    public class Subject
    {
        public string Name { get; }
        public Teacher Teacher { get; }
        public List<Student> Students { get; }

        public Subject(string name, Teacher teacher, List<Student> students)
        {
            Name = name;
            Teacher = teacher;
            Students = students;
        }
    }
}
