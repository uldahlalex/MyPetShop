using System.Resources;
using Infrastructure;

namespace Service;

public class PetService : IPetService
{
    private readonly PetShopDb _infrastructureClass;

    public PetService(PetShopDb infrastructureClass)
    {
        Console.WriteLine("Service has been instantiated");
        _infrastructureClass = infrastructureClass;
    }


    public List<Pet> GetPets()
    {
        return _infrastructureClass.MyPets;
    }
}

public interface IPetService
{
    public List<Pet> GetPets();
}
