using RougeLike.Domain.Common;
using RougeLike.Domain.Entity;
using System.Collections.Generic;

namespace RougeLike.App.Common
{
    public static class ItemsInitializer
    {
        public const string itemsBase = "items.xml";

        public static List<Item> Initialize()
        {
            List<Item> items = new List<Item>();

            //Potions
            items.Add(new Item { Id = 1, Name = "Small Health Potion", HeroStatToChange = "Health", Value = 50, IsUsable = true, CompatibiltyClass = Class.none, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 2, Name = "Medium Health Potion", HeroStatToChange = "Health", Value = 100, IsUsable = true, CompatibiltyClass = Class.none, MinLevel = 1, Cost = 300 });
            items.Add(new Item { Id = 3, Name = "Big Health Potion", HeroStatToChange = "Health", Value = 150, IsUsable = true, CompatibiltyClass = Class.none, MinLevel = 1, Cost = 500 });
            //Boots
            items.Add(new Item { Id = 4, Name = "Leather Shoes", HeroStatToChange = "Attack Speed", Value = 6, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 5, Name = "Wooden Shoes", HeroStatToChange = "Attack Speed", Value = 15, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 2, Cost = 100 });
            items.Add(new Item { Id = 6, Name = "Leather Boots", HeroStatToChange = "Attack Speed", Value = 23, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 3, Cost = 100 });
            items.Add(new Item { Id = 7, Name = "Bronze Boots", HeroStatToChange = "Attack Speed", Value = 30, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 4, Cost = 100 });
            items.Add(new Item { Id = 8, Name = "Jade Boots", HeroStatToChange = "Attack Speed", Value = 38, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 5, Cost = 100 });
            //Bracelets
            items.Add(new Item { Id = 9, Name = "Wooden Bracelet", HeroStatToChange = "Health", Value = 90, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 1, Cost = 300 });
            items.Add(new Item { Id = 10, Name = "Copper Bracelet", HeroStatToChange = "Health", Value = 125, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 11, Name = "Silver Bracelet", HeroStatToChange = "Health", Value = 250, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 3, Cost = 800 });
            items.Add(new Item { Id = 12, Name = "Gold Bracelet", HeroStatToChange = "Health", Value = 500, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 4, Cost = 1000 });
            items.Add(new Item { Id = 13, Name = "Jade Bracelet", HeroStatToChange = "Health", Value = 1000, IsUsable = false, CompatibiltyClass = Class.none, MinLevel = 5, Cost = 1500 });
            //Warrior weapons
            items.Add(new Item { Id = 14, Name = "Short Sword", HeroStatToChange = "Attack Damage", Value = 10, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 15, Name = "Sword", HeroStatToChange = "Attack Damage", Value = 15, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 16, Name = "Long sword", HeroStatToChange = "Attack Damage", Value = 20, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 17, Name = "Crescent Sword", HeroStatToChange = "Attack Damage", Value = 30, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 18, Name = "Broad Sword", HeroStatToChange = "Attack Damage", Value = 40, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 5, Cost = 2500 });
            //Warrior armors
            items.Add(new Item { Id = 19, Name = "Plate Armor", HeroStatToChange = "Armor", Value = 10, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 20, Name = "Iron Plate Armor", HeroStatToChange = "Armor", Value = 15, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 21, Name = "Tiger Armor", HeroStatToChange = "Armor", Value = 25, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 22, Name = "Dragon Armor", HeroStatToChange = "Armor", Value = 35, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 23, Name = "Black Steel Armor", HeroStatToChange = "Armor", Value = 50, IsUsable = false, CompatibiltyClass = Class.warrior, MinLevel = 5, Cost = 2500 });
            //Mage weapons
            items.Add(new Item { Id = 24, Name = "Copper Staff", HeroStatToChange = "Attack Damage", Value = 15, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 25, Name = "Silver Staff", HeroStatToChange = "Attack Damage", Value = 26, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 26, Name = "Golden Staff", HeroStatToChange = "Attack Damage", Value = 35, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 27, Name = "Antique Staff", HeroStatToChange = "Attack Damage", Value = 45, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 28, Name = "Jade Staff", HeroStatToChange = "Attack Damage", Value = 58, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 5, Cost = 2500 });
            //Mage armors
            items.Add(new Item { Id = 29, Name = "Crimson Robe", HeroStatToChange = "Armor", Value = 5, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 30, Name = "Turquoise Robe", HeroStatToChange = "Armor", Value = 14, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 31, Name = "Pink Robe", HeroStatToChange = "Armor", Value = 22, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 32, Name = "Heavenly Robe", HeroStatToChange = "Armor", Value = 30, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 33, Name = "Sun Robe", HeroStatToChange = "Armor", Value = 38, IsUsable = false, CompatibiltyClass = Class.mage, MinLevel = 5, Cost = 2500 });
            //Thief weapons
            items.Add(new Item { Id = 34, Name = "Dagger", HeroStatToChange = "Attack Damage", Value = 11, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 35, Name = "Cobra Dagger", HeroStatToChange = "Attack Damage", Value = 25, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 36, Name = "Ninja Blades", HeroStatToChange = "Attack Damage", Value = 36, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 37, Name = "Lucky Knife", HeroStatToChange = "Attack Damage", Value = 40, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 38, Name = "Devil Fist Dagger", HeroStatToChange = "Attack Damage", Value = 60, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 5, Cost = 2500 });
            //Thief armors
            items.Add(new Item { Id = 39, Name = "Azure Suit", HeroStatToChange = "Armor", Value = 12, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 40, Name = "Ivory Suit", HeroStatToChange = "Armor", Value = 21, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 41, Name = "Crimson Suit", HeroStatToChange = "Armor", Value = 29, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 42, Name = "Ninja Suit", HeroStatToChange = "Armor", Value = 55, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 43, Name = "Young Dragon Suit", HeroStatToChange = "Armor", Value = 64, IsUsable = false, CompatibiltyClass = Class.thief, MinLevel = 5, Cost = 2500 });
            //berserker weapons
            items.Add(new Item { Id = 44, Name = "Short Sword", HeroStatToChange = "Attack Damage", Value = 24, IsUsable = false, CompatibiltyClass = Class.berserker, MinLevel = 1, Cost = 100 });
            items.Add(new Item { Id = 45, Name = "Sword", HeroStatToChange = "Attack Damage", Value = 36, IsUsable = false, CompatibiltyClass = Class.berserker, MinLevel = 2, Cost = 500 });
            items.Add(new Item { Id = 46, Name = "Long sword", HeroStatToChange = "Attack Damage", Value = 48, IsUsable = false, CompatibiltyClass = Class.berserker, MinLevel = 3, Cost = 1000 });
            items.Add(new Item { Id = 47, Name = "Crescent Sword", HeroStatToChange = "Attack Damage", Value = 60, IsUsable = false, CompatibiltyClass = Class.berserker, MinLevel = 4, Cost = 2000 });
            items.Add(new Item { Id = 48, Name = "Broad Sword", HeroStatToChange = "Attack Damage", Value = 72, IsUsable = false, CompatibiltyClass = Class.berserker, MinLevel = 5, Cost = 2500 });

            return items;
        }
    }
}