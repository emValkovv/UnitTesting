namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ShouldReturnCommand_IfValidString()
        {
            var input = "AddToCategory ForMale Cool";

            var result = Command.Parse(input);

            Assert.IsInstanceOf<Command>(result);
        }

        [Test]
        public void Parse_ShouldSetCorrectlyNameAndParams()
        {
            var input = "AddToCategory ForMale Cool";
            var executeProp = "AddToCategory";

            var result = Command.Parse(input);

            Assert.AreEqual(executeProp, result.Name);
        }

        [Test]
        public void Parse_ShouldNotReturnCommand_IfStringIsNull()
        {
            string input = null;

            Assert.Throws<NullReferenceException>(() => Command.Parse(input));
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullException_IfNameIsNullOrEmpty()
        {
            var input = "  ForMale Cool";

            Assert.Throws<ArgumentNullException>(() => Command.Parse(input), "Name");
        }

        [Test]
        public void Parse_ShouldThrowArgumentNullException_IfListIsNullOrEmpty()
        {
            var input = "AddToCategory  ";

            Assert.Throws<ArgumentNullException>(() => Command.Parse(input), "List");
        }
    }
}
