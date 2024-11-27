using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class Order
{
    [Key]
    public int Id { get; set; }
    public float? Value { get; set; }

    // Relacionamento 
    [ForeignKey("Id"), JsonIgnore]
    public Status? Status { get; set; }
}