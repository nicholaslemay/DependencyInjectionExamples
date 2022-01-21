namespace DependendyInjectionExamples.Mappers;

public interface IMapper
{
    public string MapperType();
}

public class MapperA : IMapper
{
    public string MapperType() => "A";
}

public class MapperB : IMapper
{
    public string MapperType() => "B";
}

public class MapperC : IMapper
{
    public string MapperType() => "C";
}