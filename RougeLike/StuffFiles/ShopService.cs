using RougeLike.PlayerFiles;

namespace RougeLike.StuffFiles
{
    public class ShopService
    {
        private readonly ItemService _itemService;
        private readonly CharacterService _characterService;

        public ShopService(ItemService itemService, CharacterService characterService)
        {
            _itemService = itemService;
            _characterService = characterService;
        }

        public void ShowMenu()
        {
            bool exit = false;

            do
            {
            } while (!exit);
        }
    }
}