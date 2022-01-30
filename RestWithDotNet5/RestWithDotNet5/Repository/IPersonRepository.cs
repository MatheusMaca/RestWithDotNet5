using RestWithDotNet5.Model;
using RestWithDotNet5.Repository.Implementations;
using System.Collections.Generic;

namespace RestWithDotNet5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
