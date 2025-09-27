using System.Text;
using Project.Entities;

namespace Project.Data
{
    public static class Database
    {
        private static string filePath = Path.Combine("Data", "students.txt");
        public static List<Student> Students { get; private set; } = new List<Student>();

        public static void LoadData()
        {

            Students.Clear();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var student = Student.FromFileString(line);
                    if (student != null)
                        Students.Add(student);
                }
            }
        }

        public static void SaveData()
        {
            try
            {
                for (int i = 0; i < Students.Count; i++)
                    Students[i].Index = i + 1;

                var lines = Students.Select(s => s.ToFileString()).ToList();
                if(!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllLines(filePath, lines, Encoding.UTF8);
                Console.WriteLine("Data successfully saved to " + filePath);
            }
            catch
            {
                Console.WriteLine("Error saving data: ");
            }
        }
    }
}
