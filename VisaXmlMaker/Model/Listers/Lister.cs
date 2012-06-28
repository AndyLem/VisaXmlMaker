using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model.Listers
{
    public class Lister
    {
        public List<ListerData> _data;

        public event EventHandler ListChanged;

        public Lister()
        {
            _data = new List<ListerData>();
        }

        public void AddLine(string item, string desc)
        {
            ListerData ld = new ListerData() { Item = item, Description = desc };

            if (_data.Exists((it) => { return it.Item == ld.Item; })) return;
            _data.Add(ld);
            if (ListChanged != null)
                ListChanged(this, EventArgs.Empty);
        }

        public IEnumerable<ListerData> Enum
        {
            get
            {
                return _data.AsEnumerable();
            }
        }

        public void Remove(string item)
        {
            ListerData fndLd = _data.Find((it) => { return it.Item == item; });
            if (fndLd != null) 
            {
                _data.Remove(fndLd);
                if (ListChanged != null)
                    ListChanged(this, EventArgs.Empty);
            }
        }

        public void Clear()
        {
            if (_data.Count > 0)
            {
                _data.Clear();
                if (ListChanged != null)
                    ListChanged(this, EventArgs.Empty);
            }
        }
    }
}
