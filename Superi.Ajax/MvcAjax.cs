// Class1.cs
//

using System;
using System.DHTML;
using Sys.UI;

namespace Sys.Mvc
{
    [Imported]
    public delegate void AsyncRequestHandler(AjaxContext context);

    [Imported]
    public enum InsertionMode
    {
        Replace = 0,
        InsertBefore = 1,
        InsertAfter = 2
    }

    [Imported]
    public class AjaxContext
    {
        public object Data { get { return null; } }
        public InsertionMode InsertionMode { get { return InsertionMode.Replace; } }
        public DOMElement LoadingElement { get { return null; } }
        public object Response { get { return null; } set { } }
        public object Request { get { return null; } }
        public DOMElement UpdateTarget { get { return null; } }
    }

    
    [Imported]
    public class AsyncHyperlink
    {
        public static void HandleClick(AnchorElement anchor, DomEvent evt, object ajaxOptions)
        { 
        
        }
    }

    [Imported]
    public class MvcHelpers
    {
        public static void UpdateDomElement(DOMElement target, InsertionMode insertionMode, string content)
        {
        
        }
    }

    [Imported]
    public class AsyncForm
    {
        public static void HandleSubmit(FormElement form, DomEvent evt, Object ajaxOptions)
        {
        
        }
    }
}
