using BeerShop.Core.Domain.Entities;

namespace BeerShop.Core.ServiceContracts;

public interface IBeerApiService
{
    Task<List<Beer>?> GetBeers(int page, int perPage, string name);
}