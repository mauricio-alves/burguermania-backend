using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;
public class Product
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string BaseDescription { get; set; }
    public required string FullDescription { get; set; }
    public required string PathImage { get; set; }
    public decimal Price { get; set; }

    // Relacionamentos
    [ForeignKey("Category")]
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<ProductOrder>? ProductOrders { get; set; }
}