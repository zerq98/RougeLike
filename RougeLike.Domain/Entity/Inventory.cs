using System.Collections.Generic;

namespace RougeLike.Domain.Entity
{
    public class Inventory
    {
        public int Capacity { get; set; }

        public List<Item> Items { get; set; }
    }
}