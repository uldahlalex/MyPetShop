using System.Resources;
using Infrastructure;

namespace Service;

public class PetService : IPetService
{
    private readonly PetShopDb db;

    public PetService(PetShopDb db)
    {
        Console.WriteLine("Service has been instantiated");
        this.db = db;
    }


    public List<Pet> GetPets()
    {
        return db.Pets().ToList();
    }
}

public interface IPetService
{
    public List<Pet> GetPets();
}
