﻿using RougeLike.PlayerFiles;
using System.IO;

namespace RougeLike.Helpers
{
    public static class SaveManager
    {
        public static void Save(Character character)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Character));

            FileStream file = System.IO.File.Create(HelperVariables.saveFile);
            writer.Serialize(file, character);
            file.Close();
        }

        public static Character Load()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Character));

            StreamReader streamReader = new StreamReader(HelperVariables.saveFile);
            var character = (Character)reader.Deserialize(streamReader);
            streamReader.Close();

            return character;
        }
    }
}