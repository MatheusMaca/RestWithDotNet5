using RestWithDotNet5.Model;
using System.Collections.Generic;

namespace RestWithDotNet5.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        void Delete(long id);
        bool Exists(long id);
    }
}
