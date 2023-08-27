namespace BeerShop.Core.Domain.Entities;

public class Beer
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public string? image_url { get; set; }
}