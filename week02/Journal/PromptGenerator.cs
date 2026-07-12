using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What is one thing I learned today?",
        "What am I grateful for today?",
        "What challenge did I overcome today?",
        "How did I show kindness to someone today?",
        "What is something I want to remember about today?",
        "What goal did I work toward today?",
        "Who inspired me today and why?",
        "What is one thing I would tell my past self about today?",
        "What made today unique from other days?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}