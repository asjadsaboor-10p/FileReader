using System;
using System.Collections.Generic;
using System.IO;
using FileReader.Services;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {

            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            //My path "/Users/asjadsaboor/Downloads/MOCK_DATA.csv";
            UserService _userService = new UserService();
            string filePath = getFilePathFromUserInput();
            // TODO: add validation to check null / empty values 
            List<User> resultData = _userService.ReadCSVFile(filePath);
            double averageSalary  = _userService.calculateAverageSalary(resultData);
            Console.WriteLine("Average Salary is : {0}", averageSalary);

        }

        static string getFilePathFromUserInput()
        {
            Console.WriteLine("Please provide csv path");
            var filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                throw new Exception("provided file: [" + filePath + "] does not exists");
            }
            return filePath;
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
