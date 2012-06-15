using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VisaXmlMaker.Model
{
    /// <summary>
    /// scanned or captured by digital camera facial image of the applicant
    /// </summary>
    public class Images
    {
        [XmlElement(ElementName = "d_images_row")]
        public ImagesRow imagesRow;
    }

    public struct ImagesRow
    {
        /// <summary>
        /// Information about used imaging device
        /// Varchar(3) 
        /// 50 = Flatbed Scanner
        /// 250 = Digital camera
        /// </summary>
        public string im_devicetype;

        /// <summary>
        /// Image width in pixels
        /// Varchar(3) number
        /// </summary>
        public string im_width;
        
        /// <summary>
        /// Image height in pixels
        /// Varchar(3) number
        /// </summary>
        public string im_height;

        /// <summary>
        /// Length in bytes of Base64 encoded jpeg 2000 compressed image
        /// Varchar(5) number
        /// </summary>
        public string im_imglen;
        
        /// <summary>
        /// Base64 encoded jpeg2000 compressed facial image
        /// ICAO compliant full frontal image, 300 dpi scanning 
        /// resolution if scanned, preferred size is 337x449 pixels.
        /// Jpeg2000 compressed image size doesn’t have to exceed 30kB.
        /// </summary>
        public string im_image;
    }
}
