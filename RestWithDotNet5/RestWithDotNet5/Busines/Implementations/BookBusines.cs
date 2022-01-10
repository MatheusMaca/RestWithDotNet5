using RestWithDotNet5.Data.Converter.Implementations;
using RestWithDotNet5.Data.VO;
using RestWithDotNet5.Model;
using RestWithDotNet5.Repository.Implementations;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public class BookBusines : IBookBusines
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusines(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
