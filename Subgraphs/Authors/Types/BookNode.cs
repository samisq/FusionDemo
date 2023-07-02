namespace Demo.Authors.Types;

public class Book
{
    public int AuthorId { get; set; }
}

[ExtendObjectType<Book>]
internal static class BookNode
{
    public static async Task<Author> GetAuthorAsync(
        [Parent] Book book,
        IAuthorsByIdDataLoader loader,
        CancellationToken cancellationToken)
        => await loader.LoadAsync(book.AuthorId, cancellationToken);
}