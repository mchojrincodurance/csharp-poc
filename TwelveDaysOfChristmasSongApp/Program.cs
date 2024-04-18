// See https://aka.ms/new-console-template for more information

using TwelveDaysOfChristmasSongApp;

Console.WriteLine("Enter a day number between 1 and 12");
var day = Console.In.ReadLine();
var output = VerseGenerator.GenerateFor(Int32.Parse(day));

Console.WriteLine(string.Join("\n", output.GetRange(0, 2).ToArray()));
Console.WriteLine(string.Join(",\n", output.GetRange(2, output.Count - 3)));
if (output.Count > 3)
{
    Console.WriteLine("And " + output.Last().ToLower());
}
else
{
    Console.WriteLine(output.Last());
}