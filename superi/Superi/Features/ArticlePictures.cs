namespace Superi.Features
{
    public static class ArticlePictures
    {
        public static ArticlePictureList Get()
        {
            return new ArticlePictureList(true);
        }

        public static ArticlePictureList Get(int ArticleId)
        {
            return new ArticlePictureList(ArticleId);
        }

        //public static bool Update(string Alias, int ID)
        //{
        //    Article item = new Article(ID);
        //    item.Alias = Alias;
        //    return item.Save();
        //}

        //public static bool Update(string Title, string Alias, int ID)
        //{
        //    Article item = new Article(ID);
        //    item.Title = Title;
        //    item.Alias = Alias;
        //    return item.Save();
        //}

        //public static bool Delete(int ID)
        //{
        //    Article item = new Article(ID);
        //    return item.Remove();
        //}

        //public static bool Insert(string Alias, string Title, int ScopeID)
        //{
        //    Article item = new Article();
        //    item.Alias = Alias;
        //    item.Title = Title;
        //    item.ScopeID = ScopeID;
        //    return item.Save();
        //}
    }
}
