using BeerShop.Core.Domain.Entities;

namespace BeerShop.Core.ServiceContracts;

public interface IFavouriteBeerService
{
    bool AddToFavorites(Beer beer);
    bool RemoveFromFavourites(int id);
    List<Beer>? GetFavoriteBeers();
}