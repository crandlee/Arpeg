using System;
using Xunit;
using Core;
using FluentAssertions;

namespace Test.Core
{
    public class CharacterTest
    {
        [Fact]
        public void IdIsSet()
        {
            var testId = Guid.NewGuid();
            var c = new Character(testId);
            c.Id.Should().Be(testId);
        }

    }
}
