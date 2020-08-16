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
            actionService.AddNewAction(2, "Go to shop(not implemented yet)", "Game Menu");
            actionService.AddNewAction(3, "Check hero info", "Game Menu");
            actionService.AddNewAction(4, "Save", "Game Menu");
            actionService.AddNewAction(5, "Exit", "Game Menu");

            actionService.AddNewAction(1, "Next fight", "Dungeon");
            actionService.AddNewAction(2, "Heal", "Dungeon");
            actionService.AddNewAction(3, "Exit Dungeon", "Dungeon");

            actionService.AddNewAction(1, "Attack", "Fight");
            actionService.AddNewAction(2, "Use item(not implemented yet)", "Fight");
            actionService.AddNewAction(3, "Try to escape", "Fight");

            return actionService;
        }
    }
}