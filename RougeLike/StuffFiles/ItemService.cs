using RougeLike.Helpers;
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

        public Item GetRandomItem()
        {
            Random random = new Random();

            int id = random.Next(0, items.Count);

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
    }
}