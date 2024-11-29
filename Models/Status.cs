using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class Status
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }

    // Relacionamento
    [JsonIgnore]
    public ICollection<Order>? Orders { get; set; }
}