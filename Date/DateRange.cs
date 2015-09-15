using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorazonLibrary.Date
{
    /// <summary>
    /// Provides date range functionalities.
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// Check if two date ranges clash.
        /// </summary>
        /// <param name="startDate1">The start date of the first date range.</param>
        /// <param name="endDate1">The end date of the first date range.</param>
        /// <param name="startDate2">The start date of the second date range.</param>
        /// <param name="endDate2">The end date of the second date range.</param>
        /// <param name="inclusiveStart">(Optional) Set to true for inclusive start date check. Default value is false.</param>
        /// <param name="inclusiveEnd">(Optional) Set to true for inclusive end date check. Default value is false.</param>
        /// <returns>Returns true if clash is found, false otherwise.</returns>
        public bool IsDateRangeClash(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, bool inclusiveStart = false, bool inclusiveEnd = false)
        {
            // init isSuccess
            bool isClash = false;

            if (inclusiveStart)
            {
                if (inclusiveEnd)
                {
                    // ALL INCLUSIVE
                    if ((startDate1 <= endDate2) && (startDate2 <= endDate1))
                        isClash = true;
                }
                else
                {
                    // ONLY INCLUSIVE START
                    if ((startDate1 <= endDate2) && (startDate2 < endDate1))
                        isClash = true;
                }
            }
            else
            {
                if (inclusiveEnd)
                {
                    // ONLY INCLUSIVE END
                    if ((startDate1 < endDate2) && (startDate2 <= endDate1))
                        isClash = true;
                }
                else
                {
                    // EXCLUSIVE (default case with inclusiveStart = inclusiveEnd = false)
                    if ((startDate1 < endDate2) && (startDate2 < endDate1))
                        isClash = true;
                }
            }

            return isClash;
        }
    }
}
