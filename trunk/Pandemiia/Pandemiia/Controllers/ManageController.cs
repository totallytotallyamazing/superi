using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pandemiia.Models;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Routing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;

namespace Pandemiia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageController : Controller
    {
        EntitiesDataContext _context = new EntitiesDataContext();

        public ActionResult Index()
        {
            return View();
        }
        #region Entities
        public ActionResult Entities()
        {
            return View(_context.Entities.Select(ent => ent).OrderByDescending(ent => ent.Date).ToList());
        }

        public ActionResult CreateEntity()
        {
            ViewData["EntitySources"] = _context.EntitySources.Select(es => es);
            ViewData["EntityTypes"] = _context.EntityTypes.Select(es => es);
            List<Tag> tagList = _context.Tags.Select(t => t).ToList();
            ViewData["tagList"] = tagList;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditEntity(FormCollection frm)
        {
            Entity entity = _context.Entities.SingleOrDefault(en => en.ID == int.Parse(frm["ID"]));
            entity.Content = Server.HtmlDecode(frm["Content"]);
            entity.Description = Server.HtmlDecode(frm["Description"]);
            entity.Title = frm["Title"];
            entity.Date = DateTime.Parse(frm["Date"]);
            entity.SourceID = int.Parse(frm["SourceID"]);
            entity.TypeID = int.Parse(frm["TypeID"]);
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files["image"].FileName))
            {
                RemovePicture(entity.Image);
                HttpPostedFileBase postedFile = Request.Files["image"];
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileNameSaved = Utils.GetUniqueFileName("EntityImages", fileName, fileName);
                entity.Image = fileName;
                postedFile.SaveAs(Utils.ServerPath("EntityImages") + fileName);
            }
            _context.EntityTagMappings.DeleteAllOnSubmit(entity.EntityTagMappings);
            _context.SubmitChanges();
            AddTags(frm["tags"], entity.ID);
            return RedirectToAction("Entities");
        }

        private void AddTags(string tags, int entityId)
        {
            //adding completely new tags
            string[] tagArray = tags.Split((' '));
            List<Tag> allTagList = _context.Tags.Select(t => t).ToList();
            string[] allTagArray = allTagList.Select(t => t.TagName).ToArray();
            string[] newTags = tagArray.Select(t => t).Where(t => (!allTagArray.Contains(t))).ToArray();
            int[] newTagIds = new int[newTags.Length];
            for (int i = 0; i < newTags.Length; i++)
            {
                string tagName = newTags[i];
                Tag tag = new Tag();
                tag.TagName = tagName;
                _context.Tags.InsertOnSubmit(tag);
            }
            _context.SubmitChanges();

            //determining which tag mappings are new

            var mappings = _context.EntityTagMappings.Select(etm => etm).Where(etm => etm.EntityID == entityId);
            int mappingsCount = mappings.Count();
            foreach (string tag in tagArray)
            {
                bool hasMapping = false;
                if (mappingsCount > 0)
                    foreach (EntityTagMapping mapping in mappings)
                    {
                        if (tag == mapping.Tag.TagName)
                            hasMapping = true;
                    }
                if (!hasMapping)
                {
                    Tag tagToMap = _context.Tags.SingleOrDefault(t => t.TagName == tag);
                    EntityTagMapping newMapping = new EntityTagMapping { EntityID = entityId, TagID = tagToMap.ID };
                    _context.EntityTagMappings.InsertOnSubmit(newMapping);
                }
            }
            _context.SubmitChanges();
        }

        public ActionResult DeleteEntity(int Id)
        {
            Entity entity = _context.Entities.SingleOrDefault(en => en.ID == Id);
            RemovePicture(entity.Image);
            _context.Entities.DeleteOnSubmit(entity);
            _context.SubmitChanges();
            return RedirectToAction("Entities");
        }

        public ActionResult EditEntity(int Id)
        {
            List<EntitySource> entitySources = _context.EntitySources.Select(es => es).ToList();
            List<EntityType> entityTypes = _context.EntityTypes.Select(es => es).ToList();
            string[] allTags = _context.Tags.Select(t => t.TagName).ToArray<string>();
            List<SelectListItem> sliSources = new List<SelectListItem>();
            List<SelectListItem> sliTypes = new List<SelectListItem>();
            Entity entity = _context.Entities.SingleOrDefault(e => e.ID == Id);
            foreach (EntitySource source in entitySources)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = source.Name;
                sli.Value = source.ID.ToString();
                sli.Selected = (source.ID == entity.SourceID);
                sliSources.Add(sli);
            }

            foreach (EntityType type in entityTypes)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = type.Name;
                sli.Value = type.ID.ToString();
                sli.Selected = (type.ID == entity.TypeID);
                sliTypes.Add(sli);
            }
            List<Tag> tagList = _context.Tags.Select(t => t).ToList();
            ViewData["tagList"] = tagList;
            ViewData["EntitySources"] = sliSources;
            ViewData["EntytyTypes"] = sliTypes;
            return View(entity);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateEntity(FormCollection frm)
        {
            Entity entity = new Entity();
            entity.Content = Server.HtmlDecode(frm["Content"]);
            entity.Description = Server.HtmlDecode(frm["Description"]);
            entity.Title = frm["Title"];
            CultureInfo info = CultureInfo.GetCultureInfo("en-US");
            entity.Date = DateTime.Parse(frm["Date"], info);
            entity.SourceID = int.Parse(frm["SourceID"]);
            entity.TypeID = int.Parse(frm["TypeID"]);
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files["image"].FileName))
            {
                HttpPostedFileBase postedFile = Request.Files["image"];
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileNameSaved = Utils.GetUniqueFileName("EntityImages", fileName, fileName);
                entity.Image = fileName;
                postedFile.SaveAs(Utils.ServerPath("EntityImages") + fileName);
            }
            _context.Entities.InsertOnSubmit(entity);
            _context.SubmitChanges();
            AddTags(frm["tags"], entity.ID);
            return RedirectToAction("Entities");
        }
        #endregion

        #region Music
        public ActionResult Music(int id)
        {
            Entity entity = _context.Entities.SingleOrDefault(e => e.ID == id);
            return View(entity);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddMusic(FormCollection form)
        {
            foreach (string file in Request.Files)
            {
                int entityId = int.Parse(form["id"]);
                HttpPostedFileBase postedFile = Request.Files[file];
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileNameSaved = Utils.GetUniqueFileName("EntityMusic", fileName, fileName);
                postedFile.SaveAs(Utils.ServerPath("EntityMusic") + fileNameSaved);
                EntityMusic music = new EntityMusic();
                music.EntityID = entityId;
                music.FileName = fileNameSaved;
                music.Album = form["album"];
                music.Artist = form["artist"];
                music.Name = form["name"];
                music.Comments = form["comments"];
                _context.EntityMusics.InsertOnSubmit(music);
            }
            _context.SubmitChanges();
            return RedirectToAction("Music", new RouteValueDictionary(new { id = form["id"] }));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RemoveMusic(FormCollection form)
        {
            foreach (string key in form.Keys)
            {
                if (key != "id" && form[key].IndexOf("true") > -1)
                {
                    int musicId = int.Parse(key);
                    EntityMusic music = _context.EntityMusics.SingleOrDefault(m => m.ID == musicId);
                    RemoveMusic(music.FileName);
                    _context.EntityMusics.DeleteOnSubmit(music);
                }
            }
            _context.SubmitChanges();
            return RedirectToAction("Music", new RouteValueDictionary(new { id = form["id"] }));
        }
        #endregion

        #region Videos
        public ActionResult Videos(int id)
        {
            Entity entity = _context.Entities.SingleOrDefault(e => e.ID == id);
            return View(entity);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddVideo(FormCollection form)
        {
            EntityVideo video = new EntityVideo();
            video.EntityID = int.Parse(form["id"]);
            video.Name = form["name"];
            video.Source = Server.UrlDecode(form["source"]);
            _context.EntityVideos.InsertOnSubmit(video);
            _context.SubmitChanges();
            return RedirectToAction("Videos", new RouteValueDictionary(new { id = form["id"] }));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RemoveVideos(FormCollection form)
        {
            foreach (string key in form.Keys)
            {
                if (key != "id" && form[key].IndexOf("true") > -1)
                {
                    int videoId = int.Parse(key);
                    EntityVideo video = _context.EntityVideos.SingleOrDefault(v => v.ID == videoId);
                    _context.EntityVideos.DeleteOnSubmit(video);
                }
            }
            _context.SubmitChanges();
            return RedirectToAction("Videos", new RouteValueDictionary(new { id = form["id"] }));
        }
        #endregion

        #region Images
        public ActionResult Images(int id)
        {
            Entity entity = _context.Entities.SingleOrDefault(e => e.ID == id);
            return View(entity);
        }

        public ActionResult SaveImages(string data, int entityId)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Pair> filePairs = serializer.Deserialize<List<Pair>>(data);
            foreach (Pair filePair in filePairs)
            {
                EntityPicture picture = new EntityPicture();
                picture.Picture = filePair.First.ToString();
                picture.Preview = filePair.Second.ToString();
                picture.EntityID = entityId;
                _context.EntityPictures.InsertOnSubmit(picture);
            }
            _context.SubmitChanges();
            return RedirectToAction("CloseWindow", "Tools");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RemoveImages(FormCollection form)
        {
            foreach (string key in form.Keys)
            {
                if (key != "id" && form[key].IndexOf("true") > -1)
                {
                    int imageId = int.Parse(key);
                    EntityPicture picture = _context.EntityPictures.SingleOrDefault(p => p.ID == imageId);
                    RemovePicture(picture.Picture);
                    RemovePicture(picture.Preview);
                    _context.EntityPictures.DeleteOnSubmit(picture);
                }
            }
            _context.SubmitChanges();
            return RedirectToAction("Images", new RouteValueDictionary(new { id = form["id"] }));
        }
        #endregion

        #region Tags
        public ActionResult Tags()
        {
            List<Tag> tags = _context.Tags.Select(t => t).ToList();
            return View(tags);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveTag(FormCollection form)
        {
            int id = int.Parse(form["id"]);
            string tagName = form["tagName"];
            Tag tag = _context.Tags.Select(t => t).Where(t => t.ID == id).First();
            tag.TagName = tagName;
            _context.SubmitChanges();
            return RedirectToAction("Tags");
        }

        public ActionResult DeleteTag(int id)
        {
            Tag tag = _context.Tags.Select(t => t).Where(t => t.ID == id).First();
            _context.EntityTagMappings.DeleteAllOnSubmit(tag.EntityTagMappings);
            _context.Tags.DeleteOnSubmit(tag);
            _context.SubmitChanges();
            return RedirectToAction("Tags");
        }
        #endregion

        #region Tools
        public ActionResult BrokenYoutube()
        {
            List<EntityVideo> videos = _context.EntityVideos.Select(v => v).ToList();
            List<EntityVideo> result = videos.Select(v => v).Where(v => !CheckVideo(v.Source)).ToList();
            return View(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateVideoSource(FormCollection form)
        {
            int id = int.Parse(form["id"]);
            string newSource = form["source"];
            EntityVideo video = _context.EntityVideos.Select(v => v).Where(v => v.ID == id).First();
            video.Source = newSource;
            _context.SubmitChanges();
            return RedirectToAction("BrokenYoutube");
        }
        #endregion

        #region Private methods
        private void RemoveFile(string folder, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string picturePath = AppDomain.CurrentDomain.BaseDirectory + folder + Path.DirectorySeparatorChar + fileName;
                System.IO.File.Delete(picturePath);
            }
        }

        private void RemovePicture(string fileName)
        {
            RemoveFile("EntityImages", fileName);
        }

        private void RemoveMusic(string fileName)
        {
            RemoveFile("EntityMusic", fileName);
        }

        private bool CheckVideo(string objectTag)
        {
            bool result = true;
            Regex regex = new Regex("/v/([^\\&^\"]+?)\\&hl");
            Match match = regex.Match(objectTag);
            if (match.Success)
            {
                string videoId = match.Groups[1].Value;
                result = QueryYoutube(videoId);
            }
            return result;
        }

        private bool QueryYoutube(string videoId)
        {
            bool result = true;
            Uri uri = new Uri("http://gdata.youtube.com/feeds/api/videos/" + videoId);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            string responseString = "<?xml version='1.0'";
            webRequest.Method = "GET";
            StreamReader reader = null;
            WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            catch(Exception exception) {
                if (exception.Message.IndexOf("404") > -1)
                    responseString = "";
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
                if (response != null)
                    response.Close();
                response = null;
            }
            result = (responseString.IndexOf("<?xml version='1.0'") > -1);
            return result;
        }
        #endregion
    }
}
