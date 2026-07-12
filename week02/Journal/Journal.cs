using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}:");
            _entries[i].Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            // Handle old files that don't have mood
            if (parts.Length > 3)
            {
                entry._mood = parts[3];
            }

            _entries.Add(entry);
        }
    }

    // NEW: Delete an entry by number
    public void DeleteEntry(int entryNumber)
    {
        if (entryNumber >= 1 && entryNumber <= _entries.Count)
        {
            _entries.RemoveAt(entryNumber - 1);
            Console.WriteLine("Entry deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid entry number.");
        }
    }

    public void SearchEntries(string keyword)
    {
        bool found = false;
        for (int i = 0; i < _entries.Count; i++)
        {
            if (_entries[i]._entryText.ToLower().Contains(keyword.ToLower()) ||
                _entries[i]._promptText.ToLower().Contains(keyword.ToLower()))
            {
                Console.WriteLine($"Entry #{i + 1}:");
                _entries[i].Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"No entries found containing '{keyword}'.");
        }
    }

    public int GetEntryCount()
    {
        return _entries.Count;
    }
}