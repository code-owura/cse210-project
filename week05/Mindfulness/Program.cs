using System;

// CREATIVITY / EXCEEDS REQUIREMENTS:
// 1. The program uses a persistent menu that keeps running until the user chooses to quit.
// 2. Added an activity log that tracks how many times each activity has been performed in a session.
// 3. Displays the activity log on the main menu each time it is shown.

class Program
{
    static int _breathingCount = 0;
    static int _reflectingCount = 0;
    static int _listingCount = 0;

    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.WriteLine($"Activity Log: Breathing({_breathingCount}) Reflecting({_reflectingCount}) Listing({_listingCount})");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                _breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                _reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                _listingCount++;
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(2000);
            }
        }
    }
}