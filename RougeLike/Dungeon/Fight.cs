using RougeLike.Enemies;
using RougeLike.Helpers;
using RougeLike.Menu;
using RougeLike.PlayerFiles;
using RougeLike.StuffFiles;
using System;
using System.Collections.Generic;

namespace RougeLike.Dungeon
{
    public static class Fight
    {
        public static CharacterService FightMenu(MenuActionService actionService, CharacterService characterService, ItemService itemService)
        {
            bool isMonsterLive = true;
            bool isHeroLive = true;
            bool isEscaped = false;
            EnemyService enemyService = new EnemyService();
            enemyService.GenerateNewEnemy(characterService.GetHeroLevel());

            int[] hiddenHeroStats = characterService.GetHiddenStats();
            int[] hiddenEnemyStats = enemyService.GetHiddenStats();

            do
            {
                Console.Clear();
                Console.WriteLine("Your hero:");
                characterService.ShowHeroInfoInFight();
                Console.WriteLine();
                enemyService.ShowMonsterInfo();

                List<MenuAction> dungeonMenu = actionService.GetMenuActionsByMenuName("Fight");
                int selectedOption;

                Console.WriteLine();

                for (int i = 0; i < dungeonMenu.Count; i++)
                {
                    Console.WriteLine($"{dungeonMenu[i].Id}. {dungeonMenu[i].Name}");
                }

                var readedKey = Console.ReadKey();
                Int32.TryParse(readedKey.KeyChar.ToString(), out selectedOption);

                switch (selectedOption)
                {
                    case 1:
                        if (hiddenHeroStats[1] >= hiddenEnemyStats[1])
                        {
                            isMonsterLive = enemyService.DealDamage(hiddenHeroStats[0]);
                            Console.Read();
                            if (isMonsterLive)
                            {
                                isHeroLive = characterService.GetDamage(hiddenEnemyStats[0]);
                            }
                        }
                        else
                        {
                            isHeroLive = characterService.GetDamage(hiddenEnemyStats[0]);
                            Console.Read();
                            if (isHeroLive)
                            {
                                isMonsterLive = enemyService.DealDamage(hiddenHeroStats[0]);
                            }
                        }

                        break;

                    case 2:
                        int selectedItem;
                        do
                        {
                            List<Item> heroItems = characterService.GetItems();
                            Console.Clear();
                            int counter = 1;
                            Console.WriteLine("Your inventory:");
                            foreach (var item in heroItems)
                            {
                                Console.WriteLine($"{counter}. {item.Name}");
                                counter++;
                            }
                            Console.WriteLine("0. Exit");
                            int.TryParse(Console.ReadKey().KeyChar.ToString(), out selectedItem);

                            Console.Clear();
                            if (selectedItem != 0 && selectedItem - 1 < heroItems.Count)
                            {
                                if (heroItems[selectedItem - 1].IsUsable)
                                {
                                    characterService.UseItem(selectedItem - 1);
                                }
                                else
                                {
                                    Console.WriteLine("This item is not usable");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have chosen wrong number");
                            }

                            Console.Read();
                            Console.Clear();
                        } while (selectedItem != 0);
                        break;

                    case 3:
                        isEscaped = TryToEscape(hiddenHeroStats[1], hiddenEnemyStats[1]);
                        if (!isEscaped)
                        {
                            Console.Clear();
                            Console.WriteLine("Ups your enemy was too quick!");
                            Console.WriteLine("Click enter to continue...");
                            Console.Read();
                            isHeroLive = characterService.GetDamage(hiddenEnemyStats[0]);
                        }
                        break;

                    default:
                        Console.WriteLine("Wrong option number");
                        break;
                }
            } while (isMonsterLive && isHeroLive && !isEscaped);

            if (!isHeroLive)
            {
                return null;
            }

            if (!isEscaped)
            {
                Random money = new Random();
                Random experience = new Random();
                Item item = itemService.GetRandomItem(characterService.GetHeroLevel(), characterService.GetHeroClass());

                int heroLevel = characterService.GetHeroLevel();

                int gainedMoney = money.Next(25 * heroLevel, 150 * heroLevel);
                int gainedExp = experience.Next(10 * heroLevel, 200 * heroLevel);

                Console.Clear();

                if (!characterService.CheckIsInventoryFull())
                {
                    int numberOfItems = characterService.AddItemToInventory(item);
                    Console.WriteLine($"You got item: {item.Name}");
                    Console.WriteLine($"You have {numberOfItems} items in your inventory");
                }

                Messages.AfterFight(gainedExp, gainedMoney);

                characterService.UpdateCharacterAfterFight(gainedMoney, gainedExp);
            }

            return characterService;
        }

        private static bool TryToEscape(int heroSpeed, int monsterSpeed)
        {
            Random escapeCounter = new Random();

            int chance = 0;

            if (heroSpeed > monsterSpeed)
            {
                chance = 75;
            }
            else if (heroSpeed == monsterSpeed)
            {
                chance = 50;
            }
            else
            {
                chance = 25;
            }

            bool isSuccessfulEscape = false;

            if (escapeCounter.Next(0, 100) >= (100 - chance))
            {
                isSuccessfulEscape = true;
            }

            return isSuccessfulEscape;
        }
    }
}