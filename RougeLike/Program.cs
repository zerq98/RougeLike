using RougeLike.App.Concrete;
using RougeLike.Domain.Entity;

namespace RougeLike
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);

            MainMenu mainMenu = new MainMenu(actionService);
            mainMenu.MenuView();
        }

        public static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(new MenuAction(1, "New Game", "Start"));
            actionService.AddNewAction(new MenuAction(2, "Load Game", "Start"));
            actionService.AddNewAction(new MenuAction(3, "Remove Data", "Start"));
            actionService.AddNewAction(new MenuAction(4, "Exit", "Start"));

            actionService.AddNewAction(new MenuAction(1, "Warrior", "Select Class"));
            actionService.AddNewAction(new MenuAction(2, "Mage", "Select Class"));
            actionService.AddNewAction(new MenuAction(3, "Thief", "Select Class"));
            actionService.AddNewAction(new MenuAction(4, "Berserker", "Select Class"));

            actionService.AddNewAction(new MenuAction(1, "Go to dungeon", "Game Menu"));
            actionService.AddNewAction(new MenuAction(2, "Go to shop", "Game Menu"));
            actionService.AddNewAction(new MenuAction(3, "Check hero info", "Game Menu"));
            actionService.AddNewAction(new MenuAction(4, "Save", "Game Menu"));
            actionService.AddNewAction(new MenuAction(5, "Exit", "Game Menu"));

            actionService.AddNewAction(new MenuAction(1, "Next fight", "Dungeon"));
            actionService.AddNewAction(new MenuAction(2, "Heal", "Dungeon"));
            actionService.AddNewAction(new MenuAction(3, "Exit Dungeon", "Dungeon"));

            actionService.AddNewAction(new MenuAction(1, "Attack", "Fight"));
            actionService.AddNewAction(new MenuAction(2, "Use item", "Fight"));
            actionService.AddNewAction(new MenuAction(3, "Try to escape", "Fight"));

            return actionService;
        }
    }
}