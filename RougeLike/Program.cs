using RougeLike.Menu;

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