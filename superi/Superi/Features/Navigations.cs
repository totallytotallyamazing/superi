using System.Collections;

namespace Superi.Features
{
	public static class Navigations
	{
	    public static NavigationList Get()
		{
			return new NavigationList(true);
		}

		public static NavigationList Get(bool GetSubItems)
		{
			return new NavigationList(true, GetSubItems);
		}

		public static NavigationList GetAll()
		{
			return new NavigationList(true, true);
		}

		public static NavigationList Get(int ParentID)
		{
			return new NavigationList(ParentID);
		}
		
        public static Navigation GetLatestByPath(string Path)
        {
            char[] sep = {'/'};
            string[] preParts = Path.Split(sep);
            ArrayList parts = new ArrayList();
            foreach (string s in preParts)
            {
                if(!string.IsNullOrEmpty(s))
                    parts.Add(s);
            }
            int parentId = int.MinValue;
            Navigation result = new Navigation();
            foreach (string s in parts)
            {
                Navigation navigation = new Navigation(s, parentId);
                if (navigation.ID>0)
                {
                    result = navigation;
                    parentId = result.ID;
                }
            }
            return result;
        }


	}
}
