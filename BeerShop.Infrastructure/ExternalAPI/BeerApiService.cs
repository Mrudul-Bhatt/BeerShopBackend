using BeerShop.Core.Domain.Entities;
using BeerShop.Core.ServiceContracts;
using Newtonsoft.Json;

namespace BeerShop.Infrastructure.ExternalAPI;

public class BeerApiService : IBeerApiService
{
    private readonly HttpClient _httpClient;

    public BeerApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<Beer>?> GetBeers(int page, int perPage, string name)
    {
        var response = await _httpClient
            .GetAsync($"https://api.punkapi.com/v2/beers?page={page}&per_page={perPage}&beer_name={name}");

        if (!response.IsSuccessStatusCode) throw new Exception("Error fetching beer data from the punk API.");
        
        var responseBody = await response.Content.ReadAsStringAsync();

        var beers = JsonConvert.DeserializeObject<List<Beer>>(responseBody);
        return beers;
    }
}