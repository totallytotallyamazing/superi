using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;

namespace Dev.Controllers
{
    public class ArticlesController : LocalizedController
    {
        public ActionResult Index(string date, int? page)
        {
            if(!string.IsNullOrEmpty(date))
                ViewData["expand"] = false;

            using (DataStorage context = new DataStorage())
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                DateTime startDate = DateTime.Now.AddDays(-DateTime.Now.Day);
                DateTime endDate = DateTime.Now.AddDays(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - DateTime.Now.Day);
                if (!string.IsNullOrEmpty(date))
                {
                    string[] dateParts = date.Split('-');
                    year = int.Parse(dateParts[0]);
                    month = int.Parse(dateParts[1]);

                    startDate = new DateTime(year, month, 1);
                    int nextYear = year;
                    int nextMonth = month + 1;
                    if (nextMonth == 13)
                    {
                        nextMonth = 1;
                        nextYear++;
                    }
                    endDate = new DateTime(nextYear, nextMonth, 1);
                }

                ViewData["year"] = year;
                ViewData["month"] = month;

                string cultureName = LocaleHelper.GetCultureName();
                List<Article> articles = context.Articles
                    .Where(a => a.Language == cultureName && a.Type == (int)ArticleType.Note)
                    .Where(a => a.Date > startDate && a.Date < endDate)
                    .OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View(articles);
            }
        }

        public ActionResult Show(string name)
        {
            ViewData["expand"] = false;

            using (DataStorage context = new DataStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                Article article = context.Articles.Where(a => a.Language == cultureName && a.Type == (int)ArticleType.Note).Select(a => a).First();
                return View(article);
            }
        }
    }
}