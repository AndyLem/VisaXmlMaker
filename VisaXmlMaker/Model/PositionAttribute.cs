using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisaXmlMaker.Model
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class PositionAttribute : Attribute
    {
        public string DescResourceName { get; set; }
        public int DesiredIndex { get; set; }
        public string Desc { get; set; }
        public bool PutToRight { get; set; }
        public string GroupName { get; set; }
        public int ColSpan { get; set; }

        /// <summary>
        /// TextBox, Combobox, DateTimePicker etc.
        /// </summary>
        public Type ControlType { get; set; }

        // This is a positional argument
        public PositionAttribute()
        {
            DescResourceName = string.Empty;
            DesiredIndex = 0;
            Desc = string.Empty;
            PutToRight = false;
            ControlType = typeof(TextBox);
            ColSpan = 1;
        }

        public Control GetControl()
        {
            object obj = Activator.CreateInstance(ControlType);
            if (obj is Control) return (Control)obj;
            throw new ArgumentException("ControlType must be a Control");
        }
    }
}
