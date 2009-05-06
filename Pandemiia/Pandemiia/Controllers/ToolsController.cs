using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using System.Web.UI;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Pandemiia.Models;

namespace Pandemiia.Controllers
{
    public class ToolsController : Controller
    {
        //
        // GET: /Tools/

        public ActionResult Index(string caller, string returnAction)
        {
            return RedirectToAction(returnAction, caller);
        }

        public ActionResult CloseWindow()
        {
            return View();
        }

        public ActionResult UploadFiles(string caller, string returnAction, string uploadFolder)
        {
            foreach (string file in Request.Files)
            { 
                
            }
            return RedirectToAction(returnAction, caller);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadFilePairs(int entityId, string caller, string returnAction, string uploadFolder, string fileKey, string previewKey)
        {
            List<Pair> filePairs = new List<Pair>();
            foreach (string file in Request.Files)
            {
                if (file.IndexOf(fileKey) > -1 &&  !string.IsNullOrEmpty(Request.Files[file].FileName))
                {
                    foreach (string preview in Request.Files)
                    {
                        if (preview.IndexOf(previewKey) > -1 && !string.IsNullOrEmpty(Request.Files[preview].FileName))
                        {
                            if (file.Replace(fileKey, "") == preview.Replace(previewKey, ""))
                            {
                                HttpPostedFileBase postedFile = Request.Files[file];
                                string fileName = Path.GetFileName(postedFile.FileName);
                                string fileNameSaved = Utils.GetUniqueFileName(uploadFolder, fileName, fileName);
                                postedFile.SaveAs(Utils.ServerPath(uploadFolder) + fileNameSaved);
                                HttpPostedFileBase postedPreview = Request.Files[preview];
                                string previewName = Path.GetFileName(postedPreview.FileName);
                                string previewNameSaved = Utils.GetUniqueFileName(uploadFolder, previewName, previewName);
                                postedPreview.SaveAs(Utils.ServerPath(uploadFolder) + previewNameSaved);
                                Pair filePair = new Pair();
                                filePair.First = fileNameSaved;
                                filePair.Second = previewNameSaved;
                                filePairs.Add(filePair);
                                break;
                            }
                        }
                    }
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return RedirectToAction(returnAction, caller, new { data = serializer.Serialize(filePairs), entityId = entityId });
        }

        

    }
}
