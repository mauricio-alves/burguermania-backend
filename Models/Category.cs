using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PathImage { get; set; }

    // Relacionamento
    public ICollection<Product>? Products { get; set; }
}