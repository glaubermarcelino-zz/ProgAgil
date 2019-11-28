using System.Collections.Generic;
using CoreApi3JWT.Models;
using CoreApi3JWT.Repositories;
using System.Linq;

namespace CoreApi3JWT.ReposiRepositoriestory
{
    public class UserRepository : IUserRepository
    {
        public Users GetUser(string user, string password)
        {
            var users = new List<Users>(){
                new Users{UserId = 1,Name="Glauber Marcelino da Silva",Password="karol0xaa",Role="manager"},
                new Users{UserId = 2,Name="Acacia Santos Mota",Password="123465",Role="employee"},
                new Users{UserId = 3,Name="Lilian Maria Santos da Silva",Password="123456789",Role="teacher"}
            };
            return users
                    .Where(x=>x.Name.ToLower().Equals(user) && x.Password.ToLower().Equals(password))
                    .SingleOrDefault();
        }
    }
}