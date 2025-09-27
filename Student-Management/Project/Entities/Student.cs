using System.Globalization;

namespace Project.Entities
{
    public class Student
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public double Score { get; set; }

        public Student() { }

        public Student(int index, string name, string id, int age, double score)
        {
            Index = index;
            Name = name;
            ID = id;
            Age = age;
            Score = score;
        }

        public override string ToString()
        {
            return $"{Index,-3} | {Name,-30} | {ID,-10} | {Age,-5} | {Score,-5}";
        }

        public string ToFileString()
        {
            return $"{Index}|{Name}|{ID}|{Age}|{Score}";
        }

        public static Student FromFileString(string line)
        {
            var parts = line.Split('|');
            if (parts.Length != 5) return null;

            if (!int.TryParse(parts[0], out var idx)) return null;
            if (!int.TryParse(parts[3], out var age)) return null;
            if (!double.TryParse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture, out var score)) return null;

            return new Student
            {
                Index = idx,
                Name = parts[1],
                ID = parts[2],
                Age = age,
                Score = score
            };
        }
    }
}
