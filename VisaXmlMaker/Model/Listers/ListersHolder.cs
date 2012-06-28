using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace VisaXmlMaker.Model.Listers
{
    public sealed class ListersHolder
    {
        private static ListersHolder _holder;
        public static ListersHolder Holder
        {
            get
            {
                if (_holder == null)
                    _holder = new ListersHolder();
                return _holder;
            }
        }

        private Dictionary<string, Lister> _listers;

        public Lister this[string key]
        {
            get
            {
                if (_listers.ContainsKey(key))
                    return _listers[key];
                Lister newLister = new Lister();
                _listers.Add(key, newLister);
                return newLister;
            }
        }

        private ListersHolder()
        {
            _listers = new Dictionary<string, Lister>();
            //Lister docTypes = this["docTypes"];
            //docTypes.AddLine("B", "Travel document for refugees");
            //docTypes.AddLine("C", "Foreigner's passport");
            //docTypes.AddLine("D", "Diplomatic passport");
            //docTypes.AddLine("G", "Travel document for stateless persons");
            //docTypes.AddLine("L", "Laissez-passer");
            //docTypes.AddLine("M", "Seaman's book");
            //docTypes.AddLine("N", "Emergency (Temporary) passport");
            //docTypes.AddLine("P", "Ordinary passport");
            //docTypes.AddLine("P", "Ordinary passport");
            //docTypes.AddLine("S", "Service passport");
            //docTypes.AddLine("U", "Travel document used by UNMIK (Kosovo)");
            //docTypes.AddLine("X", "Other type of travel document");

        }


        public void Save(string fileName)
        {
            try
            {
                List<KeyListPair> saveList = new List<KeyListPair>();
                foreach (string key in _listers.Keys)
                {
                    saveList.Add(new KeyListPair() { Key = key, List = _listers[key] });
                }
                
                FileStream fs = File.Create(fileName);
                XmlSerializer ser = new XmlSerializer(typeof(List<KeyListPair>));
                ser.Serialize(fs, saveList);
                fs.Close();
            }
            catch
            {
            }
        }

        public void Load(string fileName)
        {
            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                XmlSerializer ser = new XmlSerializer(typeof(List<KeyListPair>));
                List<KeyListPair> klList = (List<KeyListPair>)ser.Deserialize(fs);

                _listers.Clear();
                foreach (KeyListPair klp in klList)
                {
                    _listers.Add(klp.Key, klp.List);
                }
                fs.Close();
            }
            catch
            {
            }
        }

        public class KeyListPair
        {
            public string Key;
            public Lister List;
        }
    }
}
