using RestWithDotNet5.Model.Base;
using System.Collections.Generic;

namespace RestWithDotNet5.Repository.Implementations
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        List<T> FindAll();
        T FindById(long id);
        void Delete(long id);
        bool Exists(long id);
    }
}
