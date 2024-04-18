using System;
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
        [TestCase(1, new String[]{"A partridge in a pear tree"})]
        [TestCase(2, new String[]{"Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(3, new String[]{"Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(4, new String[]{"Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(5, new String[]{"Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(6, new String[]{"Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(7, new String[]{"Seven swans a-swimming", "Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(8, new String[]{"Eight maids a-milking", "Seven swans a-swimming", "Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(9, new String[]{"Nine ladies dancing", "Eight maids a-milking", "Seven swans a-swimming", "Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(10, new String[]{"Ten lords a-leaping", "Nine ladies dancing", "Eight maids a-milking", "Seven swans a-swimming", "Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(11, new String[]{"Eleven pipers piping", "Ten lords a-leaping", "Nine ladies dancing", "Eight maids a-milking", "Seven swans a-swimming", "Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        [TestCase(12, new String[]{"Twelve drummers drumming", "Eleven pipers piping", "Ten lords a-leaping", "Nine ladies dancing", "Eight maids a-milking", "Seven swans a-swimming", "Six geese a-laying", "Five golden rings", "Four calling birds", "Three French hens", "Two turtle doves", "A partridge in a pear tree",})]
        
        public void generate_the_correct_sequence(int day, string[] verses)
        {
            var output = VerseGenerator.GenerateFor(day);
            output.RemoveRange(0, 2);
            
            Assert.That(output.ToArray(), Is.EqualTo(verses));
        }
    }
}