using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IPetService,PetService>();
builder.Services.AddSingleton<MyInfrastructureClass>();
var app = builder.Build();
app.MapControllers();
app.Run();
public class MyPetshopController(IPetService petService) : ControllerBase
{
    
    [HttpGet(nameof(GetPets))]
    public List<object> GetPets()
    {
        return petService.GetPets();
    }
}