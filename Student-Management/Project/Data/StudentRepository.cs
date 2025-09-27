using Project.Entities;

namespace Project.Data
{
    internal class StudentRepository
    {
        public List<Student> GetAll()
        {
            Database.LoadData();
            return Database.Students;
        }

        public void Add(Student s)
        {
            Database.Students.Add(s);
            Database.SaveData();
        }

        public void Update(int index, Student updated)
        {
            var idx = Database.Students.FindIndex(x => x.Index == index);
            if (idx >= 0)
            {
                updated.Index = Database.Students[idx].Index;
                Database.Students[idx] = updated;
                Database.SaveData();
            }
            else throw new ArgumentException("Student not found");
        }

        public void Delete(int index)
        {
            var st = Database.Students.FirstOrDefault(x => x.Index == index);
            if (st != null)
            {
                Database.Students.Remove(st);
                Database.SaveData();
            }
            else throw new ArgumentException("Student not found");
        }

        public Student GetByIndex(int index)
        {
            return Database.Students.FirstOrDefault(x => x.Index == index);
        }
    }
}
