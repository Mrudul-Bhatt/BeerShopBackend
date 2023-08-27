using BeerShop.Core.Domain.Entities;
using BeerShop.Core.DTO;

namespace BeerShop.Core.ServiceContracts;

public interface IBeerService
{
    Task<List<BeerDto>?> GetBeers(int page, int perPage, string name);
    bool AddToFavourite(Beer beer);
    bool RemoveFromFavourites(int id);
    List<Beer>? GetFavoriteBeers();
}