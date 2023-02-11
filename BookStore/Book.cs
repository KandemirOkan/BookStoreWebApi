using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApi
{
public class Book
{  
    // AutoIncrement Id eklenmesini sağlayan Attribute
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }   
    public string? Title { get; set; }   
    public int GenreId { get; set; }   
    public int PageCount { get; set; }   
    public string? Author { get; set; }  
}
}