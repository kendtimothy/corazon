using CorazonLibrary.DateFormatting.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorazonLibrary.Date
{

    /// <summary>
    /// Provides date formatting services.
    /// </summary>
    public class DateFormatting
    {
        // these values are the format for each possible option in DateFormat enum:
        private const string DateTimeFullFormat = "dd MMMM yyyy hh:mm tt";
        private const string DateTimeFormat = "dd-MMM-yy hh:mm tt";
        private const string DateFullFormat = "dd MMMM, yyyy";
        private const string _DateFormat = "dd-MMM-yy";
        private const string Time24Format = "HH:mm";
        private const string Time12Format = "hh:mm tt";

        /// <summary>
        /// Convert DateTime object to a string with the specified format.
        /// </summary>
        /// <param name="date">The DateTime object to convert.</param>
        /// <param name="format">The format to convert the date.</param>
        /// <returns>Returns the string representation of the DateTime object.</returns>
        public string ToString(DateTime date, DateFormat format)
        {
            string stringValue = null;

            // convert to string using the specified format
            switch (format)
            {
                case DateFormat.DateTimeFull:
                    stringValue = date.ToString(DateTimeFullFormat);
                    break;
                case DateFormat.DateTime:
                    stringValue = date.ToString(DateTimeFormat);
                    break;
                case DateFormat.DateFull:
                    stringValue = date.ToString(DateFullFormat);
                    break;
                case DateFormat.Date:
                    stringValue = date.ToString(_DateFormat);
                    break;
                case DateFormat.Time24:
                    stringValue = date.ToString(Time24Format);
                    break;
                case DateFormat.Time12:
                    stringValue = date.ToString(Time12Format);
                    break;
            }

            return stringValue;
        }

        /// <summary>
        /// Convert a string matching one of the format to a specified DateTime object.
        /// </summary>
        /// <param name="dateText">The text which represents a DateTime value.</param>
        /// <param name="format">The format of the dateText.</param>
        /// <returns></returns>
        public DateTime? Convert(string dateText, DateFormat format)
        {
            DateTime? date = new DateTime();
            
            switch (format)
            {
                case DateFormat.DateTimeFull:
                    date = DateTime.ParseExact(dateText, DateTimeFullFormat, CultureInfo.InvariantCulture);
                    break;
                case DateFormat.DateTime:
                    date = DateTime.ParseExact(dateText, DateTimeFormat, CultureInfo.InvariantCulture);
                    break;
                case DateFormat.DateFull:
                    date = DateTime.ParseExact(dateText, DateFullFormat, CultureInfo.InvariantCulture);
                    break;
                case DateFormat.Date:
                    date = DateTime.ParseExact(dateText, _DateFormat, CultureInfo.InvariantCulture);
                    break;
                case DateFormat.Time24:
                    date = DateTime.ParseExact(dateText, Time24Format, CultureInfo.InvariantCulture);
                    break;
                case DateFormat.Time12:
                    date = DateTime.ParseExact(dateText, Time12Format, CultureInfo.InvariantCulture);
                    break;
            }

            return date;
        }

    }
}
