using RougeLike.Dungeon;
using RougeLike.Menu;
using RougeLike.PlayerFiles;
using System;

namespace RougeLike
{
    public class Game
    {
        private readonly CharacterService _characterService;
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
                        do
                        {
                            Console.Clear();
                            selectedOption = dungeonService.DungeonMenu(_actionService);

                            switch (selectedOption)
                            {
                                case 1:
                                    dungeonService.NextFight(_actionService);
                                    break;

                                case 2:
                                    break;
                            }
                        } while (selectedOption != 3);
                        break;

                    case 2:
                        break;

                    case 3:
                        Console.Clear();
                        int i = _characterService.CharacterInfo(_actionService);
                        break;

                    case 4:
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