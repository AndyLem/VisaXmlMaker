using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

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
        [Position(GroupName = "Заголовок", ColSpan = 2, Desc = "Код визового центра", ControlType = typeof(ComboBox))]
        public string mh_kscreated;

        /// <summary>
        /// Visa Application identifier, unique for the visa application centre.
        /// Char(8), numbers 0-9 padded with leading zeroes
        /// </summary>
        [Position(GroupName = "Заголовок", ColSpan = 2, Desc = "Номер заявления")]
        public string mh_regnom;

        /// <summary>
        /// VFS unique reference number or GUID To be considered if this information is necessary 
        /// for BG consulates.
        /// Char(50); Format will be defined  by VFS
        /// </summary>
        [Position(GroupName = "Заголовок", ColSpan = 2, Desc = "Идентификатор заявителя")]
        public string mh_vfsrefno;

        /// <summary>
        /// Names OR first letters of the names of the operator who processed  the application data
        /// Varchar(30) Latin capital letters (A-Z) and spaces
        /// </summary>
        [Position(GroupName = "Заголовок", ColSpan = 2, Desc = "Пользователь", ControlType = typeof(ComboBox))]
        public string mh_usera;

        /// <summary>
        /// Date of creation of XML file
        /// yyyy-mm-dd
        /// </summary>
        [Position(GroupName = "Заголовок", ColSpan = 1, Desc = "Дата формирования", ControlType = typeof(DateTimePicker))]
        public string mh_datvav;
    }
}
