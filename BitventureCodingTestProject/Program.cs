using BitventureCodingTestProject.Processsors;
using System;
using System.Configuration;

namespace BitventureCodingTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProcessor serviceProcessor = new ServiceProcessor();

            var file = ConfigurationManager.AppSettings["jFile"];

            serviceProcessor.CallWebAPIAsync(file).Wait();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThis the end of the Project, Thank you Bitventure!. I have learned alot wotking on this.\n\nKeep Coding and Keep Learning :)");
            
            Console.ReadLine();
        }
       
    }
}
