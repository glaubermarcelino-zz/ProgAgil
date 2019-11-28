using CoreApi3JWT.Models;

namespace CoreApi3JWT.Repositories
{
    public interface IUserRepository
    {
         Users GetUser(string user,string password);
    }
}