using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dev.Helpers;
using System.Web.Mvc;
using System.Globalization;

namespace Shop.Helpers
{
    public enum Currencies
    {
        Dollar, Euro, Ruble, Hrivna
    }

    public static class CurrencyHelper
    {
        public static float Convert(float amount, Currencies currency)
        {
            switch (currency)
            {
                case Currencies.Dollar:
                    return amount / WebSession.Settings.DollarRate;
                case Currencies.Euro:
                    return amount / WebSession.Settings.EuroRate;
                case Currencies.Ruble:
                    return amount / WebSession.Settings.RubleRate;
                default:
                    return amount;
            }
        }

        public static string RenderPrice(this HtmlHelper helper, float price, Currencies currency, int decimalPlaces, string groupSeparator)
        {
            float amount = Convert(price, currency);
            string currencySymbol = "грн.";
            int currencyPattern = 3;
            switch (currency)
            {
                case Currencies.Dollar:
                    currencySymbol = "$";
                    currencyPattern = 0;
                    break;
                case Currencies.Euro:
                    currencySymbol = "€";
                    currencyPattern = 0;
                    break;
                case Currencies.Ruble:
                    currencySymbol = "руб.";
                    currencyPattern = 3;
                    break;
            }
            CultureInfo info = CultureInfo.CreateSpecificCulture("en-US");
            info.NumberFormat.CurrencyDecimalDigits = decimalPlaces;
            info.NumberFormat.CurrencyGroupSeparator = groupSeparator;
            info.NumberFormat.CurrencySymbol = currencySymbol;
            info.NumberFormat.CurrencyPositivePattern = currencyPattern;

            return string.Format(info, "{0:c}", price);
        }
    }
}
