using FluentAssertions;
using Moq;
using RougeLike.App.Abstract;
using RougeLike.App.Managers;
using RougeLike.Domain.Common;
using RougeLike.Domain.Entity;
using System.Collections.Generic;
using Xunit;

namespace RougeLike.Tests
{
    public class ItemManagerTests
    {
        private List<Item> items = new List<Item>
        {
            new Item{Id=1,Name="Test", CompatibiltyClass=CharacterClass.none,IsUsable=false,MinLevel=1}
        };

        [Fact]
        public void Should_Return_Item()
        {
            Item item = new Item { Id = 1, Name = "Test", CompatibiltyClass = CharacterClass.none, IsUsable = false, MinLevel = 1 };
            var mock = new Mock<IItemService>();
            mock.Setup(s => s.GetCount()).Returns(1);
            mock.Setup(s => s.GetItem(0)).Returns(item);

            var manager = new ItemManager(mock.Object);

            var selectedItem = manager.GetRandomItem(1, CharacterClass.none);

            selectedItem.Should().NotBeNull();
            selectedItem.Id.Should().BeOfType(typeof(int));
            selectedItem.Id.Should().Be(1);
        }

        [Fact]
        public void Should_Return_List()
        {
            var mock = new Mock<IItemService>();
            mock.Setup(s => s.GetAll()).Returns(items);

            var manager = new ItemManager(mock.Object);

            var selectedList = manager.GetShopStuff(1, CharacterClass.none);

            selectedList.Should().NotBeNull();
            selectedList.Should().BeOfType(typeof(List<Item>));
            selectedList.Count.Should().BeGreaterThan(0);
        }
    }
}