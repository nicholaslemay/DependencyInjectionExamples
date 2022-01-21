using Microsoft.Extensions.DependencyInjection;
namespace DependendyInjectionExamples.Mappers;

public interface IHeavyFactory
{
    public IMapper GetMapper(string type);
}
public class HeavyFactory : IHeavyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public HeavyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMapper GetMapper(string type)
    {
        switch (type)
        {
            case "A":
                return _serviceProvider.GetService<MapperA>();
            case "B":
                return _serviceProvider.GetService<MapperB>();
            case "C":
                return _serviceProvider.GetService<MapperB>();
            default:
                throw new Exception($"Unknown factory type {type}");
        }
    }
}

public class ServiceUsingHeavyFactory
{
    private readonly IHeavyFactory _factory;

    public ServiceUsingHeavyFactory(IHeavyFactory factory)
    {
        _factory = factory;
    }

    public void DoTheDew(string type)
    {
        var mapper = _factory.GetMapper(type);
        Console.WriteLine($"ServiceUsingHeavyFactory doing something of type:{type} with:{mapper.GetType()}");
    }
}

