namespace MotoAPI.Entitites;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int MotoId { get; set; }
    public virtual Moto Moto { get; set; }
    
}