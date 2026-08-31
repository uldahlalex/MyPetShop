using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MyInfrastructureClass>();
builder.Services.AddScoped<IPetService,PetService>();
builder.Services.AddControllers();
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