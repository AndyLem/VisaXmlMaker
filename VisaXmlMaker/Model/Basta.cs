using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// Father’s data
    /// </summary>
    public class Basta
    {
        [XmlElement(ElementName = "d_basta_row")]
        public BastaRow bastaRow;
    }

    public struct BastaRow
    {
        /// <summary>
        /// Surname/s (family name/s)
        /// Varchar(100) Latin capital letters only (A-Z) and spaces between  surnames. 
        /// Cyrillic could be used if father is citizen of country which uses Cyrillic as well.
        /// </summary>
        public string dc_famil;

        /// <summary>
        /// First Names (Given names)
        /// Varchar(100) Latin capital letters only (A-Z) and spaces between names. 
        /// Cyrillic could be used if father is citizen of country which uses Cyrillic as well.
        /// </summary>
        public string dc_imena;
    }
}
