using System.Globalization;
using Project.Data;
using Project.Entities;
using Project.Utilities;

namespace Project.Services
{
    internal class StudentServices
    {
        private StudentRepository repo = new StudentRepository();

        public void ListAll()
        {
            var list = repo.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("Idx | Name                                    | ID         | Age   | GPA  ");
            Console.WriteLine(new string('-', 60));
            foreach (var s in list)
                Console.WriteLine(s.ToString());
        }

        public void AddStudent()
        {
            var list = repo.GetAll();
            int nextIndex = list.Count + 1;
            var s = InputServices.GetStudentInfo(nextIndex);
            repo.Add(s);
            Console.WriteLine("Student added.");
        }

        public void UpdateStudent()
        {
            var list = repo.GetAll();
            if (list.Count == 0) { Console.WriteLine("No students to update."); return; }

            Console.Write("Enter student index to update: ");
            if (!int.TryParse(Console.ReadLine(), out int idx)) { Console.WriteLine("Invalid index"); return; }

            var existing = repo.GetByIndex(idx);
            if (existing == null) { Console.WriteLine("Student not found."); return; }

            Console.WriteLine("Enter new data:");

            Console.Write($"Full name ({existing.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) existing.Name = name.Trim();

            Console.Write($"Student ID ({existing.ID}): ");
            var id = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(id) && id.Length == 8 && id.All(char.IsDigit)) existing.ID = id.Trim();

            Console.Write($"Age ({existing.Age}): ");
            var ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out int age)) existing.Age = age;

            Console.Write($"GPA ({existing.Score}): ");
            var gpaInput = Console.ReadLine();
            if (double.TryParse(gpaInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double gpa)) existing.Score = gpa;

            repo.Update(idx, existing);
            Console.WriteLine("Student updated.");
        }

        public void DeleteStudent()
        {
            var list = repo.GetAll();
            if (list.Count == 0) { Console.WriteLine("No students to delete."); return; }

            Console.Write("Enter student index to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int idx)) { Console.WriteLine("Invalid index"); return; }

            try
            {
                repo.Delete(idx);
                Console.WriteLine("Student deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void SearchByName()
        {
            var list = repo.GetAll();
            Console.Write("Enter name to search: ");
            string q = Console.ReadLine()?.Trim() ?? string.Empty;
            var results = list.Where(s => s.Name.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (results.Count == 0) { Console.WriteLine("No matches."); return; }

            Console.WriteLine("Idx | Name                         | ID         | Age   | GPA  ");
            Console.WriteLine(new string('-', 60));
            foreach (var s in results)
                Console.WriteLine(s.ToString());
        }

        public void AddListStudents()
        {
            Console.Write("Enter the number of students: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Error. It must be a number greater than 0.");
                return;
            }

            var list = repo.GetAll();
            for (int i = 1; i <=  n; i++)
            {
                Console.WriteLine($"\nEnter the information of student {i}:");
                var student = InputServices.GetStudentInfo(i);
                repo.Add(student);
            }
            Database.SaveData(); 
            Console.WriteLine($"\nSaved {n} students.");
        }
    }
}
