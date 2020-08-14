using System.Collections.Generic;

namespace RougeLike.Menu
{
    public class MenuActionService
    {
        private List<MenuAction> menuActions;

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> selectedActions = new List<MenuAction>();

            foreach (var action in menuActions)
            {
                if (action.MenuName == menuName)
                {
                    selectedActions.Add(action);
                }
            }

            return selectedActions;
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            menuActions.Add(new MenuAction { Id = id, Name = name, MenuName = menuName });
        }
    }
}