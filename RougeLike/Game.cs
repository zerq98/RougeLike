using RougeLike.Dungeon;
using RougeLike.Menu;
using RougeLike.PlayerFiles;
using System;

namespace RougeLike
{
    public class Game
    {
        private CharacterService _characterService;
        private readonly MenuActionService _actionService;

        public Game(CharacterService characterService, MenuActionService actionService)
        {
            _characterService = characterService;
            _actionService = actionService;
        }

        public void GameMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"What do you want to do {_characterService.GetCharacterName()}");

                foreach (var action in _actionService.GetMenuActionsByMenuName("Game Menu"))
                {
                    Console.WriteLine($"{action.Id}. {action.Name}");
                }

                int chosenOption;

                int.TryParse(Console.ReadKey().KeyChar.ToString(), out chosenOption);

                Console.Clear();

                switch (chosenOption)
                {
                    case 1:
                        DungeonService dungeonService = new DungeonService(_characterService);
                        int selectedOption = 0;
                        bool isDungeonFinished = false;
                        do
                        {
                            Console.Clear();
                            selectedOption = dungeonService.DungeonMenu(_actionService);

                            switch (selectedOption)
                            {
                                case 1:
                                    if (dungeonService.CheckCount())
                                    {
                                        dungeonService.NextFight(_actionService);
                                    }
                                    else
                                    {
                                        isDungeonFinished = true;
                                        _characterService = dungeonService.ExitMenu()
                                    }
                                    break;
                                case 2:
                                    Console.Clear();
                                    int cost = 250 * _characterService.GetHeroLevel();
                                    Console.WriteLine($"Do you want to heal your hero for {cost} gold? (y/n)");
                                    var confirmHeal = Console.ReadLine();
                                    if (confirmHeal == "y" || confirmHeal == "Y")
                                    {
                                        if (_characterService.Heal(cost))
                                        {
                                            Console.WriteLine("Your hero was fully healed!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sorry you don't have enough gold");
                                        }
                                    }
                                    break;
                                case 3:
                                    isDungeonFinished = true;
                                    _characterService = dungeonService.ExitMenu()
                                    break;
                            }
                        } while (!isDungeonFinished);
                        break;

                    case 2:
                        break;

                    case 3:
                        Console.Clear();
                        int i = _characterService.CharacterInfo(_actionService);
                        break;

                    case 4:
                        if (_characterService.SaveCharacter())
                        {
                            Console.Clear();
                            Console.WriteLine("Your character was successfully saved");
                            Console.WriteLine("Press enter to continue...");
                            Console.Read();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Something went wrong try again");
                            Console.WriteLine("Press enter to continue...");
                            Console.Read();
                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to quit?(Y/N)");
                        var confirm = Console.ReadLine();
                        if (confirm == "y" || confirm == "Y")
                        {
                            Console.WriteLine("OK so BYE!!!");
                            System.Environment.Exit(1);
                        }
                        break;

                    default:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Option you selected doesn't exist");
                            Console.WriteLine("Click enter to continue");
                        } while (Console.ReadKey().Key != ConsoleKey.Enter);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}