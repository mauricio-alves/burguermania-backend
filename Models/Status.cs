using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Status
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }

    // Relacionamento
    public ICollection<Order>? Orders { get; set; }
}