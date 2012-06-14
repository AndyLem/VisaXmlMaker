using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// корневой узел анкеты. 
    /// </summary>
    [XmlRoot(ElementName = "d_loadosf")]
    public class RootLoadOsf
    {
        /// <summary>
        /// Версия структуры данных. Требуется значение 1.000
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public string version = "1.000";
        
        /// <summary>
        /// unique visa application number and date and place of the XML file creation
        /// </summary>
        [XmlElement(ElementName="d_msgheader")]
        public MsgHeader msgHeader;

        /// <summary>
        ///  applicant’s passport data
        /// </summary>
        [XmlElement(ElementName = "d_lcuz")]
        public Lcuz lcuz;

        /// <summary>
        /// applicant’s additional personal data
        /// </summary>
        [XmlElement(ElementName = "d_lcdop", IsNullable=false)]
        public LcDop lcDop;

        /// <summary>
        /// Father’s data
        /// </summary>
        [XmlElement(ElementName="d_basta")]
        public Basta basta;

        /// <summary>
        /// Mother’s  data
        /// </summary>
        [XmlElement(ElementName = "d_maika")]
        public Maika maika;

        /// <summary>
        /// spouse’s data
        /// </summary>
        [XmlElement(ElementName="d_sapruga", IsNullable=false)]
        public Sapruga sapruga;

        /// <summary>
        /// visa application data
        /// </summary>
        [XmlElement(ElementName="d_molba")]
        public Molba molba;

        public RootLoadOsf()
        {
            msgHeader = new MsgHeader();
            lcuz = new Lcuz();
            lcDop = new LcDop();
            basta = new Basta();
            maika = new Maika();
            sapruga = new Sapruga();
            molba = new Molba();
        }
    }
}
