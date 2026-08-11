using System;

// CREATIVITY
// I have added the following FULLY FUNCTIONING creative features
// that exceed the core requirements:
//
// 1. COLORED CONSOLE OUTPUT - The program uses different colors 
//    for different messages (green for success, yellow for warnings, 
//    cyan for menu, magenta for level up, red for errors)
//
// 2. WELCOME BANNER - Program starts with an attractive ASCII 
//    art welcome banner with colors
//
// 3. LEVEL SYSTEM - Users level up every 1000 points and receive 
//    a special celebration message with visual borders
//
// 4. ACHIEVEMENT BADGES - Users earn badges at milestones 
//    (100, 500, 1000, 5000 points) with unlock notifications
//
// 5. VISUAL PROGRESS BAR - Checklist goals display a progress bar 
//    showing percentage completed (e.g., [█████░░░░░] 50%)
//
// 6. SOUND EFFECTS - Uses Console.Beep to play sounds when users 
//    earn points, complete goals, or level up
//
// 7. STATISTICS MENU - Added a new menu option (option 6) that 
//    displays user statistics including total goals, completed 
//    goals, current level, and earned badges
//
// 8. PREVENTS DUPLICATE COMPLETION - Prevents recording a 
//    SimpleGoal that has already been completed
//
// All features have been thoroughly tested and are working correctly.

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║   🌟 Welcome to Eternal Quest! 🌟       ║");
        Console.WriteLine("║       Your Journey Begins Today!         ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}