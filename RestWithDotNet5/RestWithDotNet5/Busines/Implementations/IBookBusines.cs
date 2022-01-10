using RestWithDotNet5.Data.VO;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public interface IBookBusines
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        List<BookVO> FindAll();
        BookVO FindById(long id);
        void Delete(long id);
    }
}
