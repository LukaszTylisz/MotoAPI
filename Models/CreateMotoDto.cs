﻿namespace MotoAPI.Models;

public class CreateMotoDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool HasService { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    
}