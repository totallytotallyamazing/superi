using System;
using Sys.Mvc;

namespace ClientLibrary
{
    public class AjaxOptions
    {
        public string Confirm;
        public string Url;
        public string HttpMethod;
        public string UpdateTargetId;
        public string LoadingElementId;
        public string OnBegin;
        public AsyncRequestHandler OnComplete;
        public string OnSuccess;
        public string OnFailure;
    }
}
