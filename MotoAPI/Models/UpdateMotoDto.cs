using System.ComponentModel.DataAnnotations;

namespace MotoAPI.Models;

public class UpdateMotoDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }
    public string Description { get; set; }
    public bool HasDelivery { get; set; }
}