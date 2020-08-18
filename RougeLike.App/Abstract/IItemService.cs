using RougeLike.Domain.Entity;
using System.Collections.Generic;

namespace RougeLike.App.Abstract
{
    public interface IItemService
    {
        Item GetItem(int id);

        List<Item> GetAll();

        void SetList(List<Item> initializedList);

        int GetCount();
    }
}