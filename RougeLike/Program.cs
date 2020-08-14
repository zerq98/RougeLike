using RougeLike.Helpers;
using RougeLike.Menu;
using RougeLike.PlayerFiles;
using System;
using System.IO;

namespace RougeLike
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            CharacterService characterService = new CharacterService();

            actionService = Initialize(actionService);

            bool isUserInStart = true;

            while (isUserInStart)
            {
                Console.WriteLine("Welcome in the GAME Adventurer!");

                foreach (var action in actionService.GetMenuActionsByMenuName("Start"))
                {
                    Console.WriteLine($"{action.Id}. {action.Name}");
                }

                int chosenOption;

                int.TryParse(Console.ReadKey().KeyChar.ToString(), out chosenOption);

                Console.Clear();

                switch (chosenOption)
                {
                    case 1:
                        var selectedClass = characterService.CreateCharacterView(actionService);
                        if (characterService.CreateCharacter(selectedClass))
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
                        if (characterService.LoadCharacter())
                        {
                            isUserInStart = false;
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
                        Console.Clear();
                        Console.WriteLine("OK so BYE!!!");
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Option you selected doesn't exist");
                        break;
                }
            }

            Console.Clear();

            while (true)
            {
                Console.WriteLine($"What do you want to do {characterService.GetCharacterName()}");

                foreach (var action in actionService.GetMenuActionsByMenuName("Game Menu"))
                {
                    Console.WriteLine($"{action.Id}. {action.Name}");
                }

                int chosenOption;

                int.TryParse(Console.ReadKey().KeyChar.ToString(), out chosenOption);

                Console.Clear();

                switch (chosenOption)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
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

        public static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "New Game", "Start");
            actionService.AddNewAction(2, "Load Game", "Start");
            actionService.AddNewAction(3, "Remove Data", "Start");
            actionService.AddNewAction(4, "Exit", "Start");

            actionService.AddNewAction(1, "Warrior", "Select Class");
            actionService.AddNewAction(2, "Mage", "Select Class");
            actionService.AddNewAction(3, "Thief", "Select Class");
            actionService.AddNewAction(4, "Berserker", "Select Class");

            actionService.AddNewAction(1, "Go to dungeon", "Game Menu");
            actionService.AddNewAction(2, "Go to shop", "Game Menu");
            actionService.AddNewAction(3, "Check hero info", "Game Menu");
            actionService.AddNewAction(4, "Save", "Game Menu");
            actionService.AddNewAction(5, "Exit", "Game Menu");

            return actionService;
        }
    }
}