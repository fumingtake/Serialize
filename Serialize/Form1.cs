using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Serialize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
#if false
            clsPerson p = new clsPerson();
            p.FirstName = "Jeff";
            p.MI = "A";
            p.LastName = "Price";
            //p.Values = new Dictionary<double, double> { { 1.1, 2.2 }, { 3.3, 4.4 } };
            System.Xml.Serialization.XmlSerializer x
                = new System.Xml.Serialization.XmlSerializer(p.GetType());
            StreamWriter writer 
                = new StreamWriter(@"C:\Users\fumin\source\repos\CSharp\Serialize\normal.xml");
            x.Serialize(writer, p);

            RecordInfo record = new RecordInfo();

            record.Add("key1", new FieldInfo("key1", "キー１"));
            record.Add("key2", new FieldInfo("key2", "キー２"));

            var selializer = new XmlSerializer(typeof(RecordInfo));
            using (FileStream fs = new FileStream(GetXMLFilePath(), FileMode.Create))
            {
                selializer.Serialize(fs, record);

            }

            XmlSerializer serializer = new XmlSerializer(typeof(RecordInfo));
            RecordInfo record2 = new RecordInfo();
            using (FileStream fs = new FileStream(GetXMLFilePath(), FileMode.Open))
            {
                record2 = serializer.Deserialize(fs) as RecordInfo;
                // XML からオブジェクトが復元されている
            }
            Class3 oClass3 = new Class3();

            oClass3.Age = 1;
            oClass3.Record = new RecordInfo();
            oClass3.Record.Add("key1", new FieldInfo("key1", "キー１"));
            oClass3.Record.Add("key2", new FieldInfo("key2", "キー２"));

            var selializer = new XmlSerializer(typeof(Class3));
            using (FileStream fs = new FileStream(GetXMLFilePath2(), FileMode.Create))
            {
                selializer.Serialize(fs, oClass3);

            }
#endif
            Class4 o = new Class4();

            o.Age = 1;
            o.Record = new SerializableDictionary<string, string>();
            o.Record.Add("key1", "キー１");
            o.Record.Add("key2", "キー２");
            o.Record2 = new SerializableDictionary<EnumA, double>();
            o.Record2.Add(EnumA.a, 1.1);
            o.Record2.Add(EnumA.b, 1.2);

            var selializer = new XmlSerializer(typeof(Class4));
            using (FileStream fs = new FileStream(GetXMLFilePath3(), FileMode.Create))
            {
                selializer.Serialize(fs, o);

            }
        }
        private string GetXMLFilePath()
        {
            return @"C:\Users\fumin\source\repos\CSharp\Serialize\Dic.xml";
        }
        private string GetXMLFilePath2()
        {
            return @"C:\Users\fumin\source\repos\CSharp\Serialize\Dic2.xml";
        }
        private string GetXMLFilePath3()
        {
            return @"C:\Users\fumin\source\repos\CSharp\Serialize\Dic3.xml";
        }
    }
}
