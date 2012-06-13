using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// applicant’s passport data
    /// </summary>
    public class Lcuz
    {
        [XmlElement(ElementName = "d_lcuz_row")]
        public LcuzRow lcuzRow;

        public Lcuz()
        {
            //lcuzRow = new LcuzRow();
        }
    }

    public struct LcuzRow
    {
        public string vid_zp;
        public string nac_bel;
        public string nac_pasp;
        public string pasp_val;
        public string graj;
        public string famil;
        public string imena;
        public string dat_raj;
        public string pol;
        public string dat_izd;
    }
}
