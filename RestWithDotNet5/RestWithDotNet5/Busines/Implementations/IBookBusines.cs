using RestWithDotNet5.Model;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public interface IBookBusines
    {
        Book Create(Book book);
        Book Update(Book book);
        List<Book> FindAll();
        Book FindById(long id);
        void Delete(long id);
    }
}
