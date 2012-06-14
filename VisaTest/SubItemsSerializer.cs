using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaXmlMaker.Model;
using System.IO;
using System.Xml.Serialization;

namespace VisaTest
{
    [TestClass]
    public class SubItemsSerializer
    {
        [TestMethod]
        public void RootTest()
        {
            RootLoadOsf srcRoot = new RootLoadOsf();
            srcRoot.msgHeader = CreateHeader();
            srcRoot.lcuz = CreateLcuz();
            srcRoot.lcDop = CreateLcDop();
            srcRoot.basta = CreateBasta();
            srcRoot.maika = CreateMaika();

            string fileName = Path.GetTempFileName();
            FileStream fs = File.Create(fileName);
            XmlSerializer ser = new XmlSerializer(typeof(RootLoadOsf));
            ser.Serialize(fs, srcRoot);
            fs.Position = 0;
            RootLoadOsf dstRoot= (RootLoadOsf)ser.Deserialize(fs);

            fs.Close();
            File.Delete(fileName);

            Assert.AreEqual(srcRoot.msgHeader.msgHeaderRow, dstRoot.msgHeader.msgHeaderRow, 
                "Прочитанное значение MsgHeader отличается от переданного на запись");
            Assert.AreEqual(srcRoot.lcuz.lcuzRow, dstRoot.lcuz.lcuzRow,
                "Прочитанное значение Lcuz отличается от переданного на запись");
            Assert.AreEqual(srcRoot.lcDop.lcDopRow, dstRoot.lcDop.lcDopRow,
                "Прочитанное значение LcDop отличается от переданного на запись");
            Assert.AreEqual(srcRoot.basta.bastaRow, dstRoot.basta.bastaRow,
                "Прочитанное значение Basta отличается от переданного на запись");
            Assert.AreEqual(srcRoot.maika.maikaRow, dstRoot.maika.maikaRow,
                "Прочитанное значение Maika отличается от переданного на запись");

        }

        private static MsgHeader CreateHeader()
        {
            MsgHeader srcHdr = new MsgHeader();
            srcHdr.msgHeaderRow = new MsgHeaderRow()
            {
                mh_kscreated = "MOW",
                mh_regnom = "08005220",
                mh_vfsrefno = "BRGC/1103080005/01",
                mh_usera = "VIS",
                mh_datvav = "2008-08-05"
            };
            return srcHdr;
        }

        private static Lcuz CreateLcuz()
        {
            Lcuz srcLcuz = new Lcuz();
            srcLcuz.lcuzRow = new LcuzRow()
            {
                vid_zp = "P",
                nac_bel = "GE",
                nac_pasp = "A2224",
                pasp_val = "2010-07-23",
                graj = "GE",
                famil = "FIRST",
                imena = "TEST PERSON",
                dat_raj = "1978/03/22",
                pol = "M",
                dat_izd = "2005-07-23"
            };
            return srcLcuz;
        }

        private static LcDop CreateLcDop()
        {
            LcDop srcLcDop = new LcDop();
            srcLcDop.lcDopRow = new LcDopRow()
            {
                ld_mrjdarj = "GE",
                ld_mrjnm = "TBILISI",
                ld_mrjgraj = "GE",
                ld_zenen = "N",
                ld_jit_darj = "GE",
                ld_jit_nm = "TBILISI",
                ld_jit_ul = "BALIGA 22",
                ld_jit_pk = "987987",
                ld_tel = "049233866221123",
                ld_jit_email = "hisemail@yahoo.com",
                ld_rabota = "FIRST BANK",
                ld_profkod = "BK",
                ld_profesia = "",
                ld_sl_darj = "GE",
                ld_sl_nm = "TBILISI",
                ld_sl_ul = "WALLSTREET 23",
                ld_sl_pk = "7657575",
                ld_sltel = "87687687678876",
                ld_sl_fax = "",
                ld_sl_email = ""
            };
            return srcLcDop;
        }

        private static Basta CreateBasta()
        {
            Basta srcBasta = new Basta();
            srcBasta.bastaRow = new BastaRow()
            {
                dc_famil = "NEXT",
                dc_imena = "TATKO"
            };
            return srcBasta;
        }

        private static Maika CreateMaika()
        {
            Maika srcMaika = new Maika();
            srcMaika.maikaRow = new MaikaRow()
            {
                dc_famil = "NEXT",
                dc_imena = "MAIKA"
            };
            return srcMaika;
        }
    }
}
