using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace contacts_lib.models.utilities
{
    public class JWTRequirements
    {
        public string Issuer {get;private set;}
        public string Audience {get;private set;}
        public byte[] Key {get;private set;}
        public JWTRequirements()
        {
            IConfigurationRoot _appSettings = new ConfigurationBuilder().AddUserSecrets<JWTRequirements>().Build();
            Issuer = _appSettings["jwt:issuer"];
            Audience = _appSettings["jwt:audience"];
            Key = Encoding.UTF8.GetBytes(_appSettings["jwt:key"]);
        }
    }
}