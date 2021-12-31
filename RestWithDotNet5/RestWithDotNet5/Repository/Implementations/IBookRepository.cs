using RestWithDotNet5.Model;
using System.Collections.Generic;

namespace RestWithDotNet5.Repository.Implementations
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        List<Book> FindAll();
        Book FindById(long id);
        void Delete(long id);
        bool Exists(long id);
    }
}
