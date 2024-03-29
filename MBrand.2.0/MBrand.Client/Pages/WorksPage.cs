﻿using System.Html;
using MBrand.Client.Utility;
using jQueryApi;
using System;
using System.Runtime.CompilerServices;
using jQueryApi.JsRender;
using System.Collections;
using BasePage = MBrand.Client.Pages.Page;
namespace MBrand.Client.Pages
{
    public class WorksPage : Page
    {
        private const string WorkContentUrl = "/Content/Get/worksIntro";
        private const string WorksUrlFormat = "/Works/Items/{0}";
        private const int WorkItemWidth = 290;
        private const string WorkItemTemplateSelector = "#workItemTemplate";
        private const string WorksContentSelector = "#worksContent";
        private const string PagerTemplateSelector = "#pagerTemplate";

        private int _pageWidth;
        private int _currentPage;
        private int _pageSize;
        private int _pageCount;
        private int _workGroupId;

        Array _works = new Array();

        public override string Url
        {
            get { return "/Works"; }
        }

        public override string Name
        {
            get { return "WorksPage"; }
        }

        public string WorkGroupName
        {
            get { return (string)Path[0]; }
        }

        public int Page
        {
            get { return !string.IsNullOrEmpty((string)Path[1]) ? int.Parse((string)Path[1]) : 0; }
        }

        protected override void Initialize()
        {
            LoadContent();
            PageManager.Current.AddressChanged += CurrentAddressChanged;
        }

        public override void Dispose()
        {
            PageManager.Current.AddressChanged -= CurrentAddressChanged;
        }

        void CurrentAddressChanged(AddressChangeEventArgs args)
        {
            jQuery.Select("#workGroups li a").RemoveClass("current");
            if (args.Path.Length > 1)
            {
                args.PreventDefault = true;
                BasePage.ChangePage(typeof(WorkPage), (string[])args.Path.Extract(1));
            }
        }

        public override Page UpdateInstance()
        {
            if (Path.Length > 1)
            {
                return Create(typeof(WorkPage), (string[])Path.Extract(1));
            }
            return base.UpdateInstance();
        }

        private void LoadContent()
        {
            if (Path.Length > 0)
            {
                jQuery.Select("#mainNav .current").AddClass("expanded");
            }

            if (Path.Length == 0)
            {
                jQuery.Select(WorksContentSelector)
                    .Load(WorkContentUrl);
            }
            else
            {
                string url = string.Format(WorksUrlFormat, WorkGroupName);
                jQuery.Get(url, LoadWorks);
                jQuery.Select("#workGroups li a").RemoveClass("current");
                jQuery.Select("#workGroups li a[rel='address:/works/" + Path[0] + "']").AddClass("current");
            }
        }

        private void LoadWorks(object worksData)
        {
            Dictionary workGroup = (Dictionary)worksData;
            _workGroupId = (int)workGroup["Id"];
            Array works = (Array)workGroup["works"];
            if (works == null || works.Length == 0)
            {
                jQuery.Select(WorksContentSelector).After(jQuery.Select("#addLink").Hide(0)).Empty();
                ShowAdminLink();
                return;
            }

            _works = works;

            _currentPage = 0;
            if(!Browser.IsFirefox && ! Browser.IsIpad && !Browser.IsIphone)
            {
                jQuery.Window.Resize(WindowResized);
            }

            RenderWorks(_works);

            RenderPager();
        }

        private void RenderWorks(Array works)
        {
            _pageWidth = jQuery.Select(WorksContentSelector).GetWidth();
            UpdatePageSize();
            UpdatePageCount(works);

            Array page = GetCurrentPage(works);
            string layout = JsRender.Select(WorkItemTemplateSelector).Render(page);

            jQuery.Select("#worksContent").After(jQuery.Select("#addLink").Hide(0)).Empty().Html(layout);
            if (!Browser.IsFirefox)
            {
                jQuery.Select(".workItem *").Each(delegate(int index, Element element)
                                                  {
                                                      Window.SetTimeout(delegate
                                                                        {
                                                                            jQuery.FromElement(element).FadeIn(
                                                                                TransitionDuration/10*index);
                                                                        }, 100);
                                                  });
            }
            else
            {
                jQuery.Select(".workItem *").Show(0);
            }
            ShowAdminLink();

            BindWorkEvents();
        }

        private void ShowAdminLink()
        {
            jQuery.Select("#addLink").AppendTo("#worksContent").Show(0);
            jQuery.Select("#addLink a")
                .Click(delegate
                {
                    Window.Location.Href = string.Format(
                        "/Admin/Works/Create?workGroupId={0}&redirectTo={1}",
                        _workGroupId,
                        Window.Location.Href.EncodeUri());
                });
        }

        private void WindowResized(jQueryEvent e)
        {
            RenderWorks(_works);
            RenderPager();
        }

        private void UpdatePageSize()
        {
            _pageSize = Math.Floor(_pageWidth / WorkItemWidth) * 3;
        }

        private void UpdatePageCount(Array items)
        {
            _pageCount = Math.Floor(items.Length / _pageSize) + ((items.Length % _pageSize > 0) ? 1 : 0);
        }

        private void RenderPager()
        {
            if (_pageCount > 1)
            {
                Array pages = new Array();
                for (int i = 1; i <= _pageCount; i++)
                {
                    Dictionary item = new Dictionary();
                    item["Text"] = i;
                    item["Value"] = (i - 1).ToString();
                    item["Class"] = (i - 1) == _currentPage ? "pagerItem current" : "pagerItem";
                    pages[i - 1] = item;
                }
                string pagesLayout = JsRender.Select(PagerTemplateSelector).Render(pages);
                jQuery.Select("#worksPager").Html(pagesLayout);
                jQuery.Select("#worksPager a").Click(ChangePage);
            }
            else
            {
                jQuery.Select("#worksPager").Empty();
            }
        }

        private void ChangePage(jQueryEvent e)
        {
            int page = int.Parse((string)e.CurrentTarget.GetAttribute("data-page-index"));
            if (page == _currentPage)
                return;
            _currentPage = page;
            RenderWorks(_works);
            jQuery.Select("#worksPager a").RemoveClass("current");
            jQuery.FromElement(e.CurrentTarget).AddClass("current");
            ContentScroller.GoToTop();
        }



        private Array GetCurrentPage(Array items)
        {
            int startIndex = _pageSize * _currentPage;
            Array result = items.Extract(startIndex, _pageSize);
            if (result.Length == 0 && _currentPage > 0)
            {
                _currentPage--;
                result = GetCurrentPage(items);
            }
            return result;
        }

        private void BindWorkEvents()
        {
            Element currentOver = null;

            jQuery.Select(".workItem")
                .MouseOver(delegate(jQueryEvent @event)
                               {
                                   currentOver = @event.CurrentTarget;
                                   jQuery.FromElement(@event.CurrentTarget).FadeTo(TransitionDuration / 2, 0.7);
                                   @event.StopPropagation();
                               })
                .Click(delegate(jQueryEvent @event)
                           {
                               string name = jQuery.FromElement(@event.CurrentTarget).GetAttribute("data-name");
                               Window.Location.Href = "/#!/works/" + WorkGroupName + "/" + name;
                           });

            jQuery.Select(".workItem").Parent()
                .MouseOver(delegate { jQuery.FromElement(currentOver).FadeTo(TransitionDuration / 2, 1); });

            jQuery.Select(".workItem").MouseOut(delegate(jQueryEvent @event) { @event.StopPropagation(); });

            jQuery.Select("#addLink a")
                .Click(delegate
                       {
                           Window.Location.Href = string.Format(
                               "/Admin/Works/Create?workGroupId={0}&redirectTo={1}",
                               _workGroupId,
                               Window.Location.Href.EncodeUri());
                       });
        }

        protected override void PathSet()
        {
            LoadContent();
        }
    }
}
