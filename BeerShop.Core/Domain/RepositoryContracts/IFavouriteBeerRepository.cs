using BeerShop.Core.Domain.Entities;

namespace BeerShop.Core.Domain.RepositoryContracts;

public interface IFavouriteBeerRepository
{
    List<Beer>? ReadData();
    bool RemoveData(int id);
    bool InsertData(Beer beer);
}