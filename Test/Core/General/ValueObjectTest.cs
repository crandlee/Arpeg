using Core.General;
using FluentAssertions;
using Xunit;

namespace Test.Core.General
{
    public class ValueObjectTest
    {
        private class FakeValueObject : ValueObject<FakeValueObject>
        {
            public FakeValueObject(int someProp)
            {
                SomeProp = someProp;
            }

            private int SomeProp { get; }

            protected override bool EqualsCore(FakeValueObject other)
            {
                return SomeProp.Equals(other.SomeProp);
            }

            protected override int GetHashCodeCore()
            {
                return SomeProp.GetHashCode();
            }
        }

        [Fact]
        public void equals_returns_false_when_target_null()
        {
            var t1 = new FakeValueObject(4);
            FakeValueObject t2 = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            t1.Equals(t2).Should().BeFalse();
        }

        [Fact]
        public void checks_for_equality_in_subclass()
        {
            var t1 = new FakeValueObject(4);
            var t2 = new FakeValueObject(4);
            t1.Equals(t2).Should().BeTrue();
        }

        [Fact]
        public void GetHashCode_returns_proper_code()
        {
            var t1 = new FakeValueObject(4);
            var testHashCode = 4.GetHashCode();
            t1.GetHashCode().ShouldBeEquivalentTo(testHashCode);
        }

        [Fact]
        public void source_null_return_false()
        {
            FakeValueObject t1 = null;
            var t2 = new FakeValueObject(3);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            (t1 == t2).Should().BeFalse();
        }

        [Fact]
        public void target_null_return_false()
        {
            FakeValueObject t2 = null;
            var t1 = new FakeValueObject(3);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            (t1 == t2).Should().BeFalse();
        }

        [Fact]
        public void equality_returns_true()
        {
            var t1 = new FakeValueObject(3);
            var t2 = new FakeValueObject(3);
            (t1 == t2).Should().BeTrue();
        }

        [Fact]
        public void non_equality_returns_true()
        {
            var t1 = new FakeValueObject(3);
            var t2 = new FakeValueObject(3);
            (t1 != t2).Should().BeFalse();
        }


    }


}
