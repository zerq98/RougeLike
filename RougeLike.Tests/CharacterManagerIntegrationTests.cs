using FluentAssertions;
using RougeLike.App.Concrete;
using RougeLike.App.Managers;
using RougeLike.Domain.Common;
using Xunit;

namespace RougeLike.Tests
{
    public class CharacterManagerIntegrationTests
    {
        [Fact]
        public void Should_Create_Warrior()
        {
            var manager = new CharacterManager(new CharacterService());

            var result = manager.CreateCharacter(Class.warrior, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(Class));
            createdClass.Should().Be(Class.warrior);
        }

        [Fact]
        public void Should_Create_Mage()
        {
            var manager = new CharacterManager(new CharacterService());

            var result = manager.CreateCharacter(Class.mage, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(Class));
            createdClass.Should().Be(Class.mage);
        }

        [Fact]
        public void Should_Create_Berserker()
        {
            var manager = new CharacterManager(new CharacterService());

            var result = manager.CreateCharacter(Class.berserker, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(Class));
            createdClass.Should().Be(Class.berserker);
        }

        [Fact]
        public void Should_Create_Thief()
        {
            var manager = new CharacterManager(new CharacterService());

            var result = manager.CreateCharacter(Class.thief, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(Class));
            createdClass.Should().Be(Class.thief);
        }

        [Fact]
        public void Should_Create_Empty_Hero()
        {
            var manager = new CharacterManager(new CharacterService());

            var result = manager.CreateCharacter(Class.none, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeFalse();
            createdClass.Should().NotBeNull();
            createdClass.Should().Be(Class.none);
        }
    }
}