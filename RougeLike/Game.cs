using RougeLike.Dungeon;
using RougeLike.Helpers;
using RougeLike.Menu;
using RougeLike.PlayerFiles;
using RougeLike.StuffFiles;
using System;

namespace RougeLike
{
    public class Game
    {
        private CharacterService _characterService;
        private readonly MenuActionService _actionService;
        private ItemService _itemService;

        public Game(CharacterService characterService, MenuActionService actionService)
        {
            _characterService = characterService;
            _actionService = actionService;
            _itemService = new ItemService();
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
                        DungeonService dungeonService = new DungeonService(_characterService, _itemService);
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
                                        _characterService = dungeonService.ExitMenu();
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
                                    _characterService = dungeonService.ExitMenu();
                                    break;
                            }
                        } while (!isDungeonFinished);

                        _characterService.SaveCharacter();
                        break;

                    case 2:
                        ShopService shop = new ShopService(_itemService, _characterService);
                        shop.ShowMenu();
                        break;

                    case 3:
                        Console.Clear();
                        int i = _characterService.CharacterInfo();
                        break;

                    case 4:
                        Messages.SaveResult(_characterService.SaveCharacter());
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