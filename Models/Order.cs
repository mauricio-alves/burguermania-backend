using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class Order
{
    [Key]
    public int Id { get; set; }
    public float Value { get; set; }
    public string? Observation { get; set; }

    // Relacionamentos
    [ForeignKey("Status")]
    public required int StatusId { get; set; }
    public Status? Status { get; set; }
    [JsonIgnore]
    public ICollection<ProductOrder>? ProductOrders { get; set; }
    [JsonIgnore]
    public ICollection<UserOrder>? UserOrders { get; set; }
}