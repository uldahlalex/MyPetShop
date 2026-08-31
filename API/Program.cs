using Infrastructure;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PetShopDb>();
builder.Services.AddScoped<IPetService,PetService>();
builder.Services.AddControllers();

var connectoinString = "Data Source=dev.db";
var options = new DataOptions().UseSQLite(connectoinString);
var dataOptions = new DataOptions<PetShopDb>(options);

builder.Services.AddScoped<PetShopDb>(_ => new PetShopDb(dataOptions));

var app = builder.Build();
app.MapControllers();
app.Run();
public class MyPetshopController(IPetService petService) : ControllerBase
{
    
    [HttpGet(nameof(GetPets))]
    public List<Pet> GetPets()
    {
        return petService.GetPets();
    }
}