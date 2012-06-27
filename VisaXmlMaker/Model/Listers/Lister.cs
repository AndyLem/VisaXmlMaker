using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model.Listers
{
    public class Lister
    {
        public List<string> _data;

        public event EventHandler ListChanged;

        public Lister()
        {
            _data = new List<string>();
        }

        public void AddLine(string line)
        {
            if (_data.Contains(line)) return;
            _data.Add(line);
            if (ListChanged != null)
                ListChanged(this, EventArgs.Empty);
        }

        public IEnumerable<string> Enum
        {
            get
            {
                return _data.AsEnumerable();
            }
        }

        public void Remove(string line)
        {
            if (_data.Contains(line))
            {
                _data.Remove(line);
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
