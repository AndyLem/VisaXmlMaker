using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// spouse’s data
    /// </summary>
    public class Sapruga
    {
        [XmlElement(ElementName="d_sapruga_row")]
        public SaprugaRow saprugaRow;

        public Sapruga()
        {
            saprugaRow = new SaprugaRow()
            {
                sp_famil = "Famil",
                sp_imena = "names",
                sp_famil2 = "old famil",
                sp_datraj = "2000-10-01",
                sp_mrjdarj = "ctr",
                sp_mrjnm = "cit"
            };
        }
    }

    public struct SaprugaRow
    {
        public string sp_famil;
        public string sp_imena;
        public string sp_famil2;
        public string sp_datraj;
        public string sp_mrjdarj;
        public string sp_mrjnm;
    }
}
