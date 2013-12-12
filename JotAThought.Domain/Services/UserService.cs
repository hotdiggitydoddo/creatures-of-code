using JotAThought.Domain.Contracts;
using JotAThought.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCrypto;

namespace JotAThought.Domain.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repo;
        private ICryptoService _crypto;

        public UserService(IRepository<User> repo, ICryptoService crypto)
        {
            _repo = repo;
            _crypto = crypto;
        }

        public bool ChangePassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string login, string password)
        {
            var user = _repo.Query(u => u.UserName.ToLower() == login.ToLower()).FirstOrDefault();
    
            if (user != null)
                if (user.Password == _crypto.Compute(password, user.PasswordSalt))
                    return user;
            return null;
        }

        public bool CreateUser(string userName, string password, string email, out string confirmationToken)
        {
            var user = _repo.Add(new User 
                                    { UserName = userName, 
                                      Password = _crypto.Compute(password), 
                                      PasswordSalt = _crypto.Salt, 
                                      EmailAddress = email 
                                    });
            _repo.Save();
            confirmationToken = CreateVerifcationToken(email);
            return true;
        }

        private string CreateVerifcationToken(string email)
        {
            string key = "J962006#n4302009";
            string sevenDaysFromNow = DateTime.Now.AddDays(7).ToShortDateString();
            string value = email + "|" + sevenDaysFromNow;
            return EncryptionManager.EncryptRijndael(value, key);
        }

        public bool VerifyUser(string token, out string userName)
        {

            string decryptedToken = EncryptionManager.DecryptRijndael(token, "J962006#n4302009");

            if (decryptedToken == null)
            {
                userName = null;
                return false;
            }

            string[] split = decryptedToken.Split('|');
            
            string potentialMatch = split[0];

            User user = _repo.Query(u => u.EmailAddress == potentialMatch).FirstOrDefault();

            if (user != null)
                if (DateTime.Parse(split[1]) >= DateTime.Now.Date)
                {
                    userName = user.UserName;
                    user.IsValidated = true;
                    _repo.Save();
                    return true;
                }
            userName = null;
            return false;
        }
    }
}
