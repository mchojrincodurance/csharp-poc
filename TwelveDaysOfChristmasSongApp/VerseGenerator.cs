namespace TwelveDaysOfChristmasSongApp;

public class VerseGenerator
{
    public string GenerateVerseFor(int i)
    {
        if (i == 1)
        {
            return "On the First day of Christmas,";
        }
        throw new VerseNumberOutOfRange();
    }
}