using RougeLike.App.Common;
using RougeLike.Domain.Entity;
using System;
using System.Collections.Generic;

namespace RougeLike.App.Managers
{
    public class ShopManager
    {
        private readonly ItemManager _itemManager;
        private readonly CharacterManager _characterManager;

        public ShopManager(ItemManager itemManager, CharacterManager characterManager)
        {
            _itemManager = itemManager;
            _characterManager = characterManager;
        }

        public CharacterManager ShowMenu()
        {
            bool exit = false;
            List<Item> items = _itemManager.GetShopStuff(_characterManager.GetHeroLevel(), _characterManager.GetHeroClass());

            do
            {
                Console.Clear();
                int counter = 1;
                Console.WriteLine("Shop offer:");

                foreach (var item in items)
                {
                    Console.WriteLine($"{counter}. {item.Name} ({item.HeroStatToChange}: +{item.Value}) - {item.Cost} gold");
                    counter++;
                }
                Console.WriteLine();
                Console.WriteLine("7. Sell");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.WriteLine($"Your gold: {_characterManager.GetMoneyCount()}");
                int option;
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out option);
                switch (option)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        if (items.Count >= option - 1)
                        {
                            if (_characterManager.CanBuy(items[option - 1].Cost))
                            {
                                _characterManager.BuyItem(items[option - 1]);
                                items.RemoveAt(option - 1);
                            }
                        }
                        break;

                    case 7:
                        int selectedItem;
                        do
                        {
                            List<Item> heroItems = _characterManager.GetItems();
                            Console.Clear();
                            counter = 1;
                            Console.WriteLine("Your inventory:");
                            foreach (var item in heroItems)
                            {
                                Console.WriteLine($"{counter}. {item.Name} ({item.HeroStatToChange}: -{item.Value}) - {item.Cost} gold");
                                counter++;
                            }
                            Console.WriteLine("0. Exit");
                            int.TryParse(Console.ReadKey().KeyChar.ToString(), out selectedItem);

                            Console.Clear();
                            if (selectedItem != 0 && selectedItem <= heroItems.Count)
                            {
                                _characterManager.SellItem(selectedItem - 1);
                            }

                            Console.Read();
                            Console.Clear();
                        } while (selectedItem != 0);
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Messages.WrongOption();
                        break;
                }
            } while (!exit);

            return _characterManager;
        }
    }
}