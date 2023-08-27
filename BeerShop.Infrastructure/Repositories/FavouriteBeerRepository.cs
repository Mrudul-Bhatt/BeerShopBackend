using BeerShop.Core.Domain.Entities;
using BeerShop.Core.Domain.RepositoryContracts;
using Newtonsoft.Json;

namespace BeerShop.Infrastructure.Repositories;

public class FavouriteBeerRepository : IFavouriteBeerRepository
{
    private const string FilePath = "BeerDB.json";

    public List<Beer>? ReadData()
    {
        if (!File.Exists(FilePath)) return new List<Beer>();

        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Beer>>(json);
    }

    public bool RemoveData(int id)
    {
        var existingData = ReadData();
        var beerToRemove = existingData?.Find(beer => beer.id == id);

        if (beerToRemove == null) throw new Exception("No such beer exists");

        existingData?.Remove(beerToRemove);

        var json = JsonConvert.SerializeObject(existingData, Formatting.Indented);
        File.WriteAllText(FilePath, json);
        return true;
    }

    public bool InsertData(Beer beer)
    {
        var existingData = ReadData();
        existingData?.Add(beer);

        var json = JsonConvert.SerializeObject(existingData, Formatting.Indented);
        File.WriteAllText(FilePath, json);
        return true;
    }
}