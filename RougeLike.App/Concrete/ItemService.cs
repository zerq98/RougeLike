using RougeLike.App.Abstract;
using RougeLike.Domain.Entity;
using System.Collections.Generic;

namespace RougeLike.App.Concrete
{
    public class ItemService : IItemService
    {
        private List<Item> items;

        public Item GetItem(int id)
        {
            return items[id];
        }

        public List<Item> GetAll()
        {
            return items;
        }

        public void SetList(List<Item> initializedList)
        {
            items = initializedList;
        }

        public int GetCount()
        {
            return items.Count;
        }
    }
}