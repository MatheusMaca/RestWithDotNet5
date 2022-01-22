using RestWithDotNet5.Data.VO;
using RestWithDotNet5.Model;

namespace RestWithDotNet5.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        User RefreshUserInfo(User user);
    }
}
