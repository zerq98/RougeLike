using RougeLike.Helpers;
using RougeLike.PlayerFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RougeLike.StuffFiles
{
    public class ItemService
    {
        private List<Item> items;

        public ItemService()
        {
            Initialize();
        }

        public Item GetRandomItem(int level, Class classType)
        {
            Random random = new Random();
            bool isGoodItem = false;
            int id = 0;
            while (!isGoodItem)
            {
                id = random.Next(0, items.Count);
                if (items[id].MinLevel <= level && items[id].CompatibiltyClass == classType)
                {
                    isGoodItem = true;
                }
            }

            return items[id];
        }

        private void Initialize()
        {
            if (File.Exists(HelperVariables.itemsBase))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));

                StreamReader reader = new StreamReader(HelperVariables.itemsBase);

                items = (List<Item>)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                items = ItemsInitializer.Initialize();
                Save();
            }
        }

        private void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));

            FileStream writer = File.Create(HelperVariables.itemsBase);
            serializer.Serialize(writer, items);
            writer.Close();
        }

        public List<Item> GetShopStuff(int level, Class classType)
        {
            List<Item> selected = new List<Item>();

            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                bool isGoodItem = false;
                while (!isGoodItem)
                {
                    Item selectedItem = items[random.Next(0, items.Count)];

                    if (selectedItem.MinLevel <= level && selectedItem.CompatibiltyClass == classType)
                    {
                        isGoodItem = true;
                        selected.Add(selectedItem);
                    }
                }
            }

            return selected;
        }
    }
}