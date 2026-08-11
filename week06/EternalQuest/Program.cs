using System;

// CREATIVITY:
// I have added the following creative features to exceed core requirements:
// 1. Added a "Level System" — the user levels up every 1000 points
// 2. Added a special congratulations message with stars when a checklist goal is completed
// 3. Prevents recording a SimpleGoal that has already been completed
// 4. Added a friendly welcome banner at the start
// 5. Added error handling for invalid inputs and missing files

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("   Welcome to the Eternal Quest Program!");
        Console.WriteLine();

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}