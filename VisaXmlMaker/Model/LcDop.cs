using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// applicant’s additional personal data
    /// </summary>
    public class LcDop
    {
        [XmlElement(ElementName="d_lcdop_row")]
        public LcDopRow lcDopRow;
    }

    public struct LcDopRow
    {
        /// <summary>
        /// Country of birth
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string ld_mrjdarj;

        /// <summary>
        /// Place of birth
        /// Varchar(60) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces. 
        /// Cyrillic alphabet should be used if place of birth is situated in country 
        /// which uses Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, Kazakhstan, 
        /// Mongolia, Serbia, Macedonia etc.).
        /// </summary>
        public string ld_mrjnm;

        /// <summary>
        /// Nationality at birth
        /// Char(2) ISO 3166 two letter code. See Code Table 3
        /// </summary>
        public string ld_mrjgraj;

        /// <summary>
        /// Marital status
        /// Char(1) code. See Code table 4.
        /// </summary>
        public string ld_zenen;

        /// <summary>
        /// Home address - Country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string ld_jit_darj;

        /// <summary>
        /// Home address – Place
        /// Varchar(60) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if place is situated in country which uses 
        /// Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia, 
        /// Serbia, Macedonia etc.).
        /// </summary>
        public string ld_jit_nm;

        /// <summary>
        /// Home address – Street, Number, Apartment etc.
        /// Varchar(60) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces, 
        /// slashes (/), dashes (-)  and  dots. Cyrillic alphabet should be used if address 
        /// is in country which uses Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, 
        /// Mongolia, Serbia, Macedonia etc.).
        /// </summary>
        public string ld_jit_ul;

        /// <summary>
        /// Home address – ZIP code
        /// Varchar(10) 
        /// </summary>
        public string ld_jit_pk;

        /// <summary>
        /// Personal telephone number
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        public string ld_tel;

        /// <summary>
        /// Personal  e-mail address
        /// Varchar(250) all allowed symbols in e-mail addresses
        /// </summary>
        public string ld_jit_email;

        /// <summary>
        /// Employer’s (Company) name
        /// For students – Name of school
        /// Varchar(100)  Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if place is situated in country which uses 
        /// Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia,
        /// Serbia, Macedonia etc.).
        /// </summary>
        public string ld_rabota;

        /// <summary>
        /// Occupation code
        /// Char(2) two letter code. See Code Table 5
        /// </summary>
        public string ld_profkod;

        /// <summary>
        /// Other occupation (mandatory if occupation is not listed in code table 5)
        /// Varchar(70) Cyrillic letters  and spaces. Currently is used free description in 
        /// BULGARIAN language
        /// </summary>
        public string ld_profesia;

        /// <summary>
        /// Employer’s /School’s address – Country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string ld_sl_darj;

        /// <summary>
        /// Employer’s  / School’s address – Place
        /// Varchar(60) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces. 
        /// Cyrillic alphabet should be used if place is situated in country which uses 
        /// Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia, 
        /// Serbia, Macedonia etc.).
        /// </summary>
        public string ld_sl_nm;

        /// <summary>
        /// Employer’s / School’s address – Street, Number, Apartment etc.
        /// Varchar(60) Latin OR Cyrillic capital letters only (A-Z or  А-Я), dots (.), 
        /// slashes (/), dashes (-)   and spaces . Cyrillic alphabet should be used if place 
        /// is situated in country which uses Cyrillic as well (Bulgaria, Russia, Ukraine, 
        /// Byelorussia, Kazakhstan, Mongolia, Serbia, Macedonia etc.).
        /// </summary>
        public string ld_sl_ul;

        /// <summary>
        /// Employer’s / School’s address – ZIP code
        /// Varchar(10) 
        /// </summary>
        public string ld_sl_pk;

        /// <summary>
        /// Employer’s / School’s telephone number
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        public string ld_sltel;

        /// <summary>
        /// Employer’s / School’s Fax number
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        public string ld_sl_fax;

        /// <summary>
        /// Employer’s / School’s e-mail address
        /// Varchar(250) all allowed symbols in e-mail addresses
        /// </summary>
        public string ld_sl_email;
    }
}
