namespace Superi.Locations
{
    public class Countries
    {
        public static CountryList Get()
        {
            return new CountryList(true);
        }

        public static bool Update(string Name, string IsoCode2, string IsoCode3, int ID)
        {
            Country item = new Country(ID);
            item.Name = Name;
            item.IsoCode2 = IsoCode2;
            item.IsoCode3 = IsoCode3;
            return item.Save();
        }

        public static bool Delete(int ID)
        {
            Country item = new Country(ID);
            return item.Remove();
        }

        public static bool Insert(string Name, string IsoCode2, string IsoCode3)
        {
            Country item = new Country();
            item.Name = Name;
            item.IsoCode2 = IsoCode2;
            item.IsoCode3 = IsoCode3;
            return item.Save();
        }

    }
}