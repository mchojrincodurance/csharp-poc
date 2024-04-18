// See https://aka.ms/new-console-template for more information

using TwelveDaysOfChristmasSongApp;

Console.WriteLine("Enter a day number between 1 and 12");
var day = Console.In.ReadLine();
var output = VerseGenerator.GenerateFor(Int32.Parse(day));

Console.WriteLine(string.Join(",\n", output.ToArray()));

if (output.Count > 3)
{
    
}