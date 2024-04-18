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
            Assert.Throws<DayOutOfRange>(() => VerseGenerator.GenerateFor(verseNumber));
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
            Assert.That(VerseGenerator.GenerateFor(verseNumber).First(), Is.EqualTo($"On the {dayNumeral} day of Christmas"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        public void generate_header_containing_opening_line(int day)
        {
            Assert.That(VerseGenerator.GenerateFor(day)[1], Is.EqualTo("My true love gave to me:"));
        }

        [Test]
        [TestCase(1, "A partridge in a pear tree")]
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
        public void add_the_new_verse_at_the_beginning(int day, string newVerse)
        {
            var newSequence = VerseGenerator.GenerateFor(day);
            newSequence.RemoveRange(0, 2);
            
            Assert.That(newSequence.First(), Is.EqualTo(newVerse));
        }

        [Test]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(9)]
        [TestCase(12)]
        public void only_add_new_verse_to_previous_sequence(int day)
        {
            var previousSequence = VerseGenerator.GenerateFor(day - 1);
            previousSequence.RemoveRange(0, 2);
            var currentSequence = VerseGenerator.GenerateFor(day);
            currentSequence.RemoveRange(0, 2);
            
            previousSequence.Insert(0, currentSequence.First());
            
            Assert.That(previousSequence, Is.EqualTo(currentSequence));
        }
    }
}