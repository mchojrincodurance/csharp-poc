using NUnit.Framework;
using TwelveDaysOfChristmasSongApp;

namespace TwelveDaysOfChristmasSong.Tests
{
    [TestFixture]
    public class VerseGeneratorShould
    {

        [Test]
        [TestCase(0)]
        [TestCase(13)]
        public void reject_inputs_outside_range(int verseNumber)
        {
            var verseGenerator = new VerseGenerator();
            Assert.Throws<VerseNumberOutOfRange>(() => verseGenerator.GenerateVerseFor(verseNumber));
        }

        [Test]
        [TestCase(1, "First")]
        [TestCase(2, "Second")]
        public void generate_header_containing_day_numeral(int verseNumber, string dayNumeral)
        {
            var verseGenerator = new VerseGenerator();
            var firstLine = verseGenerator.GenerateVerseFor(verseNumber).Split("\n")[0];
            
            Assert.That(firstLine, Is.EqualTo($"On the {dayNumeral} day of Christmas,"));
        }
    }
}