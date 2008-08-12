namespace Superi.Locations
{
    public class Regions
    {
        public static RegionList Get(int CountryID)
        {
            return new RegionList(CountryID);
        }

        public static bool Update(string Name, int CountryID, string IsoCode3, int ID)
        {
            Region item = new Region(ID);
            item.Name = Name;
            item.CountryID = CountryID;
            return item.Save();
        }

        public static bool Delete(int ID)
        {
            Region item = new Region(ID);
            return item.Remove();
        }

        public static bool Insert(string Name, int CountryID)
        {
            Region item = new Region();
            item.Name = Name;
            item.CountryID = CountryID;
            return item.Save();
        }
    }
}
