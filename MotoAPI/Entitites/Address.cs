namespace MotoAPI.Entitites;

public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    
    public virtual Moto Moto { get; set; }
}