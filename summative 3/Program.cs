// See https://aka.ms/new-console-template for more information

Console.WriteLine("Oyster Eating Competition");
Console.WriteLine("How many competitors are there?");
int numofcomp = ReadInt();

string[] compsnames = new string[numofcomp];
int[] oysterseaten = new int[numofcomp];

for (int i = 0; i < compsnames.Length; i++)
{
    Console.WriteLine("What is the name of competitor number " + (i + 1) + "?");
    compsnames[i] = Console.ReadLine();
    Console.WriteLine("How many oysters did " + compsnames[i] + " eat?");
    oysterseaten[i] = ReadInt();
}

// Bubble sort the competitors by the number of oysters eaten in descending order
for (int i = 0; i < oysterseaten.Length - 1; i++)
{
    for (int j = 0; j < oysterseaten.Length - 1 - i; j++)
    {
        if (oysterseaten[j] < oysterseaten[j + 1])
        {
            int tempOysters = oysterseaten[j];
            oysterseaten[j] = oysterseaten[j + 1];
            oysterseaten[j + 1] = tempOysters;

            string tempName = compsnames[j];
            compsnames[j] = compsnames[j + 1];
            compsnames[j + 1] = tempName;
        }
    }
}

// Write results to file and display them
using (StreamWriter writer = new StreamWriter("competition_results.txt"))
{
    writer.WriteLine("Oyster Eating Competition Results");
    for (int i = 0; i < compsnames.Length; i++)
    {
        string resultLine = $"{i + 1}. {compsnames[i]} ate {oysterseaten[i]} oysters";
        writer.WriteLine(resultLine);
        Console.WriteLine(resultLine);  // Display the same line to console
    }
}

// Helper method to read integers from console
static int ReadInt()
{
    int number;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
        {
            return number;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid positive number.");
        }
    }
}