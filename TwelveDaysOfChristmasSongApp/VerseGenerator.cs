namespace TwelveDaysOfChristmasSongApp;

public class VerseGenerator
{
    public string GenerateVerseFor(int i)
    {
        string numeral;
        
        switch(i) {
            case 1 : numeral = "First";
                break;
            case 2: numeral = "Second";
                break;
            case 3: numeral = "Third";
                break;
            default:
                throw new VerseNumberOutOfRange();
        }
        
        return $"On the {numeral} day of Christmas,\nMy true love gave to me:\n";
    }
}