using System;

// 1. Added a LIBRARY of multiple scriptures - the program randomly picks one
//    each time it starts, so users can practice different scriptures.
// 2. The HideRandomWords method only hides words that are NOT already hidden,
//    ensuring efficient hiding and no wasted attempts.
// 3. Added a welcome message and clear instructions for the user.
// 4. Added a nice ending message when the scripture is fully hidden.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>();

        Reference reference1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(reference1,
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        scriptureLibrary.Add(scripture1);

        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(reference2,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths.");
        scriptureLibrary.Add(scripture2);

        Reference reference3 = new Reference("2 Nephi", 2, 25);
        Scripture scripture3 = new Scripture(reference3,
            "Adam fell that men might be and men are that they might have joy.");
        scriptureLibrary.Add(scripture3);

        Random random = new Random();
        int index = random.Next(scriptureLibrary.Count);
        Scripture scripture = scriptureLibrary[index];

        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer Program!");
        Console.WriteLine("Press Enter to begin...");
        Console.ReadLine();

        string userInput = "";
        while (!scripture.IsCompletelyHidden() && userInput.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Congratulations! You've hidden all the words!");
            Console.WriteLine("Great job practicing! Goodbye!");
        }
    }
}