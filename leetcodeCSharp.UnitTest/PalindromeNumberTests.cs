using System;
using leetcodeCSharp;
using NUnit.Framework;

namespace leetcodeCSharp.UnitTest
{
    [TestFixture]
    public class PalindromeNumberTests
    {
        [Test]
        public void IsPalindrome_Negative_False()
        {
            var r0 = PalindromeNumber.IsPalindrome(-10);
            Assert.That(r0 == false);
        }
        
        [Test]
        public void IsPalindrome_positive_true()
        {
            var r0 = PalindromeNumber.IsPalindrome(5);
            var r1 = PalindromeNumber.IsPalindrome(22);
            var r2 = PalindromeNumber.IsPalindrome(23432);

            Assert.IsTrue(r0);
            Assert.IsTrue(r1);
            Assert.IsTrue(r2);
        }

        [Test]
        public void IsPalindrome_positive_false()
        {
            var r1 = PalindromeNumber.IsPalindrome(68);
            var r2 = PalindromeNumber.IsPalindrome(46234);

            Assert.IsFalse(r1);
            Assert.IsFalse(r2);
        }

        [Test]
        public void IsPalindrome_overflow_false()
        {
            var r = PalindromeNumber.IsPalindrome(1234567895);
            Assert.IsFalse(r);
        }
    }
}
