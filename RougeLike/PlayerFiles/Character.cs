namespace RougeLike.PlayerFiles
{
    public class Character
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public int NeededExperience { get; set; }

        public Class Class { get; set; }

        public int Money { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int AttackDamage { get; set; }

        public int Armor { get; set; }

        public int AttackSpeed { get; set; }

        public Inventory Inventory { get; set; }
    }
}