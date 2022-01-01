using RestWithDotNet5.Model;
using RestWithDotNet5.Repository.Implementations;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public class BookBusines : IBookBusines
    {
        private readonly IRepository<Book> _repository;

        public BookBusines(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
