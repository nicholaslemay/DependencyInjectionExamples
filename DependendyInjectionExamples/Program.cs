using DependendyInjectionExamples.Mappers;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<MapperA>()
    .AddTransient<MapperB>()
    .AddTransient<MapperC>()
    .AddTransient<IMapper, MapperA>()
    .AddTransient<IMapper, MapperB>()
    .AddTransient<IMapper, MapperC>()
    .AddSingleton<IHeavyFactory, HeavyFactory>()
    .AddSingleton<ServiceUsingHeavyFactory>()
    .AddSingleton<ICleanFactory, CleanFactory>()
    .AddSingleton<ServiceUsingCleanFactory>()
    .AddTransient<Func<string, IMapper>>(services => type => services.GetService<IEnumerable<IMapper>>().First(m=> m.MapperType() == type))
    .AddSingleton<ServiceUsingFunFactory>()
    .AddTransient<DelegateFactory>(services => type => services.GetService<IEnumerable<IMapper>>().First(m=> m.MapperType() == type))
    .AddSingleton<ServiceUsingDelegateFactory>()
    .BuildServiceProvider();

var serviceUsingHeavyFactory = serviceProvider.GetService<ServiceUsingHeavyFactory>();
serviceUsingHeavyFactory.DoTheDew("A");
serviceUsingHeavyFactory.DoTheDew("B");

Console.WriteLine();
Console.WriteLine();

var serviceUsingCleanFactory = serviceProvider.GetService<ServiceUsingHeavyFactory>();
serviceUsingCleanFactory.DoTheDew("A");
serviceUsingCleanFactory.DoTheDew("B");

Console.WriteLine();
Console.WriteLine();

var serviceUsingNoFactory = serviceProvider.GetService<ServiceUsingFunFactory>();
serviceUsingNoFactory.DoTheDew("A");
serviceUsingNoFactory.DoTheDew("B");

Console.WriteLine();
Console.WriteLine();

var serviceUsingDelegateFactory = serviceProvider.GetService<ServiceUsingDelegateFactory>();
serviceUsingDelegateFactory.DoTheDew("A");
serviceUsingDelegateFactory.DoTheDew("B");