using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Utilities
{
    public static class SerializationUtilities
    {
        public static void SerializeContract(this object value, string fileName = @".\serializedData.xml")
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            using (XmlWriter writer = XmlWriter.Create(fileName, new XmlWriterSettings { Indent = true }))
            {
                new DataContractSerializer(value.GetType()).WriteObject(writer, value);
            }
        }

        public static T DeserializeContract<T>(string fileName = @".\serializedData.xml")
        {
            DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
            XmlReaderSettings settings = new XmlReaderSettings()
            {
                ValidationType = ValidationType.Schema
            };

            try
            {
                using (XmlReader reader = XmlReader.Create(new FileStream(fileName, FileMode.Open), settings))
                    return (T)deserializer.ReadObject(reader);
            }
            catch (FileNotFoundException)
            {
                return default(T);
            }
            
        }
    }
}
