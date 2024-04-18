using System;
using System.Collections.Generic;
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
        [TestCase(2, new String[]{"A partridge in a pear tree", "Two turtle doves"})]
        [TestCase(3, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens"})]
        [TestCase(4, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds"})]
        [TestCase(5, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings"})]
        [TestCase(6, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying"})]
        [TestCase(7, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying", "Seven swans a-swimming"})]
        [TestCase(8, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying", "Seven swans a-swimming", "Eight maids a-milking"})]
        [TestCase(9, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying", "Seven swans a-swimming", "Eight maids a-milking", "Nine ladies dancing"})]
        [TestCase(10, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying", "Seven swans a-swimming", "Eight maids a-milking", "Nine ladies dancing", "Ten lords a-leaping"})]
        [TestCase(11, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying", "Seven swans a-swimming", "Eight maids a-milking", "Nine ladies dancing", "Ten lords a-leaping", "Eleven pipers piping"})]
        [TestCase(12, new String[]{"A partridge in a pear tree", "Two turtle doves", "Three French hens", "Four calling birds", "Five golden rings", "Six geese a-laying", "Seven swans a-swimming", "Eight maids a-milking", "Nine ladies dancing", "Ten lords a-leaping", "Eleven pipers piping", "Twelve drummers drumming"})]
        public void generate_the_correct_sequence(int day, string[] verses)
        {
            var output = VerseGenerator.GenerateFor(day);
            output.RemoveRange(0, 2);
            
            Assert.That(output.ToArray(), Is.EqualTo(verses));
        }
    }
}