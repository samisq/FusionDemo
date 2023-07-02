namespace Demo.Books.Types;

[ExtendObjectType<Book>(IgnoreProperties = new[] { nameof(Book.AuthorId) })]
internal static class BookNode
{
    public static Author GetAuthor([Parent] Book book) => new() { Id = book.AuthorId };

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Book>> GetBookByIdAsync(
        IReadOnlyList<int> ids,
        BookContext context)
    {
        var result = context.Books
            .Where(t => ids.Contains(t.Id))
            .ToDictionary(t => t.Id);
        await Task.CompletedTask;
        return result;
    }

    [DataLoader]
    internal static Task<ILookup<int, Book>> GetBooksByAuthorIdAsync(
        IReadOnlyList<int> ids,
        BookContext context)
    {
        var books = context.Books
            .Where(t => ids.Contains(t.AuthorId))
            .ToList();

        return Task.FromResult(books.ToLookup(t => t.AuthorId));
    }
}