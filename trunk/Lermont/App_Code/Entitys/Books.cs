public static class Books
{
    public static BookList Get()
    {
        return new BookList(true);
    }

    public static BookList Get(int GroupId)
    {
        return new BookList(GroupId);
    }
}