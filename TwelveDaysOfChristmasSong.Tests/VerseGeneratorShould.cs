using System.Linq;
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
            Assert.Throws<DayOutOfRange>(() => VerseGenerator.GenerateForDay(verseNumber));
        }

        [Test]
        [TestCase(1, "First")]
        [TestCase(2, "Second")]
        [TestCase(3, "Third")]
        [TestCase(4, "Fourth")]
        [TestCase(5, "Fifth")]
        [TestCase(6, "Sixth")]
        [TestCase(7, "Seventh")]
        [TestCase(8, "Eighth")]
        [TestCase(9, "Ninth")]
        [TestCase(10, "Tenth")]
        [TestCase(11, "Eleventh")]
        [TestCase(12, "Twelfth")]
        public void generate_header_containing_day_numeral(int verseNumber, string dayNumeral)
        {
            var firstLine = VerseGenerator.GenerateForDay(verseNumber)[0];
            
            Assert.That(firstLine, Is.EqualTo($"On the {dayNumeral} day of Christmas"));
        }

        [Test]
        public void generate_header_containing_opening_line()
        {
            var secondLine = VerseGenerator.GenerateForDay(1)[1];
            
            Assert.That(secondLine, Is.EqualTo("My true love gave to me:"));         
            
        }

        [Test]
        public void generate_verse_for_day_one()
        {
            var lastLine = VerseGenerator.GenerateForDay(1).Last();
            Assert.That(lastLine, Is.EqualTo("A partridge in a pear tree"));
        }

        [Test]
        [TestCase(2, "Two turtle doves")]
        [TestCase(3, "Three French hens")]
        [TestCase(4, "Four calling birds")]
        [TestCase(5, "Five golden rings")]
        [TestCase(6, "Six geese a-laying")]
        [TestCase(7, "Seven swans a-swimming")]
        [TestCase(8, "Eight maids a-milking")]
        [TestCase(9, "Nine ladies dancing")]
        [TestCase(10, "Ten lords a-leaping")]
        [TestCase(11, "Eleven pipers piping")]
        [TestCase(12, "Twelve drummers drumming")]
        public void generate_the_correct_last_verse(int day, string lastVerse)
        {
            var lines = VerseGenerator.GenerateForDay(day);
            var lastLine = lines.Last();
            Assert.That(lastLine, Is.EqualTo(lastVerse));
        }
    }
}