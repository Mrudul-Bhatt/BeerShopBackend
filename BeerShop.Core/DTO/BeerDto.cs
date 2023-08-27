namespace BeerShop.Core.DTO;

public class BeerDto
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public string? image_url { get; set; }
    public bool is_favourite { get; set; }
}