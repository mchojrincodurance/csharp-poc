using NUnit.Framework;
using TwelveDaysOfChristmasSongApp;

namespace TwelveDaysOfChristmasSong.Tests
{
    [TestFixture]
    public class VerseGeneratorShould
    {

        [Test]
        public void reject_inputs_outside_range()
        {
            var verseGenerator = new VerseGenerator();
            Assert.Throws<VerseNumberOutOfRange>(() => verseGenerator.GenerateVerseFor(0));
        }
    }
}