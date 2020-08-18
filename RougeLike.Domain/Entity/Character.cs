using RougeLike.Domain.Common;

namespace RougeLike.Domain.Entity
{
    public class Character : BaseCreatureEntity
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public int NeededExperience { get; set; }

        public Class Class { get; set; }

        public int Money { get; set; }

        public int MaxHealth { get; set; }

        public Inventory Inventory { get; set; }
    }
}