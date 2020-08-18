using RougeLike.App.Abstract;
using RougeLike.Domain.Entity;
using System.Collections.Generic;

namespace RougeLike.App.Concrete
{
    public class MenuActionService : IMenuActionService
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

        public void AddNewAction(MenuAction action)
        {
            menuActions.Add(action);
        }
    }
}