using FluentAssertions;
using Seller.Shared.DDD.Domain.Models;
using Xunit;

namespace Seller.Listings.Domain.Listings.Models
{
    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            // Arrange
            var first = new UserSeller().SetId("12345678901234567890123456789012");
            var second = new UserSeller().SetId("12345678901234567890123456789012");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            // Arrange
            var first = new UserSeller().SetId("12345678901234567890123456789012");
            var second = new UserSeller().SetId("1234567890123456789012345678901233");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {
        public static TEntity? SetId<TEntity>(this TEntity entity, string id)
            where TEntity : Entity<string>
        {
            return entity.SetId<string>(id) as TEntity;
        }
            

        private static Entity<T> SetId<T>(this Entity<T> entity, string id)
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
