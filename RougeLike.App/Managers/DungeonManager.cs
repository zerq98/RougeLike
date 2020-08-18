using RougeLike.App.Common;
using RougeLike.App.Concrete;
using RougeLike.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace RougeLike.App.Managers
{
    public class DungeonManager
    {
        private CharacterManager _characterManager;
        private ItemManager _itemManager;
        private int heroLevel;
        private int monstersCount;

        public DungeonManager(CharacterManager characterManager, ItemManager itemManager)
        {
            _characterManager = characterManager;
            _itemManager = itemManager;
            heroLevel = _characterManager.GetHeroLevel();
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
            _characterManager = Fight.FightMenu(actionService, _characterManager, _itemManager);

            if (_characterManager == null)
            {
                Console.Clear();
                Console.WriteLine("Sorry you lost :( . Try again!");
                File.Delete(SaveManager.saveFile);
                Environment.Exit(1);
            }
        }

        public CharacterManager ExitMenu()
        {
            _characterManager.Heal();
            return _characterManager;
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