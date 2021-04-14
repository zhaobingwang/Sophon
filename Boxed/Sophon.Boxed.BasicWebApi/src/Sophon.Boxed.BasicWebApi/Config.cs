using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApi
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> {
                new ApiScope("test1", "WeatherForecast1"),
                new ApiScope("test2", "WeatherForecast2")
            };

        public static IEnumerable<Client> Clients => new List<Client>
            {
                new Client
                {
                    ClientId="client_id",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets=
                    {
                        new Secret("123456".Sha256())
                    },
                    AllowedScopes={ "test1" }
                }
            };
    }
}
