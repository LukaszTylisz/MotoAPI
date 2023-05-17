using System.ComponentModel.DataAnnotations;

namespace MotoAPI.Models;

public class CreateCarDto
{
    [Required]
    public string Model { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    public int MotoId { get; set; }
}