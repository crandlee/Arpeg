using System;
using Core.General;
using FluentAssertions;
using Xunit;

namespace Test.Core.General
{
    public class EntityTest
    {
        private class FakeEntityRefTyped : Entity<EntityTestRefIdClass>
        {
            public FakeEntityRefTyped(EntityTestRefIdClass id) : base(id)
            {
            }
        }

        private class FakeEntityValueTyped : Entity<int>
        {
            public FakeEntityValueTyped(int id) : base(id)
            {
            }
        }
       

        //Constructor
        [Fact]
        public void entityid_is_set()
        {
            var rand = new Random().Next();
            var t = new FakeEntityValueTyped(rand);
            t.Id.Should().Be(rand);
        }

        [Fact]
        public void exception_on_default_id()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new FakeEntityValueTyped(default(int));
            action.ShouldThrow<ArgumentException>();
        }

        //Equals(typed)
        [Fact]
        public void parameter_is_null_returns_false()
        {
            var t = new FakeEntityValueTyped(3);
            t.Equals(null).Should().BeFalse();
        }

        [Fact]
        public void reference_equals_returns_true()
        {
            var c = new EntityTestRefIdClass();
            var t = new FakeEntityRefTyped(c);
            var t2 = t;            
            t.Equals(t2).Should().BeTrue();
        }

        [Fact]
        public void types_unequal_returns_false()
        {
            var c = new EntityTestRefIdClass();
            var t = new FakeEntityRefTyped(c);
            var t2 = new FakeEntityValueTyped(3);
            // ReSharper disable once SuspiciousTypeConversion.Global
            t.Equals(t2).Should().BeFalse();
        }

        [Fact]
        public void ids_are_equal_returns_true()
        {
            var t1 = new FakeEntityValueTyped(3);
            var t2 = new FakeEntityValueTyped(3);
            t1.Equals(t2).Should().BeTrue();
        }

        [Fact]
        public void ids_not_equal_returns_false()
        {
            var t1 = new FakeEntityValueTyped(3);
            var t2 = new FakeEntityValueTyped(4);
            t1.Equals(t2).Should().BeFalse();

        }

        //Equals(untyped)
        //
        [Fact]
        public void untyped_object_ids_are_equal_returns_true()
        {
            var t1 = new FakeEntityValueTyped(3);
            var t2 = new FakeEntityValueTyped(3);
            t1.Equals((object) t2).Should().BeTrue();
        }
        //GetHashCode
        [Fact]
        public void GetHashCode_returns_expected_code()
        {
            var t1 = new FakeEntityValueTyped(3);
            var t2 = new FakeEntityValueTyped(3);
            t1.GetHashCode().Equals(t2.GetHashCode()).Should().BeTrue();
        }
        //==
        [Fact]
        public void source_and_target_are_null_return_true()
        {
            Entity<int> t1 = null;
            Entity<int> t2 = null;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            (t1 == t2).Should().BeTrue();
        }

        [Fact]
        public void source_null_return_false()
        {
            Entity<int> t1 = null;
            var t2 = new FakeEntityValueTyped(3);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            (t1 == t2).Should().BeFalse();
        }

        [Fact]
        public void target_null_return_false()
        {
            Entity<int> t2 = null;
            var t1 = new FakeEntityValueTyped(3);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            (t1 == t2).Should().BeFalse();
        }

        [Fact]
        public void equality_returns_true()
        {
            var t1 = new FakeEntityValueTyped(3);
            var t2 = new FakeEntityValueTyped(3);
            (t1 == t2).Should().BeTrue();
        }

        [Fact]
        public void non_equality_returns_true()
        {
            var t1 = new FakeEntityValueTyped(3);
            var t2 = new FakeEntityValueTyped(3);
            (t1 != t2).Should().BeFalse();
        }

    }


    internal class EntityTestRefIdClass
    {

    }


}
