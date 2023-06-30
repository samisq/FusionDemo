namespace Demo.Authors.Types;

[ExtendObjectType<Author>]
internal static class AuthorNode
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Author>> GetAuthorsByIdAsync(
        IReadOnlyList<int> ids,
        AuthorContext context,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return context.Authors
            .Where(t => ids.Contains(t.Id))
            .ToDictionary(t => t.Id);
    }
}