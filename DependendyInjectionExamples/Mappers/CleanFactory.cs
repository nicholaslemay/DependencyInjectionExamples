namespace DependendyInjectionExamples.Mappers;

public interface ICleanFactory
{
    public IMapper GetMapper(string type);
}

public class CleanFactory : ICleanFactory
{
    private readonly IEnumerable<IMapper> _mappers;

    public CleanFactory(IEnumerable<IMapper> mappers) => _mappers = mappers;

    public IMapper GetMapper(string type) => _mappers.First(m => m.MapperType() == type);
}

public class ServiceUsingCleanFactory
{
    private readonly ICleanFactory _factory;

    public ServiceUsingCleanFactory(ICleanFactory factory) => _factory = factory;

    public void DoTheDew(string type)
    {
        var mapper = _factory.GetMapper(type);
        Console.WriteLine($"ServiceUsingCleanFactory doing something of type:{type} with:{mapper.GetType()}");
    }
}

