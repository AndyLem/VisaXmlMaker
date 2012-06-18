using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// Hosting person or organization or hotel
    /// </summary>
    public class Domakin
    {
        [XmlElement(ElementName = "d_domakin_row")]
        public DomakinRow domakinRow;
    }

    public struct DomakinRow
    {
        /// <summary>
        /// Type of the host in EU (person, company/organization or hotel)
        /// Char(1) code 
        /// L = Hosting person 
        /// F = Hosting company or organization 
        /// H = Hotel or temporary address
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "Тип принимающей стороны", ControlType = typeof(ComboBox))]
        public string dm_vid;

        /// <summary>
        /// Registration Number of the Invitation  for visiting Bulgaria 
        /// (necessary for private and business visits)
        /// Varchar(40) Cyrillic capital letters (А-Я), 
        /// numbers, dots (.), dashes (-), slashes (/)  and spaces . 
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "Рег. номер", PutToRight = true, ControlType = typeof(ComboBox))]
        public string nom_pok;

        /// <summary>
        /// Hosting person – citizenship OR Contact person from Hosting company - Citizenship
        /// Char(2) ISO 3166 two letter code. See Code Table 3
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "Страна регистрации", ControlType = typeof(ComboBox))]
        public string dom_graj;

        /// <summary>
        /// Hosting person – Family name/s OR Contact person from Hosting company – Family name/s
        /// Varchar(100) Latin OR Cyrillic capital letters (A-Z or  А-Я) and spaces. 
        /// Cyrillic alphabet should be used if Hosting person is Bulgarian.
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "Фамилия контактного лица", ControlType = typeof(TextBox))]
        public string dom_famil;

        /// <summary>
        /// Hosting person – First names OR Contact person from Hosting company – First names
        /// Varchar(100) Latin OR Cyrillic capital letters (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if Hosting person is Bulgarian.
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "Имя контактоного лица", PutToRight = true, ControlType = typeof(TextBox))]
        public string dom_ime;

        /// <summary>
        /// Hosting person – National Identification number (for BG citizens - EGN)
        /// Varchar(10) 10 digits number   0-9
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "ИД контактного лица", ControlType = typeof(ComboBox))]
        public string dom_egn;

        /// <summary>
        /// Hosting company/organization identification number (For BG companies only – BULSTAT number)
        /// Varchar(13) Cyrillic capital letters (А-Я) and numbers
        /// </summary>
        [Position(DesiredIndex = -1, GroupName = "Принимающая сторона", Desc = "ИД принимающей организации", PutToRight = true, ControlType = typeof(ComboBox))]
        public string ved_ekpou;

        /// <summary>
        /// Hosting person address - Country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Страна", ControlType = typeof(ComboBox))]
        public string dom_darj;

        /// <summary>
        /// Hosting person address - Place
        /// Varchar(50) Latin OR Cyrillic capital letters (A-Z or  А-Я), 
        /// numbers, dots (.), dashes (-) and spaces. Cyrillic alphabet should be used if 
        /// Hosting person Country is Bulgaria.
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Город", PutToRight = true, ControlType = typeof(ComboBox))]
        public string dom_nm;

        /// <summary>
        /// Hosting person address – ZIP code
        /// Varchar(10)
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Индекс", ControlType = typeof(TextBox))]
        public string dom_pk;

        /// <summary>
        /// Hosting person address - Street, Number, Apartment etc.
        /// Varchar(60) Latin OR Cyrillic capital letters (A-Z or  А-Я), 
        /// numbers, dots (.), dashes (-), slashes(/) and spaces. 
        /// Cyrillic alphabet should be used if Hosting person Country is Bulgaria.
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Улица, дом и т.п.", PutToRight = true, ControlType = typeof(TextBox))]
        public string dom_adres;

        /// <summary>
        /// Hosting person telephone number
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Телефон", ControlType = typeof(TextBox))]
        public string dom_tel;

        /// <summary>
        /// Hosting person fax
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Факс", PutToRight = true, ControlType = typeof(TextBox))]
        public string dom_fax;

        /// <summary>
        /// Hosting person e-mail address
        /// Varchar(250) all allowed symbols in e-mail addresses
        /// </summary>
        [Position(GroupName = "Принимающая сторона (адрес)", Desc = "Электронная почта", ControlType = typeof(TextBox))]
        public string dom_email;
        
        /// <summary>
        /// Hosting company/organization – Name OR Hotel - Name
        /// Varchar(60) Latin OR Cyrillic capital letters (A-Z or  А-Я), numbers, 
        /// dots (.), dashes (-) and spaces . Cyrillic alphabet should be used if 
        /// Hosting company/organization is Bulgarian or registered in Bulgaria.
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Название", ColSpan = 3, ControlType = typeof(ComboBox))]
        public string ved_ime;

        /// <summary>
        /// Hosting company/organization address – Country OR Hotel address - Country
        /// Char(2) ISO 3166 two letter code. See Code Table 2
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Страна", ControlType = typeof(ComboBox))]
        public string ved_darj;

        /// <summary>
        /// Hosting company/organization address - Place OR Hotel address - Place
        /// Varchar(50) Latin OR Cyrillic capital letters (A-Z or  А-Я) and spaces.
        /// Cyrillic alphabet should be used if Hosting company/organization Country is Bulgaria.
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Город", PutToRight = true, ControlType = typeof(ComboBox))]
        public string ved_nm;

        /// <summary>
        /// Hosting company/organization address – ZIP code OR Hotel address – ZIP code
        /// Varchar(10)
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Индекс", ControlType = typeof(TextBox))]
        public string ved_pk;

        /// <summary>
        /// Hosting company/organization address - Street, Number, Apartment etc. OR 
        /// Hotel address - Street, Number, Apartment etc.
        /// Varchar(60) Latin OR Cyrillic capital letters (A-Z or  А-Я), numbers, dots (.), 
        /// dashes (-), slashes (/) and spaces . Cyrillic alphabet should be used if 
        /// Hosting company/ organization Country is Bulgaria.
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Улица, дом и т.п.", PutToRight = true, ControlType = typeof(ComboBox))]
        public string ved_adres;

        /// <summary>
        /// Hosting company/organization telephone number OR Hotel telephone number
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Телефон", ControlType = typeof(TextBox))]
        public string ved_tel;

        /// <summary>
        /// Hosting company/organization Fax number OR Hotel Fax number
        /// Varchar(30) up to 30 digits (0-9) without spaces, dashes  etc.
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Факс", PutToRight = true, ControlType = typeof(TextBox))]
        public string ved_fax;

        /// <summary>
        /// Hosting company/organization e-mail address OR Hotel  e-mail address
        /// Varchar(250) all allowed symbols in e-mail addresses
        /// </summary>
        [Position(GroupName = "Принимающая Компания/Отель", Desc = "Электронная почта", ControlType = typeof(TextBox))]
        public string ved_email;
    }
}
