using JotAThought.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotAThought.Domain.Contracts
{
    public interface IUserService
    {
        bool ChangePassword(int id, string password);
        User GetUser(string login, string password);
        bool CreateUser(string userName, string password, string email, out string confirmationToken);
        bool VerifyUser(string token, out string userName);
    }
}
