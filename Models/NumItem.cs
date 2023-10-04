using System.ComponentModel.DataAnnotations;

namespace NumberAPI.Models;

public class NumItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int NumberItem { get; set; }
}