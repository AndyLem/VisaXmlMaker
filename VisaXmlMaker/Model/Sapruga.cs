using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// spouse’s data
    /// </summary>
    public class Sapruga
    {
        [XmlElement(ElementName="d_sapruga_row")]
        public SaprugaRow saprugaRow;
    }

    public struct SaprugaRow
    {
        /// <summary>
        /// Поле для добавления чекбокса на форму через Controller
        /// </summary>
        [XmlIgnore()]
        [Position(GroupName = "Супруг(а)", Desc = "Холост/Не замужем", DesiredIndex=-1, ControlType=typeof(CheckBox))]
        public bool isSingle;

        /// <summary>
        /// Spouse’s Surname/s (family name/s)
        /// Varchar(100) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet could be used if spouse comes from country which uses 
        /// Cyrillic as well (Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia, 
        /// Serbia, Macedonia etc.). If spouse is Bulgarian, Cyrillic is mandatory.
        /// </summary>
        [Position(GroupName = "Супруг(а)", Desc = "Фамилия")]
        public string sp_famil;

        /// <summary>
        /// Spouse’s First Names (Given names)
        /// Varchar(100) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet could be used if spouse comes from country which uses 
        /// Cyrillic as well (Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia, 
        /// Serbia, Macedonia etc.). If spouse is Bulgarian, Cyrillic is mandatory.
        /// </summary>
        [Position(GroupName = "Супруг(а)", Desc = "Имена", PutToRight=true)]
        public string sp_imena;

        /// <summary>
        /// Spouse’s Family name at birth
        /// Varchar(100) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet could be used if spouse comes from country which uses 
        /// Cyrillic as well (Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia, 
        /// Serbia, Macedonia etc.). If spouse is Bulgarian, Cyrillic is mandatory.
        /// </summary>
        [Position(GroupName = "Супруг(а)", Desc = "Фамилия при рождении")]
        public string sp_famil2;

        /// <summary>
        /// Spouse’s date of birth
        /// Char(10) dd/mm/yyyy. If day or month are unknown, please substitute with 00
        /// </summary>
        [Position(GroupName = "Супруг(а)", Desc = "Дата рождения", ControlType = typeof(DateTimePicker))]
        public string sp_datraj;

        /// <summary>
        /// Spouse’s Country of birth
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        [Position(GroupName = "Супруг(а)", Desc = "Страна рождения", ControlType=typeof(ComboBox))]
        public string sp_mrjdarj;

        /// <summary>
        /// Spouse’s place of birth
        /// Varchar(60) Latin OR Cyrillic capital letters only (A-Z or  А-Я) and spaces. 
        /// Cyrillic alphabet should be used if place is situated in country which uses 
        /// Cyrillic as well (Bulgaria, Russia, Ukraine, Byelorussia, Kazakhstan, Mongolia,
        /// Serbia, Macedonia etc.).
        /// </summary>
        [Position(GroupName = "Супруг(а)", Desc = "Город рождения", ControlType = typeof(ComboBox), PutToRight = true)]
        public string sp_mrjnm;
    }
}
