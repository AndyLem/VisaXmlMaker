﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// applicant’s passport data
    /// </summary>
    public class Lcuz
    {
        [XmlElement(ElementName = "d_lcuz_row")]
        public LcuzRow lcuzRow;

    }

    public class LcuzRow
    {
        /// <summary>
        /// Type of passport
        /// Char(1)  one letter code.  See Code Table 1
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Тип паспорта", 
            ControlType = typeof(ComboBox), ListerName="docTypes", OnlyFromList=true)]
        public string vid_zp;

        /// <summary>
        /// Issuing country
        /// Char(2) ISO 3166 two letter Country code.  See Code Table 2
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 2, Desc = "Страна, выдавшая паспорт",
            ControlType = typeof(ComboBox), ListerName = "countries", OnlyFromList = true)]
        public string nac_bel;

        /// <summary>
        /// Passport Number as printed in MRZ
        /// Varchar(30) alphanumeric A-Z  0-9, no spaces allowed
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Номер паспорта")]
        public string nac_pasp;

        /// <summary>
        /// Passport date of expiry
        /// yyyy-mm-dd
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Срок действия паспорта", 
            ControlType = typeof(DateTimePicker), ConverterType = ConverterType.ShortYmMmD)]
        public string pasp_val;

        /// <summary>
        /// Date of issuance of the passport
        /// yyyy-mm-dd
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Дата выдачи паспорта",
            ControlType = typeof(DateTimePicker), ConverterType = ConverterType.ShortYmMmD)]
        public string dat_izd;

        /// <summary>
        /// Citizenship of the applicant
        /// Char(2) ISO 3166 two letter code. See Code Table 3
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Гражданство",
            ControlType = typeof(ComboBox), ListerName = "countries", OnlyFromList = true)]
        public string graj;

        /// <summary>
        /// Surname/s (family name/s) as in the passport
        /// Varchar(100) Latin capital letters only (A-Z) and spaces between surnames
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 2, Desc = "Фамилия")]
        public string famil;

        /// <summary>
        /// First Names as in the passport
        /// Varchar(100) Latin capital letters only (A-Z) and spaces between names
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 2, Desc = "Имена")]
        public string imena;

        /// <summary>
        /// Date of birth
        /// Char(10)  yyyy/mm/dd IF day or month of the date of birth are unknown, substitute with 00
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Дата рождения",
            ControlType = typeof(DateTimePicker), ConverterType = ConverterType.ShortYsMsD)]
        public string dat_raj;

        /// <summary>
        /// Sex
        /// Char(1)  M = male F = female
        /// </summary>
        [Position(GroupName = "Информация о паспорте", ColSpan = 1, Desc = "Пол", ControlType = typeof(ComboBox),
            ListerName="sex", OnlyFromList=true)]
        public string pol;


    }
}
