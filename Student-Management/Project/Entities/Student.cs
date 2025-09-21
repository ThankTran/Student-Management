using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project.Entities
{
    public class Student
    {
        public int Index { get; set; };
        public string Name { get; set; };
        public string ID { get; set; };
        public int Age { get; set; };
        public double Score { get; set; };
        public override string ToString()
        {
            return $"{Index,-3} | {Name,-20} | {ID,-10} | {Age,-5} | {Score,-5}";
        }
        public string ToFileString()
        {
            return $"{Index}|{Name}|{ID}|{Age}|{Score}";
        }
        public static Student FromFileString(string line)
        {
            var parts = line.Split('|');
            if (parts.Length != 5) return null;

            return new Student
            {
                Index = int.Parse(parts[0]),
                Name = parts[1],
                ID = parts[2],
                Age = int.Parse(parts[3]),
                Score = double.Parse(parts[4])
            };
        }
    }
}
