using BeerShop.Core.Domain.Entities;
using BeerShop.Core.Domain.RepositoryContracts;
using BeerShop.Core.ServiceContracts;

namespace BeerShop.Core.Services;

public class FavouriteBeerService : IFavouriteBeerService
{
    private readonly IFavouriteBeerRepository _favouriteBeerRepository;

    public FavouriteBeerService(IFavouriteBeerRepository favouriteBeerRepository)
    {
        _favouriteBeerRepository = favouriteBeerRepository;
    }

    public bool AddToFavorites(Beer beer)
    {
        return _favouriteBeerRepository.InsertData(beer);
    }

    public bool RemoveFromFavourites(int id)
    {
        return _favouriteBeerRepository.RemoveData(id);
    }

    public List<Beer>? GetFavoriteBeers()
    {
        return _favouriteBeerRepository.ReadData();
    }
}