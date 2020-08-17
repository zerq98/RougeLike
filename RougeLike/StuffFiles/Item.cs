using RougeLike.PlayerFiles;

namespace RougeLike.StuffFiles
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsUsable { get; set; }

        public string HeroStatToChange { get; set; }

        public int Value { get; set; }

        public int Cost { get; set; }

        public Class CompatibiltyClass { get; set; }

        public int MinLevel { get; set; }
    }
}