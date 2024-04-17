namespace TwelveDaysOfChristmasSongApp;

public class VerseGenerator
{
    public string GenerateVerseFor(int verseNumber)
    {
        string[] numerals =
        {
            "First",
            "Second",
            "Third",
        };

        if (verseNumber is < 1 or > 12)
        {
            throw new VerseNumberOutOfRange();
        }
        
        return $"On the {numerals[verseNumber]} day of Christmas,\nMy true love gave to me:\n";
    }
}