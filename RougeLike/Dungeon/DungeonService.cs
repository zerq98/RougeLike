using RougeLike.Menu;
using RougeLike.PlayerFiles;
using System;
using System.Collections.Generic;

namespace RougeLike.Dungeon
{
    public class DungeonService
    {
        private CharacterService _characterService;
        private int heroLevel;
        private int monstersCount;

        public DungeonService(CharacterService characterService)
        {
            _characterService = characterService;
            heroLevel = _characterService.GetHeroLevel();
            monstersCount = heroLevel + 2 * heroLevel;
        }

        public int DungeonMenu(MenuActionService actionService)
        {
            List<MenuAction> dungeonMenu = actionService.GetMenuActionsByMenuName("Dungeon");
            int selectedOption;

            Console.WriteLine("What do you want to do in this dungeon:");
            Console.WriteLine();

            for (int i = 0; i < dungeonMenu.Count; i++)
            {
                Console.WriteLine($"{dungeonMenu[i].Id}. {dungeonMenu[i].Name}");
            }

            var readedKey = Console.ReadKey();
            Int32.TryParse(readedKey.KeyChar.ToString(), out selectedOption);

            return selectedOption;
        }

        public void NextFight(MenuActionService actionService)
        {
            _characterService = Fight.FightMenu(actionService, _characterService);

            if (_characterService == null)
            {
                Console.Clear();
                Console.WriteLine("Sorry you lost :( . Try again!");
                Environment.Exit(1);
            }
        }

        public CharacterService ExitMenu()
        {
            _characterService.Heal();
            return _characterService;
        }

        public bool CheckCount()
        {
            if (monstersCount > 0)
            {
                monstersCount--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}