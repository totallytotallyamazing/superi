// Class1.cs
//

using System;
using System.DHTML;
using Sys.UI;

namespace Sys.Mvc
{
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
    public class AjaxOptions
    {
        [IntrinsicProperty]
        public string Confirm { get{return null;} set{} }
        [IntrinsicProperty]
        public string Url { get{return null;} set{} }
        [IntrinsicProperty]
        public string HttpMethod { get{return null;} set{} }
        [IntrinsicProperty]
        public string UpdateTargetId { get{return null;} set{} }
        [IntrinsicProperty]
        public string LoadingElementId { get{return null;} set{} }
        [IntrinsicProperty]
        public string OnBegin { get{return null;} set{} }
        [IntrinsicProperty]
        public string OnComplete { get{return null;} set{} }
        [IntrinsicProperty]
        public string OnSuccess { get{return null;} set{} }
        [IntrinsicProperty]
        public string OnFailure { get{return null;} set{} }
    }
    
    [Imported]
    public class AsyncHyperlink
    {
        public static void HandleClick(AnchorElement anchor, DomEvent evt, AjaxOptions ajaxOptions)
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
        public static void HandleSubmit(FormElement form, DomEvent evt, AjaxOptions ajaxOptions)
        {
        
        }
    }
}
