using System.Collections.Generic;

namespace RestWithDotNet5.Data.Converter.Contract
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
