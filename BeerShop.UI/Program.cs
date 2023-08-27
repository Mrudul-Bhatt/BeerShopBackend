using BeerShop.Core.Domain.RepositoryContracts;
using BeerShop.Core.ServiceContracts;
using BeerShop.Core.Services;
using BeerShop.Infrastructure.ExternalAPI;
using BeerShop.Infrastructure.Repositories;

var policyName = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddTransient<IFavouriteBeerRepository, FavouriteBeerRepository>();
builder.Services.AddHttpClient<IBeerApiService, BeerApiService>();
builder.Services.AddTransient<IBeerService, BeerService>();
builder.Services.AddTransient<IFavouriteBeerService, FavouriteBeerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// builder.Services.AddCors(options => options.AddPolicy(policyName,
//     policyBuilder =>
//     {
//         policyBuilder.WithOrigins("*")
//             .AllowAnyMethod()
//             .AllowAnyHeader();
//     }));

builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();