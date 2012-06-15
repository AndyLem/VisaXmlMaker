using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// prepaid services for organized tourists (voucher information)
    /// </summary>
    public class Voit
    {
        [XmlElement(ElementName = "d_voit_row")]
        public VoitRow voitRow;
    }

    public struct VoitRow
    {
        /// <summary>
        /// Number of voucher for prepaid tourist services
        /// Varchar(30) Latin OR Cyrillic capital letters, 
        /// numbers, dashes (-), dots (.), slashes (/) and spaces 
        /// </summary>
        public string vnom;

        /// <summary>
        /// Voucher is valid from
        /// yyyy-mm-dd
        /// </summary>
        public string voit_datot;

        /// <summary>
        /// Voucher is valid to
        /// yyyy-mm-dd
        /// </summary>
        public string voit_datdo;

        /// <summary>
        /// Name of local travel company issued voucher
        /// Varchar(60) Latin OR Cyrillic capital letters,
        /// numbers, dashes (-) and dots (.)
        /// </summary>
        public string vime;

        /// <summary>
        /// Name  of hosting travel company in Bulgaria
        /// Varchar(60) Cyrillic capital letters, numbers, 
        /// dashes (-), dots (.)
        /// </summary>
        public string bgime;

        /// <summary>
        /// Name and place of the hotel in Bulgaria
        /// Varchar(60) Cyrillic capital letters, numbers,
        /// dashes (-), commas (,), dots (.) and spaces.
        /// </summary>
        public string bgadres;

        /// <summary>
        /// Telephone number of hosting travel company or hotel in Bulgaria
        /// Varchar(20) up to 20 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        public string tel;
    }
}
