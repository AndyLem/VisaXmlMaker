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

    }

    public struct LcuzRow
    {
        /// <summary>
        /// Type of passport
        /// Char(1)  one letter code.  See Code Table 1
        /// </summary>
        public string vid_zp;

        /// <summary>
        /// Issuing country
        /// Char(2) ISO 3166 two letter Country code.  See Code Table 2
        /// </summary>
        public string nac_bel;

        /// <summary>
        /// Passport Number as printed in MRZ
        /// Varchar(30) alphanumeric A-Z  0-9, no spaces allowed
        /// </summary>
        public string nac_pasp;

        /// <summary>
        /// Passport date of expiry
        /// yyyy-mm-dd
        /// </summary>
        public string pasp_val;

        /// <summary>
        /// Citizenship of the applicant
        /// Char(2) ISO 3166 two letter code. See Code Table 3
        /// </summary>
        public string graj;

        /// <summary>
        /// Surname/s (family name/s) as in the passport
        /// Varchar(100) Latin capital letters only (A-Z) and spaces between surnames
        /// </summary>
        public string famil;

        /// <summary>
        /// First Names as in the passport
        /// Varchar(100) Latin capital letters only (A-Z) and spaces between names
        /// </summary>
        public string imena;

        /// <summary>
        /// Date of birth
        /// Char(10)  yyyy/mm/dd IF day or month of the date of birth are unknown, substitute with 00
        /// </summary>
        public string dat_raj;

        /// <summary>
        /// Sex
        /// Char(1)  M = male F = female
        /// </summary>
        public string pol;

        /// <summary>
        /// Date of issuance of the passport
        /// yyyy-mm-dd
        /// </summary>
        public string dat_izd;
    }
}
