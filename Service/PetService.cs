using System.Resources;
using Infrastructure;

namespace Service;

public class PetService : IPetService
{
    private readonly MyInfrastructureClass _infrastructureClass;

    public PetService(MyInfrastructureClass infrastructureClass)
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
