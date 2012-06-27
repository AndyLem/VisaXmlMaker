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
        public ConverterType ConverterType
        {
            get
            {
                return _convType;
            }
            set
            {
                if (value != _convType)
                {
                    _convType = value;
                    CreateConverter();
                }
            }
        }
        /// <summary>
        /// Like "Y|N", "Yes|No", "A|b" and so on
        /// </summary>
        public string CheckBoxValues
        {
            get
            {
                return _checkBoxValues;
            }
            set
            {
                if (_checkBoxValues != value)
                {
                    _checkBoxValues = value;
                    CreateConverter();
                }
            }
        }

        private string _checkBoxValues;

        private void CreateConverter()
        {
            switch (_convType)
            {
                case Model.ConverterType.Long: _converter = new LongDateTimeConverter(); break;
                case Model.ConverterType.ShortDsMsY: _converter = new DateDsMsYConverter(); break;
                case Model.ConverterType.ShortYmMmD: _converter = new DateYmMmDConverter(); break;
                case Model.ConverterType.ShortYsMsD: _converter = new DateYsMsDConverter(); break;
                case Model.ConverterType.Bool: _converter = new BoolConverter(_checkBoxValues); break;
                default: _converter = new StringConverter(); break;
            }
        }

        private ConverterType _convType;
        private IValueConverter _converter;

        public IValueConverter Converter
        {
            get
            {
                return _converter;
            }
        }

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
            _convType = Model.ConverterType.String;
            _checkBoxValues = "Y|N";
            CreateConverter();
        }

        public Control GetControl()
        {
            object obj = Activator.CreateInstance(ControlType);
            if (obj is Control) return (Control)obj;
            throw new ArgumentException("ControlType must be a Control");
        }
    }

    public enum ConverterType
    {
        String,
        Bool,
        Long,
        ShortYmMmD,
        ShortYsMsD,
        ShortDsMsY
    }

    public interface IValueConverter
    {
        string ConvertToString(object value);
        object ConvertFromString(string line);
    }

    public class StringConverter : IValueConverter
    {
        public string ConvertToString(object value)
        {
            return value.ToString();
        }

        public object ConvertFromString(string line)
        {
            return line;
        }
    }

    public class BoolConverter : IValueConverter
    {
        private string _values;
        private string _y;
        private string _n;

        public BoolConverter(string checkBoxValues)
        {
            _values = checkBoxValues;
            string[] w = checkBoxValues.Split('|');
            if (w.Length != 2) throw new Exception("CheckBoxValues must contain 'Y|N' pair");
            _y = w[0];
            _n = w[1];
        }

        public string ConvertToString(object value)
        {
            bool val = (bool)value;
            return val ? _y : _n;
        }

        public object ConvertFromString(string line)
        {
            if (string.IsNullOrEmpty(line)) return false;
            if (line == _y) return true;
            if (line == _n) return false;            
            throw new Exception("Line does not match Yes|No pair");
        }
    }

    public class DateYmMmDConverter : IValueConverter
    {
        public object ConvertFromString(string line)
        {
            try
            {
                string[] w = line.Split('-');
                int d, m, y;
                d = int.Parse(w[2]);
                m = int.Parse(w[1]);
                y = int.Parse(w[0]);
                return new DateTime(y, m, d);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string ConvertToString(object value)
        {
            DateTime dt = (DateTime) value;
            return string.Format("{0}-{1}-{2}", dt.Year, dt.Month, dt.Day);
        }
    }

    public class DateDsMsYConverter : IValueConverter
    {
        public object ConvertFromString(string line)
        {
            try
            {
                string[] w = line.Split('/');
                int d, m, y;
                d = int.Parse(w[0]);
                m = int.Parse(w[1]);
                y = int.Parse(w[2]);
                return new DateTime(y, m, d);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string ConvertToString(object value)
        {
            DateTime dt = (DateTime)value;
            return string.Format("{2}/{1}/{0}", dt.Year, dt.Month, dt.Day);
        }
    }

    public class DateYsMsDConverter : IValueConverter
    {
        public object ConvertFromString(string line)
        {
            try
            {
                string[] w = line.Split('/');
                int d, m, y;
                d = int.Parse(w[2]);
                m = int.Parse(w[1]);
                y = int.Parse(w[0]);
                return new DateTime(y, m, d);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string ConvertToString(object value)
        {
            DateTime dt = (DateTime) value;
            return string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
        }
    }

    public class LongDateTimeConverter : IValueConverter
    {
        public object ConvertFromString(string line)
        {
            try
            {
                return DateTime.Parse(line);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string ConvertToString(object value)
        {
            DateTime dt = (DateTime)value;
            return dt.ToLongDateString();
        }

    }
}
