using RestWithDotNet5.Model;
using RestWithDotNet5.Repository.Implementations;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public class PersonBusines : IPersonBusines
    {
        private readonly IRepository<Person> _repository; 

        public PersonBusines(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
