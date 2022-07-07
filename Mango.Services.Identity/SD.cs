using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Mango.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentidyResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScope => new List<ApiScope>
        {
            new ApiScope("mango", "Mango Server"),
            new ApiScope(name: "read", displayName: "Read your data"),
            new ApiScope(name: "write", displayName: "Write your data"),
            new ApiScope(name: "delete", displayName: "Delete your data")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" },
                RedirectUris = {
                    "https://localhost:44339/signin-oidc", 
                    //"https://localhost:7120/signin-oidc", 
                    //"http://localhost:26910/signin-oidc" 
                },
                PostLogoutRedirectUris = {"https://localhost:44339/signout-callback-oidc" }
            },
            new Client
            {
                ClientId = "mango",
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:44339/signin-oidc",
                    "https://localhost:7120/signin-oidc" },
                PostLogoutRedirectUris = {"https://localhost:44339/signout-callback-oidc",
                    "https://localhost:7120/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "mango"
                }
            },
        };
    }
}
