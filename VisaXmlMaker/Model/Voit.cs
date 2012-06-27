using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

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

    public class VoitRow
    {
        /// <summary>
        /// Number of voucher for prepaid tourist services
        /// Varchar(30) Latin OR Cyrillic capital letters, 
        /// numbers, dashes (-), dots (.), slashes (/) and spaces 
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Номер ваучера", ControlType = typeof(TextBox))]
        public string vnom;

        /// <summary>
        /// Voucher is valid from
        /// yyyy-mm-dd
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Ваучер действителен с", 
            ControlType = typeof(DateTimePicker), ConverterType = ConverterType.ShortYmMmD)]
        public string voit_datot;

        /// <summary>
        /// Voucher is valid to
        /// yyyy-mm-dd
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Ваучер действителен по",
            ControlType = typeof(DateTimePicker), ConverterType = ConverterType.ShortYmMmD)]
        public string voit_datdo;

        /// <summary>
        /// Name of local travel company issued voucher
        /// Varchar(60) Latin OR Cyrillic capital letters,
        /// numbers, dashes (-) and dots (.)
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Компания, выпустившая ваучер", ControlType = typeof(ComboBox))]
        public string vime;

        /// <summary>
        /// Name  of hosting travel company in Bulgaria
        /// Varchar(60) Cyrillic capital letters, numbers, 
        /// dashes (-), dots (.)
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Принимающая компания", ControlType = typeof(ComboBox))]
        public string bgime;

        /// <summary>
        /// Name and place of the hotel in Bulgaria
        /// Varchar(60) Cyrillic capital letters, numbers,
        /// dashes (-), commas (,), dots (.) and spaces.
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Название и адрес отеля", ControlType = typeof(ComboBox))]
        public string bgadres;

        /// <summary>
        /// Telephone number of hosting travel company or hotel in Bulgaria
        /// Varchar(20) up to 20 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        [Position(GroupName = "Организованный туризм", ColSpan = 2, Desc = "Телефон", ControlType = typeof(TextBox))]
        public string tel;
    }
}