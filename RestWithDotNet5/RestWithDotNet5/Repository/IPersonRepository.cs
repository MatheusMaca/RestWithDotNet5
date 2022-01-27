using RestWithDotNet5.Model;
using RestWithDotNet5.Repository.Implementations;

namespace RestWithDotNet5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
