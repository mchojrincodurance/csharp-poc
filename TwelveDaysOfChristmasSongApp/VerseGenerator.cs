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

        output.AddRange(GenerateVerses(day));
        
        return output;
    }

    private static List<string> GenerateVerses(int day)
    {
        List<string> verses = new List<string>();

        for (int i = 0; i < day; i++)
        {
            verses.Add(Verses[12 - day]);
        }

        return verses;
    }

    private static List<string> GenerateHeader(int day)
    {
        return new List<string>([
            $"On the {Numerals[day - 1]} day of Christmas",
            "My true love gave to me:",
        ]);
    }
}