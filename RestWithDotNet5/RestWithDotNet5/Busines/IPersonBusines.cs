using RestWithDotNet5.Data.VO;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public interface IPersonBusines 
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        void Delete(long id);
    }
}
