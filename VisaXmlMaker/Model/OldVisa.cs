using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// information about other (up to 6) visas issued during the past three years
    /// </summary>
    public class OldVisa
    {
        [XmlElement(ElementName = "d_oldvisa_row")]
        public List<OldVisaRow> oldVisaRows;

        public OldVisa()
        {
            oldVisaRows = new List<OldVisaRow>();
        }
    }

    public struct OldVisaRow
    {
        /// <summary>
        /// Issuing country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string ov_nacbel;

        /// <summary>
        /// Type of visa 
        /// Char(1) code
        /// A = Airport transit visa
        /// B = Transit visa
        /// C = Short stay visa
        /// D = Long stay visa
        /// </summary>
        public string ov_vidvis;

        /// <summary>
        /// Visa number
        /// Varchar(20) Capital Latin letters and numbers
        /// </summary>
        public string ov_visnom;

        /// <summary>
        /// Valid from
        /// yyyy-mm-dd
        /// </summary>
        public string ov_dataot;

        /// <summary>
        /// Valid to
        /// yyyy-mm-dd
        /// </summary>
        public string ov_datado;

        /// <summary>
        /// Number of entries
        /// Char(1)
        /// 1 = Single entry
        /// 2 = Double entries
        /// M = Multiple entries
        /// </summary>
        public string ov_brvl;
    }
}
