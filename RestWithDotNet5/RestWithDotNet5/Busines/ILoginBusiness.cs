using RestWithDotNet5.Data.VO;

namespace RestWithDotNet5.Busines
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
