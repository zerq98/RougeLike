using System;

namespace RougeLike.Enemies
{
    public class EnemyService
    {
        private Enemy enemy;
        private Random random;

        public EnemyService()
        {
            enemy = new Enemy();
            random = new Random();
        }

        public void GenerateNewEnemy(int heroLevel)
        {
            EnemyType type = (EnemyType)random.Next(0, 4);
            EnemyRace race = (EnemyRace)random.Next(0, 5);

            switch (type)
            {
                case EnemyType.Archer:
                    enemy = new Enemy()
                    {
                        Type = type,
                        Race = race,
                        Health = (100 * heroLevel),
                        AttackDamage = (15 * heroLevel),
                        Armor = (2 * heroLevel),
                        AttackSpeed = (30 * heroLevel)
                    };
                    break;

                case EnemyType.Berserker:
                    enemy = new Enemy()
                    {
                        Type = type,
                        Race = race,
                        Health = (150 * heroLevel),
                        AttackDamage = (30 * heroLevel),
                        Armor = (10 * heroLevel),
                        AttackSpeed = (60 * heroLevel)
                    };
                    break;

                case EnemyType.Mage:
                    enemy = new Enemy()
                    {
                        Type = type,
                        Race = race,
                        Health = (75 * heroLevel),
                        AttackDamage = (45 * heroLevel),
                        Armor = (2 * heroLevel),
                        AttackSpeed = (30 * heroLevel)
                    };
                    break;

                case EnemyType.Shielder:
                    enemy = new Enemy()
                    {
                        Type = type,
                        Race = race,
                        Health = (300 * heroLevel),
                        AttackDamage = (7 * heroLevel),
                        Armor = (40 * heroLevel),
                        AttackSpeed = (5 * heroLevel)
                    };
                    break;

                case EnemyType.Warrior:
                    enemy = new Enemy()
                    {
                        Type = type,
                        Race = race,
                        Health = (200 * heroLevel),
                        AttackDamage = (15 * heroLevel),
                        Armor = (20 * heroLevel),
                        AttackSpeed = (10 * heroLevel)
                    };
                    break;
            }
        }

        private bool DealDamage(int heroDamage)
        {
            enemy.Health -= heroDamage - enemy.Armor;

            if (enemy.Health > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}