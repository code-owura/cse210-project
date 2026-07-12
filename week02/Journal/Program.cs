using System;

// CREATIVITY - EXCEEDING REQUIREMENTS:
// 
// 1. Added a MOOD field to each entry, so users can track their
//    emotional state along with their journal entries.
//
// 2. Expanded the prompt list from 5 to 15 prompts for greater 
//    variety and less repetition.
//
// 3. Added an ENTRY COUNTER that displays on the menu showing 
//    how many entries the user currently has in their journal.
//
// 4. Added a DELETE ENTRY feature (menu option 6) that allows 
//    users to remove specific entries by their number.
//
// 5. Added a SEARCH feature (menu option 7) that lets users 
//    search for entries containing a specific keyword in either 
//    the prompt or entry text (case-insensitive search).
//
// 6. Added entry numbering when displaying all entries, so users 
//    can easily reference specific entries.
//
// 7. Added helpful messages when the journal is empty or when 
//    search returns no results.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "8")
        {
            Console.WriteLine($"\n[You have {myJournal.GetEntryCount()} entries in your journal]");
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Delete an entry");
            Console.WriteLine("6. Search entries");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                // Write a new entry
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling? (Happy, Sad, Excited, etc.): ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._mood = mood;

                myJournal.AddEntry(newEntry);
                Console.WriteLine("Entry saved!");
            }
            else if (choice == "2")
            {
                // Display the journal
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Load from file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                try
                {
                    myJournal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Could not load file. Please check the filename.");
                }
            }
            else if (choice == "4")
            {
                // Save to file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully!");
            }
            else if (choice == "5")
            {
                // Delete an entry
                myJournal.DisplayAll();
                Console.Write("Enter the number of the entry to delete: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int entryNumber))
                {
                    myJournal.DeleteEntry(entryNumber);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            else if (choice == "6")
            {
                // Search entries
                Console.Write("Enter a keyword to search for: ");
                string keyword = Console.ReadLine();
                myJournal.SearchEntries(keyword);
            }
            else if (choice == "7" || choice == "8")
            {
                Console.WriteLine("Goodbye!");
                choice = "8";
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}