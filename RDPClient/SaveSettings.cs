using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace RDPClient
{
   public class SaveSettings
    {
        public String XMLFileName = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("RDPClient.exe", "") + "settings.xml";
        public string Password = "";
        public string NameUser = "";
        public string NameServer = "";
        public int SizeScreen = 6;
    }
    public class Props
    {
        public SaveSettings Fields;
        //запись настроек в файл
        public Props()
            {
                 Fields = new SaveSettings();
            }
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(SaveSettings));
            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        //чтение настроек из файла
        public void ReadXML()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(SaveSettings));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as SaveSettings;
                reader.Close();
            }
        }
    }
}
