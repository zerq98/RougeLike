using RougeLike.Domain.Common;

namespace RougeLike.Domain.Entity
{
    public class Enemy : BaseCreatureEntity
    {
        public EnemyRace Race { get; set; }

        public EnemyType Type { get; set; }
    }
}