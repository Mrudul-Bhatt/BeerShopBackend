using BeerShop.Core.Domain.Entities;
using BeerShop.Core.DTO;
using BeerShop.Core.ServiceContracts;

namespace BeerShop.Core.Services;

public class BeerService : IBeerService
{
    private readonly IBeerApiService _beerApiService;
    private readonly IFavouriteBeerService _favouriteBeerService;

    public BeerService(IBeerApiService beerApiService, IFavouriteBeerService favouriteBeerService)
    {
        _beerApiService = beerApiService;
        _favouriteBeerService = favouriteBeerService;
    }

    public async Task<List<BeerDto>?> GetBeers(int page, int perPage, string name)
    {
        var beers = await _beerApiService.GetBeers(page, perPage, name);
        var favBeers = GetFavoriteBeers();

        var beerList = new List<BeerDto>();

        beers?.ForEach(beer =>
        {
            var beerDto = new BeerDto
            {
                id = beer.id,
                name = beer.name,
                description = beer.description,
                image_url = beer.image_url,
                is_favourite = favBeers?.Find(favBeer => favBeer.id == beer.id) != null
            };

            beerList.Add(beerDto);
        });

        return beerList;
    }

    public bool AddToFavourite(Beer beer)
    {
        return _favouriteBeerService.AddToFavorites(beer);
    }

    public bool RemoveFromFavourites(int id)
    {
        return _favouriteBeerService.RemoveFromFavourites(id);
    }

    public List<Beer>? GetFavoriteBeers()
    {
        return _favouriteBeerService.GetFavoriteBeers();
    }
}