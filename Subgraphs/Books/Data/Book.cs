namespace Demo.Books.Data;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(128)]
    public required string Title { get; set; }
    
    public int AuthorId { get; set; }
}