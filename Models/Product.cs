using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Base_description { get; set; }
    public string? Full_description { get; set; }
    public string? Path_image { get; set; }
    public string? Price { get; set; }

    // Relacionamento 
    [ForeignKey("Id"), JsonIgnore]
    public Category? Category { get; set; }
}