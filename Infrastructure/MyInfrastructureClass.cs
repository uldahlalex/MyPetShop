using LinqToDB.Mapping;

namespace Infrastructure;

public class MyInfrastructureClass
{
  
}

public class Pet
{
    [PrimaryKey]public string Id { get; set; }
    public string Name { get; set; }
}