using NUnit.Framework;
using TwelveDaysOfChristmasSongApp;

namespace TwelveDaysOfChristmasSong.Tests
{
    [TestFixture]
    public class VerseGeneratorShould
    {
        private readonly VerseGenerator _verseGenerator = new VerseGenerator();

        [Test]
        [TestCase(0)]
        [TestCase(13)]
        public void reject_inputs_outside_range(int verseNumber)
        {
            Assert.Throws<VerseNumberOutOfRange>(() => _verseGenerator.GenerateVerseFor(verseNumber));
        }

        [Test]
        [TestCase(1, "First")]
        [TestCase(2, "Second")]
        [TestCase(3, "Third")]
        public void generate_header_containing_day_numeral(int verseNumber, string dayNumeral)
        {
            var firstLine = _verseGenerator.GenerateVerseFor(verseNumber).Split("\n")[0];
            
            Assert.That(firstLine, Is.EqualTo($"On the {dayNumeral} day of Christmas,"));
        }

        [Test]
        public void generate_header_containing_opening_line()
        {
            var secondLine = _verseGenerator.GenerateVerseFor(1).Split("\n")[1];
            
            Assert.That(secondLine, Is.EqualTo("My true love gave to me:"));         
            
        }
    }
}