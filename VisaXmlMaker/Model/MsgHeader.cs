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

        public MsgHeader()
        {
            msgHeaderRow = new MsgHeaderRow()
            {
                mh_kscreated = "MIN",
                mh_regnom = "01234567",
                mh_vfsrefno = "BGRC/110308/0005/01",
                mh_usera = "ABC",
                mh_datvav = "2012-06-13"
            };
        }
    }

    public struct MsgHeaderRow
    {
        public string mh_kscreated;
        public string mh_regnom;
        public string mh_vfsrefno;
        public string mh_usera;
        public string mh_datvav;
    }
}
