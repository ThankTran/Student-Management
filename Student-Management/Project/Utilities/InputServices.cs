using System.Globalization;
using Project.Entities;

namespace Project.Utilities
{
    public static class InputServices
    {
        public static Student GetStudentInfo(int index)
        {
            string fullName = "";
            string studentId = "";
            int birthYear = 0;
            double gpa = 0;

            while (true)
            {
                Console.Write($"[{index}] Enter full name: ");
                fullName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    Console.WriteLine("Error! Full name cannot be empty. Please enter again.");
                    continue;
                }

                if (!fullName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Error! Full name can only contain letters and spaces. Please enter again.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Enter student ID (8 digits): ");
                studentId = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(studentId) || studentId.Length != 8 || !studentId.All(char.IsDigit))
                {
                    Console.WriteLine("Error! Student ID must be exactly 8 digits! Please enter again.");
                    continue;
                }
                break;
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter birth year: ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out birthYear))
                        throw new FormatException("Birth year must be a number!");

                    if (birthYear < 1900 || birthYear > DateTime.Now.Year)
                        throw new ArgumentOutOfRangeException("Birth year is not valid!");

                    break;
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }

            while (true)
            {
                Console.Write("Enter GPA (0.0 - 10.0): ");
                string input = Console.ReadLine();

                try
                {
                    if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out gpa))
                    {
                        Console.WriteLine("Error! GPA must be a number.");
                        continue;
                    }

                    if (gpa < 0.0 || gpa > 10.0)
                    {
                        Console.WriteLine("Error! GPA must be between 0.0 and 10.0.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! GPA must be a number.");
                    continue;
                }

                break;
            }

            int age = DateTime.Now.Year - birthYear;

            return new Student(index, fullName.Trim(), studentId.Trim(), age, gpa);
        }

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }
    }
}
