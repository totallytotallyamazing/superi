using jQueryApi;
namespace MBrand.Client.Pages
{
    public class WorksPage :Page
    {
        private const string WorkContentUrl = "/Content/Get/worksIntro";
        private const string WorksUrlFormat = "/Works/Items/{0}?page={1}";

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
                jQuery.Select("#worksContent").Load(WorkContentUrl);
            }
            else
            {
                string url = string.Format(WorksUrlFormat, WorkGroupName, Page);
                jQuery.Select("#worksContent").Load(url);
            }
        }

        protected override void PathSet()
        {
            LoadContent();
        }
    }
}
