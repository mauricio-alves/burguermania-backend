using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class User
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    // Relacionamento
    public ICollection<UserOrder>? UserOrders { get; set; }
}