// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
       
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

       
        string birthdateInput;
        DateTime birthdate;
        while (true)
        {
            Console.Write("Enter your birthdate (MM/dd/yyyy): ");
            birthdateInput = Console.ReadLine();

           
            if (Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
            {
               
                birthdate = DateTime.ParseExact(birthdateInput, "MM/dd/yyyy", null);
                break;
            }
            else
            {
                Console.WriteLine("Error: Invalid date format. Please use MM/dd/yyyy.");
            }
        }

       
        int age = DateTime.Now.Year - birthdate.Year;
        if (DateTime.Now.DayOfYear < birthdate.DayOfYear) age--;
        Console.WriteLine($"Hello {name}, you are {age} years old.");

       
        string filePath = "user_info.txt";
        File.WriteAllText(filePath, $"Name: {name}\nBirthdate: {birthdate.ToShortDateString()}\nAge: {age}");
        Console.WriteLine("\nUser information saved to user_info.txt");

       
        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine("\nContent of user_info.txt:");
        Console.WriteLine(fileContent);

       
        Console.Write("\nEnter a directory path to list its files: ");
        string directoryPath = Console.ReadLine();

   
        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("\nFiles in the directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("Error: Directory does not exist.");
        }

       
        Console.Write("\nEnter a string to format to Title Case: ");
        string inputString = Console.ReadLine();
        string titleCaseString = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputString.ToLower());
        Console.WriteLine($"Formatted String: {titleCaseString}");

       
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("\nGarbage Collection triggered explicitly.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}


