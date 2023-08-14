using System;
using System.Globalization;

namespace Aien_Test.Common.Utilities
{
    public static class Infrastructure
    {

        #region date time extensions

        public static string ConvertToPersianDate(this DateTime georgianDate)
        {
            PersianCalendar pc = new();

            string persianDateString =
                $"{pc.GetYear(georgianDate)}/{pc.GetMonth(georgianDate)}/{pc.GetDayOfMonth(georgianDate)}";

            return persianDateString;
        }

        #endregion

    }
}

