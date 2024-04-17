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
        public void generate_header_containing_day_numeral()
        {
            var verseGenerator = new VerseGenerator();
            var firstLine = verseGenerator.GenerateVerseFor(1).Split("\n")[0];
            
            Assert.That(firstLine, Is.EqualTo("On the First day of Christmas,"));
        }
    }
}