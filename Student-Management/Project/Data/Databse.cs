using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public static class Database
    {
        private static string filePath = "students.txt";
        public static List<Student> Students { get; private set; } = new List<Student>();

        public static void LoadData()
        {
            Students.Clear();
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var student = Student.FromFileString(line);
                if (student != null)
                    Students.Add(student);
            }
        }

        public static void SaveData()
        {
            for (int i = 0; i < Students.Count; i++)
                Students[i].Index = i + 1;

            var lines = Students.Select(s => s.ToFileString()).ToList();
            File.WriteAllLines(filePath, lines);
        }
    }
}
