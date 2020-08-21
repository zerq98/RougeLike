using RougeLike.Domain.Common;

namespace RougeLike.Domain.Entity
{
    public class Item : BaseEntity
    {
        public bool IsUsable { get; set; }

        public string HeroStatToChange { get; set; }

        public int Value { get; set; }

        public int Cost { get; set; }

        public CharacterClass CompatibiltyClass { get; set; }

        public int MinLevel { get; set; }
    }
}