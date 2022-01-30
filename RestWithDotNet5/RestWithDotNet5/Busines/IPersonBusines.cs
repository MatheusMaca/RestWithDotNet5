using RestWithDotNet5.Data.VO;
using RestWithDotNet5.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestWithDotNet5.Busines.Implementations
{
    public interface IPersonBusines 
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        PersonVO Disabled(long id);
        void Delete(long id);
    }
}
