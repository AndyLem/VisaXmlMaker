using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    public class ModelIO
    {
        public static bool Save(RootLoadOsf root, string fileName)
        {
            try
            {
                FileStream fs = File.Create(fileName);
                XmlSerializer ser = new XmlSerializer(typeof(RootLoadOsf));
                ser.Serialize(fs, root);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static RootLoadOsf Load(string fileName)
        {
            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                XmlSerializer ser = new XmlSerializer(typeof(RootLoadOsf));
                RootLoadOsf root = (RootLoadOsf)ser.Deserialize(fs);
                fs.Close();
                return root;
            }
            catch
            {
                return null;
            }
            
        }
    }
}
