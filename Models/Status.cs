using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Status
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}