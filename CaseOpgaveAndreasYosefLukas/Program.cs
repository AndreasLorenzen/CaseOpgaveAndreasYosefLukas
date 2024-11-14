using System.Text.RegularExpressions;

namespace CaseOpgaveAndreasYosefLukas
{
    class Program
    {
        static List<Subject> subjects = DataProvider.GetSubjects();

        // Asks klient to make a decision based on typing a number between 1-3. The decision is concluded via an if-else and Switch-Case structure
        static void Main(string[] args)
        {
            // We declared a bool variable "continuesearch" which is set to true. To keep the program running.
            bool continueSearch = true;
            while (continueSearch)
            {
                Console.WriteLine("Choices: ");
                Console.WriteLine("1. Search on a teacher");
                Console.WriteLine("2. Search on a student");
                Console.WriteLine("3. Search on a subject");
                Console.Write("Enter a number (1-3): ");

                // this code attempts to parse the user input as a SearchCriteria enum value and store it in the variable 'criteria'.
                if (Enum.TryParse<SearchCriteria>(Console.ReadLine(), out var criteria) && Enum.IsDefined(typeof(SearchCriteria), criteria))
                {
                    switch (criteria)
                    {
                        case SearchCriteria.Teacher:
                            SearchTeacher();
                            break;
                        case SearchCriteria.Student:
                            SearchStudent();
                            break;
                        case SearchCriteria.Subject:
                            SearchSubject();
                            break;
                    }
                }
                else
                {
                    // If input was not a valid SearchCriteria, it outputs an error message.
                    Console.WriteLine("No match found!.");
                }

                Console.WriteLine("Do you want to continue serching! (y/n)");
                continueSearch = Console.ReadLine()?.ToLower() == "y";
            }
        }

        static void SearchTeacher()
        {
            Console.Write("Enter your teachers FIRST name: ");
            var teacherName = Console.ReadLine();
            // this code finds the first teacher in the subjects list whose first name matches the teacherName (case-insensitive)
            var teacher = subjects.Select(s => s.Teacher).FirstOrDefault(t => t.FirstName.Equals(teacherName, StringComparison.OrdinalIgnoreCase));

            // return null if no match is found, and sends a message
            if (teacher == null)
            {
                Console.WriteLine("No match found.");
                return;
            }

            Console.WriteLine($"Lærer: {teacher.FirstName} {teacher.LastName}");
            // For each subject taught by the teacher, display the subject name and student count, then list each student’s full name. Highlight students under 20 years old in red text.
            foreach (var subject in subjects.Where(s => s.Teacher == teacher))
            {
                Console.WriteLine($"Subjects: {subject.Name}, Amount of Students: {subject.Students.Count}");
                foreach (var student in subject.Students)
                {
                    if (student.Age < 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"Students: {student.FirstName} {student.LastName}" + (student.Age < 20 ? "" : ""));

                    Console.ResetColor();
                }
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter students full name: ");
            var studentName = Console.ReadLine();
            // Find the first student across all subjects whose full name matches the given studentName (case-insensitive)
            var student = subjects.SelectMany(s => s.Students).FirstOrDefault(st => $"{st.FirstName} {st.LastName}".Equals(studentName, StringComparison.OrdinalIgnoreCase));

            // return null if no match is found
            if (student == null)
            {
                Console.WriteLine("No match found.");
                return;
            }

            Console.WriteLine($"Elev: {student.FirstName} {student.LastName}");
            // For each subject the student has, it displays the subject name and the teacher's full name.
            foreach (var subject in subjects.Where(s => s.Students.Contains(student)))
            {
                Console.WriteLine($"subject: {subject.Name}, teacher: {subject.Teacher.FirstName} {subject.Teacher.LastName}");
            }
        }

        static void SearchSubject()
        {
            Console.Write("Enter subject name: ");
            var subjectName = Console.ReadLine();
            // Find the first subject with a name that matches the given subjectName (case-insensitive)
            var subject = subjects.FirstOrDefault(s => s.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase));

            // return null if no match is found.
            if (subject == null)
            {
                Console.WriteLine("No match found");
                return;
            }

            Console.WriteLine($"Fag: {subject.Name}, Lærer: {subject.Teacher.FirstName} {subject.Teacher.LastName}, Antal elever: {subject.Students.Count}");

            // for each student under 20, there name will be written in red.
            foreach (var student in subject.Students)
            {
                if (student.Age < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"Student: {student.FirstName} {student.LastName}" + (student.Age < 20 ? "" : ""));

                Console.ResetColor();
            }
        }
    }
}
