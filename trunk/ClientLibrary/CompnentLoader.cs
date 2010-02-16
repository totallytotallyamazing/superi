using System;
using Sys;
using Sys.UI;
using System.DHTML;

namespace ClientLibrary
{
    public class ComponentLoader : Component
    {

        public ComponentLoader()
        {

        }

        public override void Initialize()
        {
            Window.SetTimeout(PageLoaded, 1000);
        }

        void PageLoaded()
        {
            Component[] components = Application.GetComponents();
            int length = components.Length;
            for (int i = 0; i < length; i++)
            {
                if (components[i] is ILoadableComponent)
                {
                    ((ILoadableComponent)components[i]).OnLoad();
                }
            }
        }
    }
}
