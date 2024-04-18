namespace TwelveDaysOfChristmasSongApp;

public static class VerseGenerator
{
    private static readonly string[] Numerals = [
        "First",
        "Second",
        "Third",
        "Fourth",
        "Fifth",
        "Sixth",
        "Seventh",
        "Eighth",
        "Ninth",
        "Tenth",
        "Eleventh",
        "Twelfth",
    ];

    private static readonly string[] Verses =
    [
        "Twelve drummers drumming",
        "Eleven pipers piping",
        "Ten lords a-leaping",
        "Nine ladies dancing",
        "Eight maids a-milking",
        "Seven swans a-swimming",
        "Six geese a-laying",
        "Five golden rings",
        "Four calling birds",
        "Three French hens",
        "Two turtle doves",
        "A partridge in a pear tree",
    ];

    public static List<string> GenerateFor(int day)
    {
        if (day is < 1 or > 12)
        {
            throw new DayOutOfRange();
        }

        var output = GenerateHeader(day);

        var generateVerses = GenerateVerses(day);
        
        output.AddRange(generateVerses);
        
        return output;
    }

    private static List<string> GenerateVerses(int day)
    {
        var generatedVerses = new List<string>([Verses.Last()]);

        for (int i = 1; i < day; i++)
        {
            generatedVerses.Insert(0, Verses[Verses.Length - 1 - i]);
        }

        return generatedVerses;
    }

    private static List<string> GenerateHeader(int day)
    {
        return new List<string>([
            $"On the {Numerals[day - 1]} day of Christmas",
            "My true love gave to me:",
        ]);
    }
}