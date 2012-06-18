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

                Control control = CreateAndStyleControl(info.PositionAttr);
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
            }

            //            string desc = pAttr.Desc;

            //            Control control = CreateAndStyleControl(pAttr);
            //            Label l = CreateAndStyleLabel(desc);

            //            if (pAttr.PutToRight)
            //            {
            //                if (currentRightFilled)
            //                {
            //                    currentRow++;
            //                    currentLeftFilled = false;
            //                    currentRightFilled = false;
            //                }
            //                currentColumn = 2;
            //                currentRightFilled = true;
            //            }
            //            else
            //            {
            //                if (currentLeftFilled)
            //                {
            //                    currentRow++;
            //                    currentLeftFilled = false;
            //                    currentRightFilled = false;
            //                }
            //                currentColumn = 0;
            //                currentLeftFilled = true;
            //            }

            //            while (currentRow >= table.RowCount)
            //                table.RowCount++;

            //            table.Controls.Add(l, currentColumn, currentRow);
            //            table.Controls.Add(control, currentColumn + 1, currentRow);

            //            break;
            //        }
            //    }
            //}
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

        private static Control CreateAndStyleControl(PositionAttribute pAttr)
        {
            Control c = pAttr.GetControl();
            c.Padding = new Padding(5);
            c.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            return c;
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
