namespace Demo.Books.Types;

[QueryType]
public static class Query
{
    public static async Task<Book?> GetBookById(
        int id,
        IBookByIdDataLoader loader,
        CancellationToken cancellationToken)
        => await loader.LoadAsync(id, cancellationToken);

    public static async Task<IReadOnlyList<Book>> GetBooksById(
        int[] ids,
        IBookByIdDataLoader loader,
        CancellationToken cancellationToken)
        => (await loader.LoadAsync(ids, cancellationToken)).Select(x => x!).ToList();

    public static IQueryable<Book> GetBooks(BookContext context)
        => context.Books.OrderBy(t => t.Id);

    public static async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(
        int authorId,
        IBooksByAuthorIdDataLoader loader,
        CancellationToken cancellationToken)
        => await loader.LoadAsync(authorId, cancellationToken) ?? [];

    public static Author GetBookAuthor(int authorId)
        => new Author { Id = authorId };

    public static IReadOnlyList<Author> GetBookAuthors(int[] authorIds)
        => authorIds.Select(authorId => new Author {Id = authorId}).ToList();
} 