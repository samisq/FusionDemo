namespace Demo.Books.Types;

public record Author
{
    public int Id { get; set; }
}

[ExtendObjectType<Author>]
internal static class AuthorNode
{
    public static async Task<IEnumerable<Book>> GetBooksAsync(
        [Parent] Author author,
        IBooksByAuthorIdDataLoader loader,
        CancellationToken cancellationToken)
        => await loader.LoadAsync(author.Id, cancellationToken) ?? [];
}