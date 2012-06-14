using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// visa application data
    /// </summary>
    public class Molba
    {
        [XmlElement(ElementName = "molba_row")]
        public MolbaRow molbaRow;
    }

    public struct MolbaRow
    {
        /// <summary>
        /// Intended date of arrival
        /// yyyy-mm-dd
        /// </summary>
        public string dat_vli;

        /// <summary>
        /// Intended date of departure
        /// yyyy-mm-dd
        /// </summary>
        public string dat_izl;

        /// <summary>
        /// Type of visa
        /// A = Airport transit
        /// B = Transit
        /// C = Short stay
        /// D = Long stay
        /// </summary>
        public string vidvis;

        /// <summary>
        /// Number of entries
        /// 1 = single entry
        /// 2 = double entries
        /// M = multiple entries
        /// </summary>
        public string brvl;

        /// <summary>
        /// Period of validity for double and multiple entry visas
        /// D = up to 3 months (valid for double and multiple entry A, B, C visas)
        /// E = up to 6 months (valid for double entry B visas and multiple entry B , C and D visas)
        /// F = up to 1 year (valid for multiple entry B, C and D visas)
        /// G = up to 2 years (valid for multiple entry C visas only)
        /// H = up to 3 years (valid for multiple entry C visas only)
        /// I = up to 4 years (valid for multiple entry C visas only)
        /// J = up to 5 years (valid for multiple entry C visas only)
        /// </summary>
        public string valvis;

        /// <summary>
        /// Requested processing speed of visa application (ordinary or fast) 
        /// Fast processing requires double fee.
        /// Char(1) code
        /// O = ordinary
        /// B = fast processing
        /// </summary>
        public string vidus;

        /// <summary>
        /// Duration of stay (number of days visa is requested for)
        /// For Airport transit visas = 0 days
        /// For transit visas =  1 day
        /// For short entry visas =  1 to 90 days
        /// For long stay visas =  180 or 360 days
        /// </summary>
        public string brdni;

        /// <summary>
        /// Purpose of travel
        /// Three letter code. See Code table 6
        /// </summary>
        public string cel;

        /// <summary>
        /// Other purpose of travel (Mandatory if not listed in Code table 6).
        /// Varchar(100) Cyrillic letters, commas, dots  and spaces.
        /// Currently is used free description in BULGARIAN language 
        /// </summary>
        public string celdruga;

        /// <summary>
        /// Date and time of lodging of the application in Visa application centre
        /// yyyy-mm-ddThh:mm:ss.ccccc
        /// </summary>
        public string mol_dat_vav;

        /// <summary>
        /// Information if Visa application should be processed without fee 
        /// (diplomats, cultural events etc.) [Yes/No]
        /// Char(1)  Y = yes N = No
        /// </summary>
        public string gratis;

        /// <summary>
        /// Information if in case of transit the applicant has an entry permit 
        /// for the final country of destination [Yes/No]
        ///  Char(1)  Y = yes N = No Mandatory for Airport transit (A) and Transit (B) visas
        /// </summary>
        public string imavisa;

        /// <summary>
        /// Amount of collected application fee
        /// Decimal number  12.2
        /// </summary>
        public string cenamol;

        /// <summary>
        /// Currency in which the fee was collected
        /// Char(3) Three letter currency code. Capital latin letters.
        /// </summary>
        public string cenacurr;

        /// <summary>
        /// Main destination - Country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string maindest;

        /// <summary>
        /// Main destination - Place
        /// Varchar(100) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if place is situated in country which uses 
        /// Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia, 
        /// Serbia, Macedonia etc.).
        /// </summary>
        public string maindestnm;

        /// <summary>
        /// Border of first entry - Country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        public string gkpp_darj;

        /// <summary>
        /// Border of first entry – Border check point name
        /// Varchar(100) Cyrillic letters, dots  and spaces.
        /// Currently is used free description in BULGARIAN language
        /// </summary>
        public string gkpp_text;

        /// <summary>
        /// Transit route (for transit visas only)
        /// Varchar(150) Cyrillic letters, commas, dots  and spaces.
        /// Currently is used free description in BULGARIAN language Mandatory for Transit (B) visas
        /// </summary>
        public string marsrut;

        /// <summary>
        /// Any additional information and comments about visa application and  applicant
        /// Varchar(500) Cyrillic letters, commas, dots  and spaces.
        /// Currently is used free description in BULGARIAN language
        /// </summary>
        public string Text_ini;
    }
}
