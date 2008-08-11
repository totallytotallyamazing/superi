namespace Superi.Features
{
    public class Events
    {
        public static EventTypeList Get()
        {
            return new EventTypeList(true);
        }

        public static bool Update(string Name, int ID)
        {
            EventType item = new EventType(ID);
            item.Name = Name;
            return item.Save();
        }

        public static bool Delete(int ID)
        {
            EventType item = new EventType(ID);
            return item.Remove();
        }

        public static bool Insert(string Name)
        {
            EventType item = new EventType();
            item.Name = Name;
            return item.Save();
        }
    }
}
