using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// EU or EEA family member information
    /// </summary>
    public class Euroda
    {
        [XmlElement(ElementName = "d_euroda_row")]
        public EurodaRow eurodaRow;
    }

    public struct EurodaRow
    {
        /// <summary>
        /// Surname/s (family name/s) of the EU/EAA citizen
        /// Varchar(100) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if EU citizen is Bulgarian.
        /// </summary>
        public string eu_famil;

        /// <summary>
        /// First Names (Given names) of  the EU/EAA citizen
        /// Varchar(100) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if EU citizen is Bulgarian.
        /// </summary>
        public string eu_imena;

        /// <summary>
        /// Date of birth of the EU/EAA citizen
        /// dd/mm/yyyy
        /// </summary>
        public string eu_datraj;

        /// <summary>
        /// Citizenship of the EU/EAA citizen
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string eu_nac_bel;

        /// <summary>
        /// Passport number of the EU/EAA citizen
        /// Varchar(30) Capital Latin letters and numbers
        /// </summary>
        public string eu_nac_pasp;

        /// <summary>
        /// Family relationship of the EU/EEA citizen to the visa applicant
        /// Char(1) code. See Code table 7
        /// </summary>
        public string eu_rodstvo;
    }
}
