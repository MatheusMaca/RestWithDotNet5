using RestWithDotNet5.Model;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public interface IPersonBusines 
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        void Delete(long id);
    }
}
