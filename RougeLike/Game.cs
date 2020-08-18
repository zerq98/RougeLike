using RougeLike.App.Common;
using RougeLike.App.Concrete;
using RougeLike.App.Managers;
using System;

namespace RougeLike
{
    public class Game
    {
        private CharacterManager _characterManager;
        private readonly MenuActionService _actionService;
        private ItemManager _itemManager;

        public Game(CharacterManager characterManager, MenuActionService actionService)
        {
            _characterManager = characterManager;
            _actionService = actionService;
            _itemManager = new ItemManager();
        }

        public void GameMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"What do you want to do {_characterManager.GetCharacterName()}");

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
                        DungeonManager dungeonService = new DungeonManager(_characterManager, _itemManager);
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
                                        _characterManager = dungeonService.ExitMenu();
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    int cost = 250 * _characterManager.GetHeroLevel();
                                    Console.WriteLine($"Do you want to heal your hero for {cost} gold? (y/n)");
                                    var confirmHeal = Console.ReadLine();
                                    if (confirmHeal == "y" || confirmHeal == "Y")
                                    {
                                        if (_characterManager.Heal(cost))
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
                                    _characterManager = dungeonService.ExitMenu();
                                    break;
                            }
                        } while (!isDungeonFinished);

                        _characterManager.SaveCharacter();
                        break;

                    case 2:
                        ShopManager shop = new ShopManager(_itemManager, _characterManager);
                        shop.ShowMenu();
                        break;

                    case 3:
                        Console.Clear();
                        int i = _characterManager.CharacterInfo();
                        break;

                    case 4:
                        Messages.SaveResult(_characterManager.SaveCharacter());
                        break;

                    case 5:
                        Messages.Exit();
                        break;

                    default:
                        Messages.WrongOption();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}