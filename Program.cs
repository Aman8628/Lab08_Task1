using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] subjects = { "VP", "Data Structures", "Calculus", "Probability" };
        Dictionary<string, List<int>> gradebook = new Dictionary<string, List<int>>();

        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Enter Student {i} Name: ");
            string name = Console.ReadLine();
            List<int> marks = new List<int>();

            foreach (string sub in subjects)
            {
                Console.Write($"Enter marks for {sub}: ");
                marks.Add(int.Parse(Console.ReadLine()));
            }
            gradebook[name] = marks;
            Console.WriteLine();
        }

        string topper = "";
        double highestAvg = 0;

        foreach (KeyValuePair<string, List<int>> entry in gradebook)
        {
            Console.WriteLine($"Student: {entry.Key}");
            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"  {subjects[i]}: {entry.Value[i]}");
            }

            double avg = entry.Value.Average();
            Console.WriteLine($"  Average: {avg:F2}\n");

            if (avg > highestAvg)
            {
                highestAvg = avg;
                topper = entry.Key;
            }
        }

        Console.WriteLine($"Class Topper: {topper} (Average: {highestAvg:F2})\n");

        Console.Write("Search student by name: ");
        string search = Console.ReadLine();

        if (gradebook.ContainsKey(search))
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"  {subjects[i]}: {gradebook[search][i]}");
            }
            Console.WriteLine($"  Average: {gradebook[search].Average():F2}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}


