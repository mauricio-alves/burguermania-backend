using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;
public class ProductOrder
{
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }
    
    // Relacionamentos
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}