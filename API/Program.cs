using Infrastructure;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetService,PetService>();
builder.Services.AddControllers();

var connectoinString = "Data Source=dev.db";
var options = new DataOptions().UseSQLite(connectoinString);
var dataOptions = new DataOptions<PetShopDb>(options);

builder.Services.AddScoped<PetShopDb>(_ => new PetShopDb(dataOptions));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope
        .ServiceProvider
        .GetRequiredService<PetShopDb>()
        .CreateTable<Pet>(tableOptions:TableOptions.CreateIfNotExists);
}

app.MapControllers();


app.Run();
public class MyPetshopController(IPetService petService, PetShopDb db) : ControllerBase
{
    
    [HttpGet(nameof(GetPets))]
    public List<Pet> GetPets()
    {
        var pet = new Pet()
        {
            Id = "lkdsjflkdsf"+new Random().Next(),
            Name = "Bob"
        };
        db.Insert(pet);
        return petService.GetPets();
    }
}