using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// unique visa application number and date and place of the XML file creation
    /// </summary>
    public class MsgHeader
    {
        [XmlElement(ElementName = "d_msgheader_row")]
        public MsgHeaderRow msgHeaderRow;
    }

    public struct MsgHeaderRow
    {
        /// <summary>
        /// Visa application centre location code. Char(3) Latin capital letters code
        /// </summary>
        public string mh_kscreated;

        /// <summary>
        /// Visa Application identifier, unique for the visa application centre.
        /// Char(8), numbers 0-9 padded with leading zeroes
        /// </summary>
        public string mh_regnom;

        /// <summary>
        /// VFS unique reference number or GUID To be considered if this information is necessary 
        /// for BG consulates.
        /// Char(50); Format will be defined  by VFS
        /// </summary>
        public string mh_vfsrefno;

        /// <summary>
        /// Names OR first letters of the names of the operator who processed  the application data
        /// Varchar(30) Latin capital letters (A-Z) and spaces
        /// </summary>
        public string mh_usera;

        /// <summary>
        /// Date of creation of XML file
        /// yyyy-mm-dd
        /// </summary>
        public string mh_datvav;
    }
}
