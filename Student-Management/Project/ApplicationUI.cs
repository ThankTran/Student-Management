using Project.Services;

internal class ApplicationUI
{
    private StudentServices studentServices = new StudentServices();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("===== Student Management =====");
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Enter list students");
            Console.WriteLine("2. List all students");
            Console.WriteLine("3. Add student");
            Console.WriteLine("4. Update student");
            Console.WriteLine("5. Delete student");
            Console.WriteLine("6. Search by name");
            Console.WriteLine("0. Exit");
            

            var input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1": studentServices.AddListStudents(); break;
                case "2": studentServices.ListAll(); break;
                case "3": studentServices.AddStudent(); break;
                case "4": studentServices.UpdateStudent(); break;
                case "5": studentServices.DeleteStudent(); break;
                case "6": studentServices.SearchByName(); break;
                case "0": Console.WriteLine("Goodbye!"); return;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        }
    }
}
