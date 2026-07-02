using System;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {
        // Part 1 requirement, user gives the magic number
        // Console.Write("What is the magic number? ");
        // string magicNumber = Console.ReadLine();
        // int number = int.Parse(magicNumber);

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        string level = "";
        int digit = 0;
        while (digit != number)
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            digit = int.Parse(guess);

            if (digit < number)
            {
                level = "Higher";
            }

            else if (digit > number)
            {
                level = "Lower";
            }

            else
            {
                level = "You guessed it!";
            }

            Console.WriteLine($"{level}");
        }
    }
}