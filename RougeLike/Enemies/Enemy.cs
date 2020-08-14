namespace RougeLike.Enemies
{
    public class Enemy
    {
        public EnemyRace Race { get; set; }

        public EnemyType Type { get; set; }

        public int Health { get; set; }

        public int AttackDamage { get; set; }

        public int Armor { get; set; }

        public int AttackSpeed { get; set; }
    }
}