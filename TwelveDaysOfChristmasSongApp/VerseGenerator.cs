namespace TwelveDaysOfChristmasSongApp;

public class VerseGenerator
{
    public static string[] GenerateVerseFor(int verseNumber)
    {
        string[] numerals =
        [
            "First",
            "Second",
            "Third"
        ];

        if (verseNumber is < 1 or > 12)
        {
            throw new VerseNumberOutOfRange();
        }

        return
        [
            $"On the {numerals[verseNumber - 1]} day of Christmas,",
            "My true love gave to me:",
        ];
    }
}