namespace Demo.Authors.Data;

public class AuthorContext
{
    private readonly List<Author> _authors = new()
    {
        new()
        {
            Id = 1,
            Name = "Douglas Adams"
        },
        new()
        {
            Id = 2,
            Name = "J. R. R. Tolkien"
        }
    };
    
    public IQueryable<Author> Authors => _authors.AsQueryable();
}
