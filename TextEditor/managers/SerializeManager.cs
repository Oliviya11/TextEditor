using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TextEditor.utils;

/*
 * Code for serializtion was taken from:
 * https://stackoverflow.com/questions/6115721/how-to-save-restore-serializable-object-to-from-file
 */

namespace TextEditor.managers
{
    public class SerializeManager
    { 
        static SerializeManager _instance = null;

        private SerializeManager()
        {

        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                Logger.Log("Failed to Serialize object", ex);
            }
        }

        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return default(T);
            }

            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                Logger.Log("Failed to DeSerialize object", ex);
            }

            return objectOut;
        }

        public static SerializeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SerializeManager();
                }

                return _instance;
            }
        }
    }
}
