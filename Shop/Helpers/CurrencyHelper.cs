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

        public static string FormatPrice(float price, Currencies currency, int decimalPlaces, string groupSeparator)
        {
            float amount = Convert(price, currency);
            string currencySymbol = "<span>грн.</span>";
            int currencyPattern = 3;
            switch (currency)
            {
                case Currencies.Dollar:
                    currencySymbol = "<span>$</span>";
                    currencyPattern = 0;
                    break;
                case Currencies.Euro:
                    currencySymbol = "<span>€</span>";
                    currencyPattern = 0;
                    break;
                case Currencies.Ruble:
                    currencySymbol = "<span>руб.</span>";
                    currencyPattern = 3;
                    break;
            }
            CultureInfo info = CultureInfo.CreateSpecificCulture("en-US");
            info.NumberFormat.CurrencyDecimalDigits = decimalPlaces;
            info.NumberFormat.CurrencyGroupSeparator = groupSeparator;
            info.NumberFormat.CurrencySymbol = currencySymbol;
            info.NumberFormat.CurrencyPositivePattern = currencyPattern;

            return string.Format(info, "{0:c}", amount);
        }

        public static string RenderPrice(this HtmlHelper helper, float price, Currencies currency, int decimalPlaces, string groupSeparator)
        {
            return FormatPrice(price, currency, decimalPlaces, groupSeparator);
        }

        #region Amount spelling
        static string[] lessThenTen = "ноль один два три четыре пять шесть семь восемь девять".Split();
        static string[] tenToTwelve = "десять одиннадцать двенадцать тринадцать четырнадцать пятнадцать шестнадцать семнадцать восемнадцать девятнадцать".Split();
        static string[] twentyToNinety = "ноль десять двадцать тридцать сорок пятьдесят шестьдесят семьдесят восемьдесят девяносто".Split();
        static string[] hundredToNine = "ноль сто двести триста четыреста пятьсот шестьсот семьсот восемьсот девятьсот".Split();
        static string[] rank = @" тысяч миллион миллиард триллион квадриллион квинтиллион секстиллион септиллион октиллион нониллион дециллион андециллион дуодециллион тредециллион кваттордециллион квиндециллион сексдециллион септемдециллион октодециллион новемдециллион вигинтиллион анвигинтиллион дуовигинтиллион тревигинтиллион кватторвигинтиллион квинвигинтиллион сексвигинтиллион септемвигинтиллион октовигинтиллион новемвигинтиллион тригинтиллион антригинтиллион".Split();

        private static IEnumerable<string> SplitToRanks(string s)
        {
            s = s.PadLeft(s.Length + 3 - s.Length % 3, '0');
            return Enumerable.Range(0, s.Length / 3).Select(i => s.Substring(i * 3, 3));
        }

        //вывести название цифр в разряде
        static IEnumerable<string> Spell(IEnumerable<string> n)
        {
            var ii = 0;
            foreach (var s in n)
            {
                var countdown = n.Count() - ++ii;
                yield return
                    String.Format(@"{0} {1} {2} {3}",
                        s[0] == '0' ? "" : hundredToNine[GetDigit(s[0])],
                        GetFirstDigit(s[1], s[2]),
                        GetSecondDigit(s[1], s[2], countdown),
                        s == "000" ? "" : GetRankName(s, countdown)
                    );
            }
        }

        private static int GetDigit(char p1)
        {
            return Int32.Parse(p1.ToString());
        }

        //вторая цифра разряда
        private static string GetFirstDigit(char p1, char p2)
        {
            if (p1 != '0')
            {
                if (p1 == '1')
                    return tenToTwelve[GetDigit(p2)];
                return twentyToNinety[GetDigit(p1)];
            }
            return "";
        }
        //третья цифра разряда
        private static string GetSecondDigit(char p1, char p2, int cd)
        {
            if (p1 != '1')
            {
                if (p2 == '0') return "";
                return (p2 == '2' && cd == 1) ? "две" : lessThenTen[GetDigit(p2)];
            }
            return "";
        }


        private static string GetRankName(string s, int ii)
        {
            if (ii == 0) return "";
            var r = rank[ii];
            //10 11 ...
            if (s[1] == '1') return r + (ii == 1 ? "" : "ов");

            if (new[] { '2', '3', '4' }.Contains(s[2]))
            {
                return r + (ii == 1 ? "и" : "а");
            }
            else
                return r + (ii == 1 ? "" : "ов");
        }


        #endregion
    }   
}
