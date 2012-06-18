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
        Model.RootLoadOsf rootObj = new Model.RootLoadOsf();
        Controller.TabsController tabsCtrl = new Controller.TabsController();

        public MainForm()
        {
            InitializeComponent();
            tabsCtrl.FillGrid(rootObj.msgHeader.msgHeaderRow, msgHeaderTable);
            tabsCtrl.FillGrid(rootObj.lcuz.lcuzRow, lcuzTable);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Controller.TabsController ctrl = new Controller.TabsController();
            ctrl.FillGrid(new VisaXmlMaker.Model.BastaRow(), domakinTable);
            ctrl.FillGrid(new VisaXmlMaker.Model.MaikaRow(), domakinTable);
            ctrl.FillGrid(new VisaXmlMaker.Model.SaprugaRow(), domakinTable);
        }
    }
}
