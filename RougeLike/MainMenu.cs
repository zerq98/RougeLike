using RougeLike.Helpers;
using RougeLike.Menu;
using RougeLike.PlayerFiles;
using System;
using System.IO;

namespace RougeLike
{
    public class MainMenu
    {
        private readonly MenuActionService _actionService;
        private readonly CharacterService _characterService;

        public MainMenu(MenuActionService actionService)
        {
            _actionService = actionService;
            _characterService = new CharacterService();
        }

        public void MenuView()
        {
            bool isUserInStart = true;

            while (isUserInStart)
            {
                Console.WriteLine("Welcome in the GAME Adventurer!");

                foreach (var action in _actionService.GetMenuActionsByMenuName("Start"))
                {
                    Console.WriteLine($"{action.Id}. {action.Name}");
                }

                int chosenOption;

                int.TryParse(Console.ReadKey().KeyChar.ToString(), out chosenOption);

                Console.Clear();

                switch (chosenOption)
                {
                    case 1:
                        var selectedClass = _characterService.CreateCharacterView(_actionService);
                        if (_characterService.CreateCharacter(selectedClass))
                        {
                            isUserInStart = false;
                        }
                        else
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Oops something went wrong :( .");
                                Console.WriteLine("Click enter to continue");
                            } while (Console.ReadKey().Key != ConsoleKey.Enter);
                            Console.Clear();
                        }
                        break;

                    case 2:
                        isUserInStart = Messages.LoadResult(_characterService.LoadCharacter());
                        break;

                    case 3:
                        if (File.Exists(HelperVariables.saveFile))
                        {
                            File.Delete(HelperVariables.saveFile);
                        }
                        else
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("You don't have any saves!");
                                Console.WriteLine("Click enter to continue");
                            } while (Console.ReadKey().Key != ConsoleKey.Enter);
                            Console.Clear();
                        }
                        break;

                    case 4:
                        Messages.Exit();
                        break;

                    default:
                        Messages.WrongOption();
                        break;
                }
            }

            Console.Clear();

            Game gameMenu = new Game(_characterService, _actionService);
            gameMenu.GameMenu();
        }
    }
}