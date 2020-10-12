using FluentAssertions;
using Seller.Shared.DDD.Domain.Models;
using Xunit;

namespace Seller.Listings.Domain.Listings.Models
{
    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new TestValueObject("a");
            var second = new TestValueObject("a");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new TestValueObject("b");
            var second = new TestValueObject("a");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }

        private class TestValueObject : ValueObject
        {
            public TestValueObject(string name)
            {
                this.Name = name;
            }

            public string Name { get;  }
        }
    }
}
