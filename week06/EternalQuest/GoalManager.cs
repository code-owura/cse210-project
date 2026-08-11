using System;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _earnedBadges;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _earnedBadges = new List<string>();
    }

    public void Start()
    {
        string choice = "";
        while (choice != "7")
        {
            DisplayPlayerInfo();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Menu Options:");
            Console.ResetColor();
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. View Statistics");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                DisplayStatistics();
            }
            else if (choice == "7")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thank you for using the Eternal Quest Program!");
                Console.WriteLine("Keep working on your goals! 🌟");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ResetColor();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n⭐ Level: {_level} | 🏆 Score: {_score} points");
        if (_earnedBadges.Count > 0)
        {
            Console.WriteLine($"🎖️  Badges: {string.Join(", ", _earnedBadges)}");
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public void DisplayStatistics()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║       📊 YOUR STATISTICS 📊         ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine($"📝 Total Goals: {_goals.Count}");
        Console.WriteLine($"✅ Completed: {_goals.Count(g => g.IsComplete())}");
        Console.WriteLine($"⏳ In Progress: {_goals.Count(g => !g.IsComplete())}");
        Console.WriteLine($"🏆 Total Points: {_score}");
        Console.WriteLine($"⭐ Current Level: {_level}");
        Console.WriteLine($"🎖️  Badges Earned: {_earnedBadges.Count}");

        if (_earnedBadges.Count > 0)
        {
            Console.WriteLine("\n🎖️  Your Badges:");
            foreach (string badge in _earnedBadges)
            {
                Console.WriteLine($"   ✨ {badge}");
            }
        }
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The goals are:");
        Console.ResetColor();
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            SimpleGoal simple = new SimpleGoal(name, description, points);
            _goals.Add(simple);
        }
        else if (type == "2")
        {
            EternalGoal eternal = new EternalGoal(name, description, points);
            _goals.Add(eternal);
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal checklist = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklist);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid goal type.");
            Console.ResetColor();
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no goals to record. Please create a goal first.");
            Console.ResetColor();
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal selectedGoal = _goals[index];

            if (selectedGoal is SimpleGoal && selectedGoal.IsComplete())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This goal has already been completed!");
                Console.ResetColor();
                return;
            }

            selectedGoal.RecordEvent();
            int earnedPoints = int.Parse(selectedGoal.GetPoints());
            _score += earnedPoints;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"🎉 Congratulations! You earned {earnedPoints} points!");
            Console.ResetColor();

            try { Console.Beep(600, 200); } catch { }

            if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete())
            {
                _score += checklist.GetBonus();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"🏆 BONUS! You earned an additional {checklist.GetBonus()} points!");
                Console.ResetColor();
                try { Console.Beep(800, 300); } catch { }
            }

            Console.WriteLine($"You now have {_score} points.");

            CheckLevelUp();
            CheckAchievements();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid goal number.");
            Console.ResetColor();
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n╔══════════════════════════════════════╗");
            Console.WriteLine($"║  🎉 LEVEL UP! You are now Level {_level}!  ║");
            Console.WriteLine("╚══════════════════════════════════════╝\n");
            Console.ResetColor();

            try
            {
                Console.Beep(523, 100);
                Console.Beep(659, 100);
                Console.Beep(784, 200);
            }
            catch { }
        }
    }

    private void CheckAchievements()
    {
        CheckBadge(100, "🥉 Beginner");
        CheckBadge(500, "🥈 Dedicated");
        CheckBadge(1000, "🥇 Champion");
        CheckBadge(5000, "👑 Legend");
    }

    private void CheckBadge(int scoreRequired, string badgeName)
    {
        if (_score >= scoreRequired && !_earnedBadges.Contains(badgeName))
        {
            _earnedBadges.Add(badgeName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🏆 ACHIEVEMENT UNLOCKED: {badgeName}!");
            Console.ResetColor();
            try { Console.Beep(1000, 200); } catch { }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);
            outputFile.WriteLine(string.Join(",", _earnedBadges));
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✅ Goals saved successfully!");
        Console.ResetColor();
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ File not found!");
            Console.ResetColor();
            return;
        }

        _goals.Clear();
        _earnedBadges.Clear();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        if (!string.IsNullOrEmpty(lines[2]))
        {
            _earnedBadges = lines[2].Split(",").ToList();
        }

        for (int i = 3; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string goalType = parts[0];
            string[] details = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(details[3]);
                SimpleGoal simple = new SimpleGoal(details[0], details[1], details[2], isComplete);
                _goals.Add(simple);
            }
            else if (goalType == "EternalGoal")
            {
                EternalGoal eternal = new EternalGoal(details[0], details[1], details[2]);
                _goals.Add(eternal);
            }
            else if (goalType == "ChecklistGoal")
            {
                int target = int.Parse(details[3]);
                int bonus = int.Parse(details[4]);
                int amountCompleted = int.Parse(details[5]);
                ChecklistGoal checklist = new ChecklistGoal(details[0], details[1], details[2], target, bonus, amountCompleted);
                _goals.Add(checklist);
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✅ Goals loaded successfully!");
        Console.ResetColor();
    }
}