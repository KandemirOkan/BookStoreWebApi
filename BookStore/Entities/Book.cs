using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApi.Entities
{
public class Book
{  
    // AutoIncrement Id eklenmesini sağlayan Attribute
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Title { get; set; }   
    public int PageCount { get; set; }
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; }   
    public int AuthorId { get; set; }
    public Genre Author { get; set; }    
}
}