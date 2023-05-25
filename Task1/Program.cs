using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool validateStr;
            do
            {
                validateStr = true;
                Console.WriteLine("Enter text:");
                var str = Console.ReadLine();
                try
                {
                    Console.WriteLine("First symbol is: " + str[0]);
                }
                catch (IndexOutOfRangeException)
                {
                    validateStr = false;
                    Console.WriteLine("InvalidOperationException. Empty line");
                }

            } while (!validateStr);
        }
    }
}