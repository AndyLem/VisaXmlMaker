using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace VisaXmlMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FileStream fs = File.Open("imTest.xml", FileMode.Open);
            XmlSerializer ser = new XmlSerializer(typeof(Model.RootLoadOsf));
            Model.RootLoadOsf root = (Model.RootLoadOsf)ser.Deserialize(fs);
            fs.Close();

            Image im = Model.ImageConverter.ConvertBase64ToImage(root.images.imagesRow.im_image);
            pictureBox1.Image = im;
        }
    }
}
