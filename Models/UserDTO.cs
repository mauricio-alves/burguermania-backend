namespace WebAPI.Models;
// DTO para retornar os dados do usuário sem a senha
public class UserDTO 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public ICollection<UserOrder>? UserOrders { get; set; }
}