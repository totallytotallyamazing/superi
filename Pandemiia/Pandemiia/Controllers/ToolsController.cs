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

namespace Pandemiia.Controllers
{
    public enum UnificatorPositionMode { Prefix, Postfix }

    public class ToolsController : Controller
    {
        string initialFileName = "";
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

        //[AcceptVerbs(HttpVerbs.Post)]
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
                                initialFileName = fileName;
                                string fileNameSaved = GetUniqueFileName(uploadFolder, fileName);
                                postedFile.SaveAs(ServerPath(uploadFolder) + fileNameSaved);
                                HttpPostedFileBase postedPreview = Request.Files[preview];
                                string previewName = Path.GetFileName(postedPreview.FileName);
                                initialFileName = previewName;
                                string previewNameSaved = GetUniqueFileName(uploadFolder, previewName);
                                postedPreview.SaveAs(ServerPath(uploadFolder) + previewNameSaved);
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

        #region UploadFiles

        const string DEFAULT_UNIFICATOR = "_";

        private string Unificator = DEFAULT_UNIFICATOR;
        private bool UnificateIncrementally = true;

        private string ServerPath(string uploadFolder)
        {
            return AppDomain.CurrentDomain.BaseDirectory + uploadFolder.Replace("/", Path.DirectorySeparatorChar.ToString()) + Path.DirectorySeparatorChar;
        }

        private UnificatorPositionMode UnificatorPosition = UnificatorPositionMode.Postfix;

        private string GetUniqueFileName(string uploadFolder, string fileName)
        {
            string result = fileName;
            if (System.IO.File.Exists(ServerPath(uploadFolder) + fileName))
            {
                result = GetUniqueFileName(uploadFolder, AddUnificator(fileName));
            }
            return result;
        }

        private string AddUnificator(string fileName)
        {
            string result = initialFileName;
            if (UnificateIncrementally)
            {
                if (UnificatorPosition == UnificatorPositionMode.Prefix)
                {
                    if (initialFileName == fileName)
                    {
                        result = "1" + Unificator + fileName;
                    }
                    else
                    {
                        int fileNameIndex = fileName.IndexOf(fileName);
                        string currentUnificator = fileName.Substring(0, fileNameIndex);
                        int currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                        currentIncrement++;
                        result = currentIncrement + Unificator + fileName;
                    }
                }
                else
                {
                    string currentUnificator;
                    int currentIncrement;
                    int lastIndexBeforeExt = fileName.LastIndexOf(".");
                    int lastIndexBeforeExtOriginal = initialFileName.LastIndexOf(".");
                    bool noExtension = false;
                    if (lastIndexBeforeExt == -1)
                    {
                        lastIndexBeforeExt = fileName.Length - 1;
                        noExtension = true;
                    }

                    if (initialFileName == fileName)
                    {
                        if (noExtension)
                            result = fileName + Unificator + "1";
                        else
                            result = fileName.Insert(lastIndexBeforeExt, Unificator + "1");
                    }
                    else
                    {
                        if (noExtension)
                        {
                            currentUnificator = fileName.Substring(fileName.Length - 1);
                            currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                            currentIncrement++;
                            result = fileName + Unificator + currentIncrement;
                        }
                        else
                        {
                            string file = initialFileName.Substring(0, initialFileName.LastIndexOf("."));
                            int length = initialFileName.Length - lastIndexBeforeExt;
                            currentUnificator = fileName.Substring(file.Length, length);
                            currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                            currentIncrement++;
                            result = initialFileName.Insert(lastIndexBeforeExtOriginal, Unificator + currentIncrement);
                        }
                    }
                }
            }
            else
            {
                if (UnificatorPosition == UnificatorPositionMode.Prefix)
                {
                    result = Unificator + initialFileName;
                }
                else
                {
                    if (fileName.LastIndexOf(".") == -1)
                    {
                        result = fileName + Unificator;
                    }
                    else
                    {
                        result = fileName.Insert(fileName.LastIndexOf("."), Unificator);
                    }
                }
            }
            return result;
        }
        #endregion

    }
}
