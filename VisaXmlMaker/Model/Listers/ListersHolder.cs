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
            Lister docTypes = this["docTypes"];
            docTypes.AddLine("B");
            docTypes.AddLine("C");
            docTypes.AddLine("D");
            docTypes.AddLine("G");
            docTypes.AddLine("L");
            docTypes.AddLine("M");
            docTypes.AddLine("N");
            docTypes.AddLine("P");
        }

        public void Save(string fileName)
        {
            try
            {
                //var klList = from key in _listers.Keys select new KeyListPair() { Key = key, List = _listers[key] };
                List<KeyListPair> saveList = new List<KeyListPair>();
                foreach (string key in _listers.Keys)
                {
                    saveList.Add(new KeyListPair() { Key = key, List = _listers[key] });
                }
                //saveList.AddRange(klList);

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
                XmlSerializer ser = new XmlSerializer(typeof(Dictionary<string, Lister>));
                Dictionary<string, Lister> _listers = (Dictionary<string, Lister>)ser.Deserialize(fs);
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
