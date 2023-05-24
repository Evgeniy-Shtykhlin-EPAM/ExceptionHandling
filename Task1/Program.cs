using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool validateStr;
            do
            {
                Console.WriteLine("Enter text:");
                var str = Console.ReadLine();
                try
                {
                    Console.WriteLine("First symbol is: " + str.First());
                    validateStr=true;
                }
                catch (InvalidOperationException)
                {
                    validateStr = false;
                    Console.WriteLine("InvalidOperationException. Empty line");
                }

            } while (!validateStr);
        }
    }
}