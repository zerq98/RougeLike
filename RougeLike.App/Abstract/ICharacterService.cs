using RougeLike.Domain.Common;
using RougeLike.Domain.Entity;
using System.Collections.Generic;

namespace RougeLike.App.Abstract
{
    public interface ICharacterService
    {
        bool CreateCharacter(Class selectedClass,string name);

        void CreateCharacter(Character loadCharacter);

        Character GetCharacter();

        void UpdateCharacter(Character updateModel);

        List<Item> GetItemList();

        bool CheckCapacity();
    }
}