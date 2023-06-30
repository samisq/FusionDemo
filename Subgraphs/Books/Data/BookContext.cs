namespace Demo.Books.Data;

public class BookContext
{
    private static readonly List<Book> BookData = new()
    {
        new Book
        {
            Id = 1,
            Title = "The Hitchhiker's Guide to the Galaxy",
            AuthorId = 1,
        },
        new Book
        {
            Id = 2,
            Title = "The Restaurant at the End of the Universe",
            AuthorId = 1,
        },
        new Book
        {
            Id = 3,
            Title = "Life, the Universe and Everything",
            AuthorId = 1,
        },
        new Book
        {
            Id = 4,
            Title = "So Long, and Thanks for All the Fish",
            AuthorId = 2
        },
        new Book
        {
            Id = 5,
            Title = "Mostly Harmless",
            AuthorId = 2
        }
    };
    
    public IQueryable<Book> Books => BookData.AsQueryable();
}
