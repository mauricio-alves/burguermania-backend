using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;
public class Order
{
    [Key]
    public int Id { get; set; }
    public float Value { get; set; }

    // Relacionamentos
    [ForeignKey("Status")]
    public required int StatusId { get; set; }
    public Status? Status { get; set; }
    public  ICollection<ProductOrder>? ProductOrders { get; set; }
    public required ICollection<UserOrder>? UserOrders { get; set; }
}