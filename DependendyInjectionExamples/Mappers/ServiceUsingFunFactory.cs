namespace DependendyInjectionExamples.Mappers;

public class ServiceUsingFunFactory
{
    private readonly Func<string, IMapper> _getMapperBasedOnType;
    public ServiceUsingFunFactory(Func<string, IMapper> getMapperBasedOnType) => _getMapperBasedOnType = getMapperBasedOnType;

    public void DoTheDew(string type)
    {
        var mapper = _getMapperBasedOnType(type);
        Console.WriteLine($"ServiceUsingFunFactory doing something of type:{type} with:{mapper.GetType()}");
    }
}