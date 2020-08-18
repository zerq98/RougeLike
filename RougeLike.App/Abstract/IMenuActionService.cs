using RougeLike.Domain.Entity;
using System.Collections.Generic;

namespace RougeLike.App.Abstract
{
    public interface IMenuActionService
    {
        List<MenuAction> GetMenuActionsByMenuName(string menuName);

        void AddNewAction(MenuAction action);
    }
}