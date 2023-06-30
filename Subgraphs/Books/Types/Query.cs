﻿using Demo.Books.Data;

namespace Demo.Books.Types;

[QueryType]
public static class Query
{
    public static async Task<Book?> GetBookById(
        int id,
        BookByIdDataLoader reviewById,
        CancellationToken cancellationToken)
        => await reviewById.LoadAsync(id, cancellationToken);
    
    public static async Task<IReadOnlyList<Book>?> GetBooksById(
        int[] ids,
        BookByIdDataLoader loader,
        CancellationToken cancellationToken)
        => await loader.LoadAsync(ids, cancellationToken);

    public static IQueryable<Book> GetBooks(BookContext context)
        => context.Books.OrderBy(t => t.Id);

    public static async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(
        int authorId,
        BooksByAuthorIdDataLoader loader,
        CancellationToken cancellationToken)
        => await loader.LoadAsync(authorId, cancellationToken);

    public static Author GetBookAuthor(int authorId)
        => new Author { Id = authorId };

    public static IReadOnlyList<Author>? GetBookAuthors(int[] authorIds)
        => authorIds.Select(authorId => new Author {Id = authorId}).ToList();
} 