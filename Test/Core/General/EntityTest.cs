using System;
using Core.General;
using FluentAssertions;
using Xunit;

namespace Test.Core.General
{
    public class EntityTest
    {
        private class MockEntityRefTyped : Entity<SomeRefIdClass>
        {
            public MockEntityRefTyped(SomeRefIdClass id) : base(id)
            {
            }
        }

        private class MockEntityValueTyped : Entity<int>
        {
            public MockEntityValueTyped(int id) : base(id)
            {
            }
        }
       

        //Constructor
        [Fact]
        public void entityid_is_set()
        {
            var rand = new Random().Next();
            var t = new MockEntityValueTyped(rand);
            t.Id.Should().Be(rand);
        }

        [Fact]
        public void exception_on_default_id()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new MockEntityValueTyped(default(int));
            action.ShouldThrow<ArgumentException>();
        }

        //Equals(typed)
        [Fact]
        public void parameter_is_null_returns_false()
        {
            var t = new MockEntityValueTyped(3);
            t.Equals(null).Should().BeFalse();
        }

        [Fact]
        public void reference_equals_returns_true()
        {
            var c = new SomeRefIdClass();
            var t = new MockEntityRefTyped(c);
            var t2 = t;            
            t.Equals(t2).Should().BeTrue();
        }

        [Fact]
        public void types_unequal_returns_false()
        {
            var c = new SomeRefIdClass();
            var t = new MockEntityRefTyped(c);
            var t2 = new MockEntityValueTyped(3);
            t.Equals(t2).Should().BeFalse();
        }

        [Fact]
        public void ids_are_equal_returns_true()
        {
            var t1 = new MockEntityValueTyped(3);
            var t2 = new MockEntityValueTyped(3);
            t1.Equals(t2).Should().BeTrue();
        }

        [Fact]
        public void ids_not_equal_returns_false()
        {
            var t1 = new MockEntityValueTyped(3);
            var t2 = new MockEntityValueTyped(4);
            t1.Equals(t2).Should().BeFalse();

        }

        //Equals(untyped)
        //Calls into Equals(typed)
        //GetHashCode
        //Returns expected code
        //==
        //source and target are null return true
        //source is null only return false
        //target is null only return false
        //calls into Equals(typed)
        //!=
        //Returns the opposite of ==
    }


    internal class SomeRefIdClass
    {

    }


}
