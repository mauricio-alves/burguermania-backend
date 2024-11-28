using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;
public class UserOrder
{
    [Key]
    public int Id { get; set; }
    
    // Relacionamentos
    [ForeignKey("User")]
    public required int UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey("Order")]
    public required int OrderId { get; set; }
    public Order? Order { get; set; }
}