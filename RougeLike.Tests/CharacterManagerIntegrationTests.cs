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
            var manager = new CharacterManager(new MenuActionService(), new CharacterService());

            var result = manager.CreateCharacter(CharacterClass.warrior, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(CharacterClass));
            createdClass.Should().Be(CharacterClass.warrior);
        }

        [Fact]
        public void Should_Create_Mage()
        {
            var manager = new CharacterManager(new MenuActionService(), new CharacterService());

            var result = manager.CreateCharacter(CharacterClass.mage, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(CharacterClass));
            createdClass.Should().Be(CharacterClass.mage);
        }

        [Fact]
        public void Should_Create_Berserker()
        {
            var manager = new CharacterManager(new MenuActionService(), new CharacterService());

            var result = manager.CreateCharacter(CharacterClass.berserker, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(CharacterClass));
            createdClass.Should().Be(CharacterClass.berserker);
        }

        [Fact]
        public void Should_Create_Thief()
        {
            var manager = new CharacterManager(new MenuActionService(), new CharacterService());

            var result = manager.CreateCharacter(CharacterClass.thief, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeTrue();
            createdClass.Should().NotBeNull();
            createdClass.Should().BeOfType(typeof(CharacterClass));
            createdClass.Should().Be(CharacterClass.thief);
        }

        [Fact]
        public void Should_Create_Empty_Hero()
        {
            var manager = new CharacterManager(new MenuActionService(), new CharacterService());

            var result = manager.CreateCharacter(CharacterClass.none, "Test");

            var createdClass = manager.GetHeroClass();

            result.Should().BeFalse();
            createdClass.Should().NotBeNull();
            createdClass.Should().Be(CharacterClass.none);
        }
    }
}