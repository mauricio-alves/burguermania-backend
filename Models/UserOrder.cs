using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class UserOrder
{
    [Key]
    public int Id { get; set; }
    
    // Relacionamentos
    [ForeignKey("User")]
    public required int UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    [JsonIgnore]
    public Order? Order { get; set; }
}