using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Dev.Helpers
{

    public static class DateTimeExtensions
    {
        static string[] ruMonthNames = { "Нулября", "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" };

        public static string GetMonthName(this DateTime date)
        {
            int currentMonth = date.Month;
            string monthName = ruMonthNames[currentMonth];
            monthName = CultureInfo.CurrentUICulture.TextInfo.ToLower(monthName);
            return monthName;
        }
    }
}
