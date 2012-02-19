using System.Html;
using jQueryApi;
using System;
using System.Runtime.CompilerServices;
using jQueryApi.JsRender;
namespace MBrand.Client.Pages
{
    public class WorksPage : Page
    {
        private const string WorkContentUrl = "/Content/Get/worksIntro";
        private const string WorksUrlFormat = "/Works/Items/{0}";
        private const int WorkItemWidth = 290;

        private int _pageWidth;
        private int _currentPage;
        private int _pageSize;
        private int _pageCount;
        
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
        }

        private void LoadContent()
        {
            if (Path.Length == 0)
            {
                jQuery.Select("#worksContent")
                    .Load(WorkContentUrl);
            }
            else
            {
                string url = string.Format(WorksUrlFormat, WorkGroupName);
                jQuery.Get(url, LoadWorks);
            }
        }

        private void LoadWorks(object worksData)
        {
            Array works = (Array)worksData;
            if (works == null || works.Length == 0)
            {
                jQuery.Select("#worksContent").Empty();
                return;
            }

            _works = works;

            _currentPage = 0;
            jQuery.Window.Resize(WindowResized);

            RenderWorks(_works);
        }

        private void RenderWorks(Array works)
        {
            _pageWidth = jQuery.Select("#worksContent").GetWidth();
            UpdatePageSize();
            UpdatePageCount(works);

            Array page = GetCurrentPage(works);
            string layout = JsRender.Select("#workItemTemplate").Render(page);
            jQuery.Select("#worksContent").Empty().Html(layout);

            jQuery.Select(".workItem *").Each(delegate(int index, Element element)
            {
                Window.SetTimeout(delegate
                {
                    jQuery.FromElement(element).FadeIn(
                        TransitionDuration / 10 * index);
                }, 100);
            });

            BindWorkEvents();
        }

        private void WindowResized(jQueryEvent e)
        {
            RenderWorks(_works);
        }

        private void UpdatePageSize()
        {
            _pageSize = Math.Floor(_pageWidth / WorkItemWidth) * 3;
        }

        private void UpdatePageCount(Array items)
        {
            _pageCount = Math.Floor(items.Length/_pageSize) + ((items.Length%_pageSize > 0) ? 1 : 0);
        }

        private Array GetCurrentPage(Array items)
        {
            int startIndex = _pageSize*_currentPage;
            return items.Extract(startIndex, _pageSize);
        }

        private void BindWorkEvents()
        {
            Element currentOver = null;

            jQuery.Select(".workItem")
                .MouseOver(delegate(jQueryEvent @event)
                               {
                                   currentOver = @event.CurrentTarget;
                                   jQuery.FromElement(@event.CurrentTarget).FadeTo(TransitionDuration / 2, 1);
                                   @event.StopPropagation();
                               })
                .Click(delegate(jQueryEvent @event)
                           {
                               string name = jQuery.FromElement(@event.CurrentTarget).GetAttribute("data-name");
                               Window.Location.Href = "/#/works/" + WorkGroupName + "/" + name;
                           });

            jQuery.Select(".workItem").Parent()
                .MouseOver(delegate { jQuery.FromElement(currentOver).FadeTo(TransitionDuration / 2, 0.7); });

            jQuery.Select(".workItem").MouseOut(delegate(jQueryEvent @event) { @event.StopPropagation(); });
        }

        protected override void PathSet()
        {
            LoadContent();
        }
    }
}
