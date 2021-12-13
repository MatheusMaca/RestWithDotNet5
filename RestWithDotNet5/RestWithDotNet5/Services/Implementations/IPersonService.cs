using RestWithDotNet5.Model;
using System.Collections.Generic;

namespace RestWithDotNet5.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        void Delete(long id);
    }
}
