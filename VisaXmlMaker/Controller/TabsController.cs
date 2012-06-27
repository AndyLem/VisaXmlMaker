using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using VisaXmlMaker.Model;

namespace VisaXmlMaker.Controller
{
    public class TabsController
    {
        public void Fill(MainForm form, RootLoadOsf rootObj)
        {
            FillGrid(rootObj.msgHeader.msgHeaderRow, form.msgHeaderTable);
            FillGrid(rootObj.lcuz.lcuzRow, form.lcuzTable);
            FillGrid(rootObj.lcDop.lcDopRow, form.lcDopTable);

            FillGrid(rootObj.basta.bastaRow, form.familyTable);
            FillGrid(rootObj.maika.maikaRow, form.familyTable);
            FillGrid(rootObj.sapruga.saprugaRow, form.familyTable);

            FillGrid(rootObj.molba.molbaRow, form.molbaTable);
            FillGrid(rootObj.domakin.domakinRow, form.domakinTable);
            FillGrid(rootObj.euroda.eurodaRow, form.eurodaTable);
            FillGrid(rootObj.voit.voitRow, form.voitTable);


            try
            {
                form.pictureBox.Image = ImageConverter.ConvertBase64ToImage(rootObj.images.imagesRow.im_image);
            }
            catch
            {
            }
        }

        public void FillGrid(object filler, TableLayoutPanel table)
        {
            FieldInfo[] fieldInfos;
            fieldInfos = filler.GetType().GetFields();

            List<FillInfo> fills = new List<FillInfo>();

            foreach (FieldInfo info in fieldInfos)
            {
                object[] custAttibs = info.GetCustomAttributes(true);
                foreach (object oAttr in custAttibs)
                {
                    if (oAttr is PositionAttribute)
                    {
                        PositionAttribute pAttr = (PositionAttribute)oAttr;
                        fills.Add(new FillInfo() { Client = filler, Field = info, PositionAttr = pAttr });
                        break;
                    }
                }
            }

            var sortedFills = from info 
                                  in fills 
                              orderby info.PositionAttr.DesiredIndex, info.PositionAttr.GroupName
                              select info;
            
            int currentRow = table.RowCount;
            int currentColumn = 0;
            bool currentLeftFilled = false;
            bool currentRightFilled = false;
            string currentGroup = string.Empty;
            foreach (FillInfo info in sortedFills)
            {
                string group = info.PositionAttr.GroupName;
                if (group != currentGroup)
                {
                    currentGroup = group;
                    if (!string.IsNullOrEmpty(currentGroup))
                    {
                        if (currentLeftFilled || currentRightFilled)
                        {
                            currentRow++;

                        }
                        currentLeftFilled = currentRightFilled = true;
                        Label groupCaptionLabel = CreateAndStyleGroupLabel(group);
                        table.Controls.Add(groupCaptionLabel, 0, currentRow);
                        table.SetColumnSpan(groupCaptionLabel, 2);
                    }
                }

                Control control = CreateAndStyleControl(info);
                Label l = CreateAndStyleLabel(info.PositionAttr.Desc);

                if (info.PositionAttr.PutToRight)
                {
                    if (currentRightFilled)
                    {
                        currentRow++;
                        currentLeftFilled = false;
                        currentRightFilled = false;
                    }
                    currentColumn = 2;
                    currentRightFilled = true;
                }
                else
                {
                    if (currentLeftFilled)
                    {
                        currentRow++;
                        currentLeftFilled = false;
                        currentRightFilled = false;
                    }
                    currentColumn = 0;
                    currentLeftFilled = true;
                }

                while (currentRow >= table.RowCount)
                    table.RowCount++;

                table.Controls.Add(l, currentColumn, currentRow);
                table.Controls.Add(control, currentColumn + 1, currentRow);
                table.SetColumnSpan(control, info.PositionAttr.ColSpan);
                if (info.PositionAttr.ColSpan > 1)
                    currentRightFilled = true;
            }
            
            table.RowCount++;
        }

        private Label CreateAndStyleGroupLabel(string group)
        {
            Label l = new Label();
            l.Text = group;
            l.Padding = new Padding(5);
            l.AutoSize = false;
            l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            l.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            l.Font = new System.Drawing.Font(l.Font, System.Drawing.FontStyle.Bold);
            return l;
        }

        private static Label CreateAndStyleLabel(string desc)
        {
            Label l = new Label();
            l.Text = desc;
            l.Padding = new Padding(5);
            l.AutoSize = false;
            l.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            l.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            return l;
        }

        private static Control CreateAndStyleControl(FillInfo info)
        {
            Control c = info.PositionAttr.GetControl();
            UpdateControlValue(info, c);
            c.Padding = new Padding(5);
            c.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            c.Tag = info;
            c.TextChanged += new EventHandler(ControlTextChanged);
            return c;
        }

        static void ControlTextChanged(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            FillInfo info = (FillInfo)c.Tag;

            UpdateFieldValue(info, c);
        }

        private static void UpdateFieldValue(FillInfo info, Control c)
        {
            if ((c is TextBox) || (c is ComboBox))
            {
                info.Field.SetValue(info.Client, c.Text);
            }
            else if (c is DateTimePicker)
            {
                DateTime dt = ((DateTimePicker)c).Value;
                IValueConverter conv = info.PositionAttr.Converter;
                if (conv != null)
                {
                    string val = conv.ConvertToString(dt);
                    info.Field.SetValue(info.Client, val);
                }
            }
        }

        private static void UpdateControlValue(FillInfo info, Control c)
        {
            /// Getting the value of the field. All fields are strings but they can be null or empty so we need
            /// to check this state
            object value = info.Field.GetValue(info.Client);
            if (value != null)
            {
                /// if the value of the field is not null we must convert it to the form needed to the Control using IValueConverter
                IValueConverter conv = info.PositionAttr.Converter;

                /// value of the field in form for the Control
                object val = null;
                if (conv != null)
                    val = conv.ConvertFromString(value.ToString());
                if (val != null)
                {
                    try
                    {
                        if (c is TextBox)
                            c.Text = (string)val;
                        else if (c is ComboBox)
                            c.Text = (string)val;
                        else if (c is DateTimePicker)
                            (c as DateTimePicker).Value = (DateTime)val;
                        else if (c is CheckBox)
                            (c as CheckBox).Checked = (bool)val;
                    }
                    catch
                    {
                        throw new Exception("IValueConverter returned incorrect object " + info.Field.Name);
                    }
                }
            }
        }


    }

    public class FillInfo
    {
        public object Client { get; set; }
        public FieldInfo Field { get; set; }
        public PositionAttribute PositionAttr { get; set; }

        public FillInfo()
        {
        }
    }
}
