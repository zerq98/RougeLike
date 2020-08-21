using RougeLike.App.Abstract;
using RougeLike.Domain.Common;
using RougeLike.Domain.Entity;
using System;
using System.Collections.Generic;

namespace RougeLike.App.Concrete
{
    public class CharacterService : ICharacterService
    {
        private Character character;

        public CharacterService()
        {
            character = new Character();
        }

        public bool CreateCharacter(CharacterClass selectedClass, string name)
        {
            character.Name = name;
            character.Class = selectedClass;
            character.Money = 0;
            character.NeededExperience = 500;
            character.Experience = 0;
            character.Level = 1;
            character.Inventory = new Inventory { Capacity = 8, Items = new List<Item>() };

            switch (selectedClass)
            {
                case CharacterClass.berserker:
                    character.Health = 300;
                    character.MaxHealth = 300;
                    character.AttackDamage = 30;
                    character.Armor = 5;
                    character.AttackSpeed = 20;
                    break;

                case CharacterClass.mage:
                    character.Health = 100;
                    character.MaxHealth = 100;
                    character.AttackDamage = 45;
                    character.Armor = 5;
                    character.AttackSpeed = 20;
                    break;

                case CharacterClass.warrior:
                    character.Health = 450;
                    character.MaxHealth = 450;
                    character.AttackDamage = 25;
                    character.Armor = 35;
                    character.AttackSpeed = 10;
                    break;

                case CharacterClass.thief:
                    character.Health = 100;
                    character.MaxHealth = 100;
                    character.AttackDamage = 10;
                    character.Armor = 5;
                    character.AttackSpeed = 80;
                    break;

                default:
                    Console.WriteLine("Option you selected doesn't exist");
                    return false;
            }

            return true;
        }

        public void CreateCharacter(Character loadCharacter)
        {
            character = loadCharacter;
        }

        public Character GetCharacter()
        {
            return character;
        }

        public void UpdateCharacter(Character updateModel)
        {
            character = updateModel;
        }

        public List<Item> GetItemList()
        {
            return character.Inventory.Items;
        }

        public bool CheckCapacity()
        {
            return (character.Inventory.Items.Count == character.Inventory.Capacity);
        }
    }
}