namespace DependendyInjectionExamples.Mappers;


public delegate IMapper DelegateFactory(string key);

public class ServiceUsingDelegateFactory
{
    private readonly DelegateFactory _factory;

    public ServiceUsingDelegateFactory(DelegateFactory factory) => _factory = factory;

    public void DoTheDew(string type)
    {
        var mapper = _factory(type);
        Console.WriteLine($"ServiceUsingDelegateFactory doing something of type:{type} with:{mapper.GetType()}");
    }
}