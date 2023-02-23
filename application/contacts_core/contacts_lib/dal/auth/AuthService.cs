using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contacts_lib.dal;
using contacts_lib.models.DTO;
using contacts_lib.models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace contacts_lib.dal.auth
{
    public class AuthService: IAuthService
    {
        private readonly IConfigurationRoot _appSettings;
        private readonly ContactsDevContext _context;
        public AuthService(ContactsDevContext context)
        {
            _context = context;
            _appSettings = new ConfigurationBuilder().AddUserSecrets<AuthService>().Build();
        }
        public async Task<string> Login(LoginDTO _loginObject)
        {
            User _user = await _context.Users.SingleOrDefaultAsync(_userData => _userData.UserName == _loginObject.username);
            if(Encoding.UTF8.GetString(_user.Password) == _hash(_loginObject.password, _user.Salt))
            {
                return _generateJWT(_user);
            }    
            return "Unauthorized";
        }
        public async Task<string> Register(RegisterDTO _registrationObject)
        {
            return "penis";
        }
        private string _hash(string _password, string _salt)
        {
            string _fullPassword = string.Format("{0}{1}", _password, _salt);
            byte[] _key = Encoding.UTF8.GetBytes(_appSettings["hashKey"]);
            HMACSHA256 _hashingAlg = new HMACSHA256(_key);
            byte[] _computedHash = _hashingAlg.ComputeHash(Encoding.UTF8.GetBytes(_fullPassword));
            return Encoding.UTF8.GetString(_computedHash);
        }
        private string _generateJWT(User _userObject)
        {
            return "penis";
        }
    }
}