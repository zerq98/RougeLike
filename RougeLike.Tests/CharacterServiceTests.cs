using FluentAssertions;
using RougeLike.App.Concrete;
using RougeLike.Domain.Common;
using RougeLike.Domain.Entity;
using System.Collections.Generic;
using Xunit;

namespace RougeLike.Tests
{
    public class CharacterServiceTests
    {
        private CharacterService characterService = new CharacterService();

        private Character character = new Character()
        {
            Name = "Test",
            Class = CharacterClass.berserker,
            Health = 1,
            MaxHealth = 1,
            Level = 1,
            Money = 0,
            Experience = 0,
            NeededExperience = 1,
            Armor = 1,
            AttackDamage = 1,
            AttackSpeed = 1,
            Inventory = new Inventory() { Capacity = 1, Items = new List<Item>() { new Item() { Id = 1 } } }
        };

        [Fact]
        public void Should_Create_Character()
        {
            var isCreated = characterService.CreateCharacter(CharacterClass.warrior, "Test");
            var createdCharacter = characterService.GetCharacter();
            var checkCapacity = characterService.CheckCapacity();

            isCreated.Should().BeTrue();
            createdCharacter.Should().NotBeNull();
            checkCapacity.Should().BeFalse();
        }

        [Fact]
        public void Should_Be_Update_Character()
        {
            characterService.UpdateCharacter(character);

            var characterAfterUpdate = characterService.GetCharacter();
            var checkCapacity = characterService.CheckCapacity();

            characterAfterUpdate.Class.Should().Be(CharacterClass.berserker);
            characterAfterUpdate.AttackDamage.Should().Be(1);
            checkCapacity.Should().BeTrue();
        }
    }
}