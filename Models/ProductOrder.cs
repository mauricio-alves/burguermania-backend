using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class ProductOrder
{
    [Key]
    public int Id { get; set; }
    
    // Relacionamento 
    [ForeignKey("Id"), JsonIgnore]
    public Product? Product { get; set; }

    // Relacionamento 
    [ForeignKey("Id"), JsonIgnore]
    public Order? Order { get; set; }
}