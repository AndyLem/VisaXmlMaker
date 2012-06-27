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
using VisaXmlMaker.Model;

namespace VisaXmlMaker
{
    public partial class MainForm : Form
    {
        Model.RootLoadOsf rootObj = new Model.RootLoadOsf();
        Controller.TabsController tabsCtrl = new Controller.TabsController();

        public MainForm()
        {
            InitializeComponent();
            rootObj = ModelIO.Load("data.xml");
            if (rootObj != null)
                tabsCtrl.Fill(this, rootObj);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void loadImageBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
