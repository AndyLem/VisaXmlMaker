using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisaXmlMaker.Model.Listers
{
    public class ListerData
    {
        public string Item;
        public string Description;

        public override string ToString()
        {
            return Item + " - " + Description;
        }
    }
}
