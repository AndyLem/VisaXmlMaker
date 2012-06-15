using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaXmlMaker.Model;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Imaging;

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
            srcRoot.sapruga = CreateSapruga();
            srcRoot.molba = CreateMolba();
            srcRoot.domakin = CreateDomakin();
            srcRoot.euroda = CreateEuroda();
            srcRoot.oldVisa = CreateOldVisa();
            srcRoot.voit = CreateVoit();
            srcRoot.images = CreateImages();

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
            Assert.AreEqual(srcRoot.sapruga.saprugaRow, dstRoot.sapruga.saprugaRow,
                "Прочитанное значение Sapruga отличается от переданного на запись");
            Assert.AreEqual(srcRoot.molba.molbaRow, dstRoot.molba.molbaRow,
                "Прочитанное значение Molba отличается от переданного на запись");
            Assert.AreEqual(srcRoot.domakin.domakinRow, dstRoot.domakin.domakinRow,
                "Прочитанное значение Domakin отличается от переданного на запись");
            Assert.AreEqual(srcRoot.euroda.eurodaRow, dstRoot.euroda.eurodaRow,
                "Прочитанное значение Domakin отличается от переданного на запись");

            Assert.AreEqual(srcRoot.oldVisa.oldVisaRows.Count, dstRoot.oldVisa.oldVisaRows.Count,
                "Количество информации в OldVisa не совпадает");
            Assert.AreEqual(srcRoot.oldVisa.oldVisaRows[0], dstRoot.oldVisa.oldVisaRows[0],
                "Прочитанное значение OldVisa отличается от переданного на запись");

            Assert.AreEqual(srcRoot.voit.voitRow, dstRoot.voit.voitRow,
                "Прочитанное значение Voit отличается от переданного на запись");
            Assert.AreEqual(srcRoot.images.imagesRow, dstRoot.images.imagesRow,
                "Прочитанное значение Images отличается от переданного на запись");
        }

        [TestMethod]
        public void ImageConversionTest()
        {
            try
            {
                Image im = Properties.Resources.TestImage;
                RootLoadOsf root = new RootLoadOsf();
                root.images.imagesRow.im_image =
                    VisaXmlMaker.Model.ImageConverter.ConvertImageToBase64(im, ImageFormat.Jpeg);
                string fileName = Path.GetTempFileName();
                FileStream fs = File.Create(fileName);
                XmlSerializer ser = new XmlSerializer(typeof(RootLoadOsf));
                ser.Serialize(fs, root);
                fs.Close();
                File.Delete(fileName);
            }
            catch
            {
                Assert.Fail("Ошибка сохранения тестовой картинки");
            }
        }

        private static Images CreateImages()
        {
            Images srcImages = new Images();
            srcImages.imagesRow = new ImagesRow()
            {
                im_devicetype = "50",
                im_width = "337",
                im_height = "449",
                im_imglen = "40112",
                im_image = ""
            };


            return srcImages;
        }

        private static Voit CreateVoit()
        {
            Voit srcVoit = new Voit();
            srcVoit.voitRow = new VoitRow()
            {
                vnom = "5674664565-VOIT-667",
                voit_datot = "2008-12-08",
                voit_datdo = "2008-22-08",
                vime = "BALKAN TUR LTD",
                bgime = "НОВ БАЛКАНСКИ ТУР ОПЕРАТОР",
                bgadres = "Х-Л КАЛИНА АЛЕНА, БАНСКО",
                tel = ""
            };

            return srcVoit;
        }

        private static OldVisa CreateOldVisa()
        {
            OldVisa srcOldVisa = new OldVisa();
            srcOldVisa.oldVisaRows.Add(new OldVisaRow()
                {
                    ov_nacbel = "AT",
                    ov_vidvis = "C",
                    ov_visnom = "АТ1234567",
                    ov_dataot = "2005-02-01",
                    ov_datado = "2006-01-31",
                    ov_brvl = "M"
                });
            srcOldVisa.oldVisaRows.Add(new OldVisaRow()
            {
                ov_nacbel = "BY",
                ov_vidvis = "D",
                ov_visnom = "BY8907654",
                ov_dataot = "2011-02-01",
                ov_datado = "2021-01-31",
                ov_brvl = "M"
            });
            return srcOldVisa;
        }

        private static Euroda CreateEuroda()
        {
            Euroda srcEuroda = new Euroda();
            srcEuroda.eurodaRow = new EurodaRow()
            {
                eu_famil = "АЛ МАГРЕБИ",
                eu_imena = "ПЕЙО ПЕЕВ",
                eu_datraj = "11/12/1995",
                eu_nac_bel = "BG",
                eu_nac_pasp = "ZP1234567",
                eu_rodstvo = "D"
            };
            return srcEuroda;
        }

        private static Domakin CreateDomakin()
        {
            Domakin srcDomakin = new Domakin();
            srcDomakin.domakinRow = new DomakinRow()
            {
                dm_vid = "F",
                nom_pok = "9876543210-234/12.09.2007",
                dom_graj = "BG",
                dom_famil = "СТОЯНОВ",
                dom_ime = "ИВАН",
                dom_egn = "",
                dom_darj = "",
                dom_nm = "",
                dom_pk = "",
                dom_adres = "",
                dom_tel = "",
                dom_fax = "",
                dom_email = "",
                ved_ekpou = "831022415Ю",
                ved_ime = "КАНЕЩА ФИРМА СОФИЙСКА",
                ved_darj = "BG",
                ved_nm = "СОФИЯ",
                ved_pk = "1000",
                ved_adres = "АЛАБИН 24",
                ved_tel = "2311444",
                ved_fax = "6615782",
                ved_email = "kanestafirma@sofia.bg"

            };
            return srcDomakin;
        }

        private static Molba CreateMolba()
        {
            Molba srcMolba = new Molba();
            srcMolba.molbaRow = new MolbaRow()
            {
			    dat_vli = "2008-08-07",
			    dat_izl = "2008-09-06",
			    vidvis = "C",
			    brvl = "1",
			    vidus = "O",
			    valvis = "",
			    brdni = "30",
			    cel = "GOS",
			    celdruga = "",
			    mol_dat_vav = "2008-08-05T13:20:43.92100",
			    gratis = "N",
			    imavisa = "",
			    cenamol = "90.00",
			    cenacurr = "USD",
			    maindest = "BG",
			    maindestnm = "ЛОМ",
			    gkpp_darj = "BG",
			    gkpp_text = "ГКПП АЕРОГАРА СОФИЯ",
			    marsrut = "",
                Text_ini = ""
            };
            return srcMolba;
        }

        private static Sapruga CreateSapruga()
        {
            Sapruga srcSapruga = new Sapruga();
            srcSapruga.saprugaRow = new SaprugaRow()
            {
                sp_famil = "AL MAGHREBI",
                sp_imena = "AYSHE",
                sp_famil2 = "MUSTAPHA",
                sp_datraj = "22/03/1977",
                sp_mrjdarj = "GH",
                sp_mrjnm = "ACCRA"
            };
            return srcSapruga;
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
