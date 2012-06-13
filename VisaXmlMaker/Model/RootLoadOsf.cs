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
        [XmlElement(ElementName="d_msgheader")]
        public MsgHeader msgHeader;

        [XmlElement(ElementName = "d_lcuz")]
        public Lcuz lcuz;

        [XmlAttribute(AttributeName="version")]
        public string version = "1.000";

        [XmlElement(ElementName="d_sapruga", IsNullable=false)]
        public Sapruga sapruga;

        public RootLoadOsf()
        {
            msgHeader = new MsgHeader();
            lcuz = new Lcuz();
            sapruga = new Sapruga();
        }
    }
}
