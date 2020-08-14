using RougeLike.StuffFiles;
using System.Collections.Generic;

namespace RougeLike.PlayerFiles
{
    public class Inventory
    {
        public int Capacity { get; set; }

        public List<Item> Items { get; set; }
    }
}