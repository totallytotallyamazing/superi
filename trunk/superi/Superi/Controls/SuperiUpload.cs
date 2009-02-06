using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web;
using System.IO;

namespace Superi.CustomControls
{
    public enum UnificatorPositionMode {Prefix, Postfix}

    public class FolderUpload : FileUpload
    {
        const string DEFAULT_UNIFICATOR = "_";

        #region Fields
        private string folder = "";
        private UnificatorPositionMode unificatorPosition = UnificatorPositionMode.Postfix;
        private string unificator = DEFAULT_UNIFICATOR;
        private bool unificateIncrementally = true;
        #endregion

        #region Properties
        [Category("Behavior")]
        public string Folder
        {
            get 
            {
                if (EnableViewState && ViewState["folder"] != null)
                    folder = ViewState["folder"].ToString();
                return folder; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["folder"] = value;
                folder = value; 
            }
        }

        [Category("Behavior")]
        public UnificatorPositionMode UnificatorPosition
        {
            get 
            {
                if (EnableViewState && ViewState["unificatorPosition"] != null)
                    unificatorPosition = (UnificatorPositionMode)Convert.ToInt32(ViewState["unificatorPosition"]);
                return unificatorPosition; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["unificatorPosition"] = value;
                unificatorPosition = value; 
            }
        }

        [Category("Behavior")]
        public string Unificator
        {
            get 
            {
                if (EnableViewState && ViewState["unificator"] != null)
                    unificator = ViewState["unificator"].ToString();
                return unificator; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["unificator"] = value;
                unificator = value; 
            }
        }

        [Category("Behavior")]
        public bool UnificateIncrementally
        {
            get 
            {
                if (EnableViewState && ViewState["unificateIncrementally"] != null)
                    unificateIncrementally = Convert.ToBoolean(ViewState["unificateIncrementally"]);
                return unificateIncrementally; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["unificator"] = value;
                unificateIncrementally = value; 
            }
        }

        private string ServerPath
        {
            get 
            { 
                return HttpContext.Current.Server.MapPath(Folder); 
            }
        }
        #endregion

        #region Methods

        public string Save()
        {
            string result = GetUniqueFileName(FileName);
            SaveAs(ServerPath + result);
            return result;
        }

        private string GetUniqueFileName(string fileName)
        {
            string result = fileName;
            if (File.Exists(ServerPath + fileName))
            {
                result = GetUniqueFileName(AddUnificator(fileName));
            }
            return result;
        }

        private string AddUnificator(string fileName)
        {
            string result = FileName;
            if (UnificateIncrementally)
            {
                if (UnificatorPosition == UnificatorPositionMode.Prefix)
                {
                    if (FileName == fileName)
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
                    int lastIndexBeforeExtOriginal = FileName.LastIndexOf(".");
                    bool noExtension = false;
                    if (lastIndexBeforeExt == -1)
                    {
                        lastIndexBeforeExt = fileName.Length - 1;
                        noExtension = true;
                    }

                    if (FileName == fileName)
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
                            string file = FileName.Substring(0, FileName.LastIndexOf("."));
                            int length = FileName.Length - lastIndexBeforeExt;
                            currentUnificator = fileName.Substring(file.Length, length);
                            currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                            currentIncrement++;
                            result = FileName.Insert(lastIndexBeforeExtOriginal, Unificator + currentIncrement);
                        }
                    }
                }
            }
            else
            {
                if (UnificatorPosition == UnificatorPositionMode.Prefix)
                {
                    result = Unificator + FileName;
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
