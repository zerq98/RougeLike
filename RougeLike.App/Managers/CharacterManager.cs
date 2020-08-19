using RougeLike.App.Abstract;
using RougeLike.App.Concrete;
using RougeLike.Domain.Common;
using RougeLike.Domain.Entity;
using System;
using System.Collections.Generic;

namespace RougeLike.App.Managers
{
    public class CharacterManager
    {
        private readonly ICharacterService _characterService;
        private Character characterUpdateModel;

        public CharacterManager(ICharacterService characterService)
        {
            _characterService = characterService;
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

        public bool CreateCharacter(Class selectedClass,string name)
        {
            return _characterService.CreateCharacter(selectedClass,name);
        }

        public bool LoadCharacter()
        {
            try
            {
                _characterService.CreateCharacter(SaveManager.Load());
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
                SaveManager.Save(_characterService.GetCharacter());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetCharacterName()
        {
            return _characterService.GetCharacter().Name;
        }

        public int CharacterInfo()
        {
            characterUpdateModel = _characterService.GetCharacter();

            Console.Clear();
            Console.WriteLine("Your character:");
            Console.WriteLine($"Name: {characterUpdateModel.Name}");
            Console.WriteLine($"Level: {characterUpdateModel.Level} ({characterUpdateModel.Experience}/{characterUpdateModel.NeededExperience})");
            Console.WriteLine($"Money: {characterUpdateModel.Money}");
            Console.WriteLine($"Class: {characterUpdateModel.Class}");
            Console.WriteLine($"Attack: {characterUpdateModel.AttackDamage}");
            Console.WriteLine($"Armor: {characterUpdateModel.Armor}");
            Console.WriteLine($"Attack speed: {characterUpdateModel.AttackSpeed}");
            Console.WriteLine();
            Console.WriteLine("1. Exit");

            int selectedAction;

            var readedKey = Console.ReadKey();
            Int32.TryParse(readedKey.KeyChar.ToString(), out selectedAction);

            return selectedAction;
        }

        public int GetHeroLevel()
        {
            return _characterService.GetCharacter().Level;
        }

        public Class GetHeroClass()
        {
            return _characterService.GetCharacter().Class;
        }

        public void ShowHeroInfoInFight()
        {
            characterUpdateModel = _characterService.GetCharacter();

            Console.WriteLine($"Name: {characterUpdateModel.Name}");
            Console.WriteLine($"Health: {characterUpdateModel.Health}");
        }

        public int[] GetHiddenStats()
        {
            characterUpdateModel = _characterService.GetCharacter();

            return new int[] { characterUpdateModel.AttackDamage, characterUpdateModel.AttackSpeed, characterUpdateModel.Armor };
        }

        public bool GetDamage(int enemyAttack)
        {
            characterUpdateModel = _characterService.GetCharacter();

            int armorInFight = characterUpdateModel.Armor;
            while (enemyAttack <= armorInFight)
            {
                armorInFight /= 2;
            }

            characterUpdateModel.Health -= (enemyAttack - armorInFight);
            Console.Clear();
            Console.WriteLine($"Enemy dealt {(enemyAttack - armorInFight)}");
            _characterService.UpdateCharacter(characterUpdateModel);
            Console.WriteLine("Click enter to continue...");
            Console.Read();
            if (characterUpdateModel.Health > 0)
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
            characterUpdateModel = _characterService.GetCharacter();

            characterUpdateModel.Money += money;
            characterUpdateModel.Experience += experience;
            if (characterUpdateModel.Experience >= characterUpdateModel.NeededExperience)
            {
                characterUpdateModel.Level++;
                characterUpdateModel.Experience -= characterUpdateModel.NeededExperience;
                characterUpdateModel.NeededExperience += 500 * (characterUpdateModel.Level - 1);
                characterUpdateModel.MaxHealth += 200;
                characterUpdateModel.Armor += 10;
                characterUpdateModel.AttackDamage += 15;
                characterUpdateModel.AttackSpeed += 15;
            }

            _characterService.UpdateCharacter(characterUpdateModel);
        }

        public int GetMoneyCount()
        {
            return _characterService.GetCharacter().Money;
        }

        public void Heal()
        {
            characterUpdateModel = _characterService.GetCharacter();

            characterUpdateModel.Health = characterUpdateModel.MaxHealth;

            _characterService.UpdateCharacter(characterUpdateModel);
        }

        public bool Heal(int cost)
        {
            characterUpdateModel = _characterService.GetCharacter();

            if (cost <= characterUpdateModel.Money)
            {
                characterUpdateModel.Health = characterUpdateModel.MaxHealth;
                characterUpdateModel.Money -= cost;
                _characterService.UpdateCharacter(characterUpdateModel);
                return true;
            }
            return false;
        }

        public List<Item> GetItems()
        {
            return _characterService.GetItemList();
        }

        public void UseItem(int itemId)
        {
            characterUpdateModel = _characterService.GetCharacter();

            characterUpdateModel.Health += characterUpdateModel.Inventory.Items[itemId].Value;
            characterUpdateModel.Inventory.Items.RemoveAt(itemId);

            _characterService.UpdateCharacter(characterUpdateModel);
        }

        public bool CheckIsInventoryFull()
        {
            return _characterService.CheckCapacity();
        }

        public int AddItemToInventory(Item item)
        {
            characterUpdateModel = _characterService.GetCharacter();

            characterUpdateModel.Inventory.Items.Add(item);

            if (!item.IsUsable)
            {
                switch (item.HeroStatToChange)
                {
                    case "Attack Damage":
                        characterUpdateModel.AttackDamage += item.Value;
                        break;

                    case "Attack Speed":
                        characterUpdateModel.AttackSpeed += item.Value;
                        break;

                    case "Armor":
                        characterUpdateModel.Armor += item.Value;
                        break;

                    case "Health":
                        characterUpdateModel.Health += item.Value;
                        break;
                }
            }

            _characterService.UpdateCharacter(characterUpdateModel);

            return characterUpdateModel.Inventory.Items.Count;
        }

        public void SellItem(int id)
        {
            characterUpdateModel = _characterService.GetCharacter();

            Item item = characterUpdateModel.Inventory.Items[id];

            if (!item.IsUsable)
            {
                switch (item.HeroStatToChange)
                {
                    case "Attack Damage":
                        characterUpdateModel.AttackDamage -= item.Value;
                        break;

                    case "Attack Speed":
                        characterUpdateModel.AttackSpeed -= item.Value;
                        break;

                    case "Armor":
                        characterUpdateModel.Armor -= item.Value;
                        break;

                    case "Health":
                        characterUpdateModel.Health -= item.Value;
                        break;
                }
            }

            characterUpdateModel.Money += (item.Cost / 2);

            characterUpdateModel.Inventory.Items.Remove(item);

            _characterService.UpdateCharacter(characterUpdateModel);
        }

        public bool CanBuy(int cost)
        {
            if (!CheckIsInventoryFull() && _characterService.GetCharacter().Money >= cost)
            {
                return true;
            }

            return false;
        }

        public void BuyItem(Item item)
        {
            characterUpdateModel = _characterService.GetCharacter();

            characterUpdateModel.Money -= item.Cost;

            _characterService.UpdateCharacter(characterUpdateModel);

            AddItemToInventory(item);
        }
    }
}