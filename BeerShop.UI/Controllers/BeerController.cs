using BeerShop.Core.Domain.Entities;
using BeerShop.Core.DTO;
using BeerShop.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.UI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BeerController : ControllerBase
{
    private readonly IBeerService _beerService;
    private readonly ILogger<BeerController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BeerController(ILogger<BeerController> logger, IBeerService beerService,
        IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _beerService = beerService;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public Task<List<BeerDto>?> GetBeers(int page, int perPage, string name)
    {
        return _beerService.GetBeers(page, perPage, name);
    }

    [HttpPut]
    public bool AddToFavourite(Beer beer)
    {
        return _beerService.AddToFavourite(beer);
    }

    [HttpDelete]
    public bool RemoveFromFavourite(int id)
    {
        return _beerService.RemoveFromFavourites(id);
    }

    [HttpGet]
    public List<Beer>? GetFavoriteBeers()
    {
        return _beerService.GetFavoriteBeers();
    }
}