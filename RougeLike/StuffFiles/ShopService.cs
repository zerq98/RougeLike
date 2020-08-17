using RougeLike.Helpers;
using RougeLike.PlayerFiles;
using System;
using System.Collections.Generic;

namespace RougeLike.StuffFiles
{
    public class ShopService
    {
        private readonly ItemService _itemService;
        private readonly CharacterService _characterService;

        public ShopService(ItemService itemService, CharacterService characterService)
        {
            _itemService = itemService;
            _characterService = characterService;
        }

        public CharacterService ShowMenu()
        {
            bool exit = false;
            List<Item> items = _itemService.GetShopStuff(_characterService.GetHeroLevel(), _characterService.GetHeroClass());

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
                Console.WriteLine($"Your gold: {_characterService.GetMoneyCount()}");
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
                            if (_characterService.CanBuy(items[option - 1].Cost))
                            {
                                _characterService.BuyItem(items[option - 1]);
                                items.RemoveAt(option - 1);
                            }
                        }
                        break;

                    case 7:
                        int selectedItem;
                        do
                        {
                            List<Item> heroItems = _characterService.GetItems();
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
                                _characterService.SellItem(selectedItem - 1);
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

            return _characterService;
        }
    }
}