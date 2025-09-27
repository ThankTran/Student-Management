using Project.Data;
using Project.Utilities;
using Project.Entities;

class Program
{
    static void Main(string[] args)
    {
        string dataFolder = "Data";
        string filePath = Path.Combine(dataFolder, "students.txt");

        if (!Directory.Exists(dataFolder))
            Directory.CreateDirectory(dataFolder);

        Database.LoadData();

        var ui = new ApplicationUI();
        try
        {
            ui.Run();
        }
        finally
        {
            Database.SaveData();
        }

    }
}
