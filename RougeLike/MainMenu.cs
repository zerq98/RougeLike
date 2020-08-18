using RougeLike.App.Common;
using RougeLike.App.Concrete;
using RougeLike.App.Managers;
using System;
using System.IO;

namespace RougeLike
{
    public class MainMenu
    {
        private readonly MenuActionService _actionService;
        private readonly CharacterManager _characterManager;

        public MainMenu(MenuActionService actionService)
        {
            _actionService = actionService;
            _characterManager = new CharacterManager();
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
                        var selectedClass = _characterManager.CreateCharacterView(_actionService);
                        if (_characterManager.CreateCharacter(selectedClass))
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
                        isUserInStart = Messages.LoadResult(_characterManager.LoadCharacter());
                        break;

                    case 3:
                        if (File.Exists(SaveManager.saveFile))
                        {
                            File.Delete(SaveManager.saveFile);
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

            Game gameMenu = new Game(_characterManager, _actionService);
            gameMenu.GameMenu();
        }
    }
}