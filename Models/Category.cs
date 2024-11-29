using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string BaseDescription { get; set; }
    public required string FullDescription { get; set; }
    public required string PathImage { get; set; }

    // Relacionamento
    public ICollection<Product>? Products { get; set; } = new List<Product>();
}