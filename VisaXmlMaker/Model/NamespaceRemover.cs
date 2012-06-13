using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace VisaXmlMaker.Model
{
    public abstract class NamespaceRemover
    {
        // void? and what we need to take into?
        public static void RemoveNamespaces()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            XmlElement rt = doc["d_loadosf"];
            for (int i = rt.Attributes.Count - 1; i >= 0; i--)
                if (rt.Attributes[i].Name != "version")
                    rt.Attributes.RemoveAt(i);

            doc.Save("test.xml");
        }
    }
}
