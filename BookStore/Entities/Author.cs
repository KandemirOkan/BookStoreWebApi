using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApi.Entities
{
public class Author
{  
    // AutoIncrement Id eklenmesini sağlayan Attribute
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? FirstName { get; set; }   
    public string? LastName { get; set; }   
    public DateTime BirthDate { get; set; }
}
}