﻿using RougeLike.Helpers;
using RougeLike.Menu;
using RougeLike.StuffFiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RougeLike.PlayerFiles
{
    public class CharacterService
    {
        private Character character;

        public CharacterService()
        {
            character = new Character();
        }

        public Class CreateCharacterView(MenuActionService actionService)
        {
            List<MenuAction> selectClassMenu = actionService.GetMenuActionsByMenuName("Select Class");
            int selectedClass;

            Console.WriteLine("Select class for your hero:");
            Console.WriteLine();

            for (int i = 0; i < selectClassMenu.Count; i++)
            {
                Console.WriteLine($"{selectClassMenu[i].Id}. {selectClassMenu[i].Name}");
            }

            var readedKey = Console.ReadKey();
            Int32.TryParse(readedKey.KeyChar.ToString(), out selectedClass);

            return (Class)selectedClass;
        }

        public bool CreateCharacter(Class selectedClass)
        {
            Console.WriteLine();
            Console.WriteLine($"Select name for your {selectedClass}");

            character.Name = Console.ReadLine();
            character.Class = selectedClass;
            character.Money = 0;
            character.NeededExperience = 500;
            character.Experience = 0;
            character.Level = 1;
            character.Inventory = new Inventory { Capacity = 8, Items = new List<StuffFiles.Item>() };

            switch (selectedClass)
            {
                case Class.berserker:
                    character.Health = 300;
                    character.MaxHealth = 300;
                    character.AttackDamage = 30;
                    character.Armor = 5;
                    character.AttackSpeed = 20;
                    break;

                case Class.mage:
                    character.Health = 100;
                    character.MaxHealth = 100;
                    character.AttackDamage = 45;
                    character.Armor = 5;
                    character.AttackSpeed = 20;
                    break;

                case Class.warrior:
                    character.Health = 450;
                    character.MaxHealth = 450;
                    character.AttackDamage = 25;
                    character.Armor = 35;
                    character.AttackSpeed = 10;
                    break;

                case Class.thief:
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

        public bool LoadCharacter()
        {
            try
            {
                character = SaveManager.Load();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveCharacter()
        {
            try
            {
                SaveManager.Save(character);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetCharacterName()
        {
            return character.Name;
        }

        public int CharacterInfo()
        {
            Console.Clear();
            Console.WriteLine("Your character:");
            Console.WriteLine($"Name: {character.Name}");
            Console.WriteLine($"Level: {character.Level} ({character.Experience}/{character.NeededExperience})");
            Console.WriteLine($"Money: {character.Money}");
            Console.WriteLine($"Class: {character.Class}");
            Console.WriteLine($"Attack: {character.AttackDamage}");
            Console.WriteLine($"Armor: {character.Armor}");
            Console.WriteLine($"Attack speed: {character.AttackSpeed}");
            Console.WriteLine();
            Console.WriteLine("1. Exit");

            int selectedAction;

            var readedKey = Console.ReadKey();
            Int32.TryParse(readedKey.KeyChar.ToString(), out selectedAction);

            return selectedAction;
        }

        public int GetHeroLevel()
        {
            return character.Level;
        }

        public Class GetHeroClass()
        {
            return character.Class;
        }

        public void ShowHeroInfoInFight()
        {
            Console.WriteLine($"Name: {character.Name}");
            Console.WriteLine($"Health: {character.Health}");
        }

        public int[] GetHiddenStats()
        {
            return new int[] { character.AttackDamage, character.AttackSpeed, character.Armor };
        }

        public bool GetDamage(int enemyAttack)
        {
            int armorInFight = character.Armor;
            while (enemyAttack <= armorInFight)
            {
                armorInFight /= 2;
            }

            character.Health -= (enemyAttack - armorInFight);
            Console.Clear();
            Console.WriteLine($"Enemy dealt {(enemyAttack - armorInFight)}");
            Console.WriteLine("Click enter to continue...");
            Console.Read();
            if (character.Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateCharacterAfterFight(int money, int experience)
        {
            character.Money += money;
            character.Experience += experience;
            if (character.Experience >= character.NeededExperience)
            {
                character.Level++;
                character.Experience -= character.NeededExperience;
                character.NeededExperience += 500 * (character.Level - 1);
                character.MaxHealth += 200;
                character.Armor += 10;
                character.AttackDamage += 15;
                character.AttackSpeed += 15;
            }
        }

        public int GetMoneyCount()
        {
            return character.Money;
        }

        public void Heal()
        {
            character.Health = character.MaxHealth;
        }

        public bool Heal(int cost)
        {
            if (cost <= character.Money)
            {
                character.Health = character.MaxHealth;
                return true;
            }
            return false;
        }

        public List<Item> GetItems()
        {
            return character.Inventory.Items.ToList();
        }

        public void UseItem(int itemId)
        {
            character.Health += character.Inventory.Items[itemId].Value;
            character.Inventory.Items.RemoveAt(itemId);
        }

        public bool CheckIsInventoryFull()
        {
            return (character.Inventory.Items.Count == character.Inventory.Capacity);
        }

        public int AddItemToInventory(Item item)
        {
            character.Inventory.Items.Add(item);

            if (!item.IsUsable)
            {
                switch (item.HeroStatToChange)
                {
                    case "Attack Damage":
                        character.AttackDamage += item.Value;
                        break;

                    case "Attack Speed":
                        character.AttackSpeed += item.Value;
                        break;

                    case "Armor":
                        character.Armor += item.Value;
                        break;

                    case "Health":
                        character.Health += item.Value;
                        break;
                }
            }

            return character.Inventory.Items.Count;
        }

        public int SellItem(int id)
        {
            Item item = character.Inventory.Items[id];

            if (!item.IsUsable)
            {
                switch (item.HeroStatToChange)
                {
                    case "Attack Damage":
                        character.AttackDamage -= item.Value;
                        break;

                    case "Attack Speed":
                        character.AttackSpeed -= item.Value;
                        break;

                    case "Armor":
                        character.Armor -= item.Value;
                        break;

                    case "Health":
                        character.Health -= item.Value;
                        break;
                }
            }

            character.Money += (item.Cost / 2);

            character.Inventory.Items.Remove(item);

            return character.Money;
        }

        public bool CanBuy(int cost)
        {
            if (!CheckIsInventoryFull() && character.Money >= cost)
            {
                return true;
            }

            return false;
        }

        public void BuyItem(Item item)
        {
            character.Money -= item.Cost;
            AddItemToInventory(item);
        }
    }
}