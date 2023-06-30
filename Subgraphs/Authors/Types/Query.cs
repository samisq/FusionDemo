﻿namespace Demo.Authors.Types;

[QueryType]
public static class Query
{
    public static async Task<Author?> GetAuthorById(
        int id,
        AuthorsByIdDataLoader userById,
        CancellationToken cancellationToken)
        => await userById.LoadAsync(id, cancellationToken);

    public static async Task<IReadOnlyList<Author>?> GetAuthorsById(
        int[] ids,
        AuthorsByIdDataLoader userById,
        CancellationToken cancellationToken)
        => await userById.LoadAsync(ids, cancellationToken);

    public static IQueryable<Author>? GetAuthors(AuthorContext context)
        => context.Authors.OrderBy(t => t.Name);

    public static Book GetBooksByAuthorId(int authorId) => new() {AuthorId = authorId};

    public static IReadOnlyList<Book>? GetBooksByAuthorIds(int[] authorIds)
        => authorIds.Select(authorId => new Book {AuthorId = authorId}).ToList();
}