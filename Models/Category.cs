using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Path_image { get; set; }
}