using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
public class MyPetshopController : ControllerBase
{
    [HttpGet(nameof(GetPets))]
    public List<object> GetPets()
    {
        return new List<object>()
        {
            new
            {
                Key = "Value"
            }
        };
    }
}