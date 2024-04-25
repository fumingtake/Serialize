using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace Serialize
{
    public class SerializableDictionary<Tkey, TValue> : Dictionary<Tkey, TValue>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(KeyValue));

            reader.Read();
            if (reader.IsEmptyElement)
                return;

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                KeyValue kv = serializer.Deserialize(reader) as KeyValue;
                if (kv != null)
                    Add(kv.Key, kv.Value);
            }
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(KeyValue));
            foreach (var key in Keys)
            {
                serializer.Serialize(writer, new KeyValue(key, this[key]));
            }
        }

        public class KeyValue
        {
            public KeyValue(Tkey key, TValue value)
            {
                Key = key;
                Value = value;
            }
            public KeyValue() { }

            public Tkey Key { get; set; }
            public TValue Value { get; set; }
        }
    }
    public class RecordInfo : SerializableDictionary<string, MyFieldInfo>
    {
        public RecordInfo() { }
    }

    public class MyFieldInfo
    {
        public MyFieldInfo(string FieldName, string JapaneseFieldName)
        {
            this.FieldName = FieldName;
            this.JapaneseFieldName = JapaneseFieldName;
        }

        public MyFieldInfo() { }

        public string FieldName;
        public string JapaneseFieldName;
    }
}
