namespace Cosmetics.Tests.Common
{
    using System;

    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_ShouldReturnNullReferenceException()
        {
            object obj = null;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfNull_ShouldNotReturnExceptio_IfNotNull()
        {
            object obj = new object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfCheckIfStringIsNullOrEmpty_ShouldThrowException_IfObjectIsNull(string a)
        {
            string textTest = a;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(textTest));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrowException_IfItsNotNull()
        {
            string textTest = "NotThrowException";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(textTest));
        }

        [TestCase(0, 20)]
        [TestCase(1, 15)]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRange_WhenNotInRange(int min, int max)
        {
            string textTest = "ShouldThrowIndexOutOfRange";

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(textTest, min, max));
        }

        [Test]
        public void CheckIfStringLengthIsValid_ShouldNotThrowException_IfInRange()
        {
            string textTest = "NotThrowException";

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(textTest, 20));
        }
    }
}
