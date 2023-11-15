using Duende.IdentityServer.Models;
using Infrastructure.Identity;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope(AuthScopes.CatalogApiScope, "Catalog api full access"),
            new ApiScope(AuthScopes.BasketApiScope, "Basket api full access"),
            new ApiScope(AuthScopes.WebClientScope, "Web client full access"),
        };

    //public static IEnumerable<ApiResource> ApiResources =>
    //    new ApiResource[]
    //    {
    //        new ApiResource("alevelwebsite.com")
    //        {
    //            Scopes = new List<string>
    //            {
    //                AuthScopes.WebClientScope
    //            },
    //        },
    //        new ApiResource("catalog_api")
    //        {
    //            Scopes = new List<string>
    //            {
    //                AuthScopes.CatalogApiScope,
    //            },
    //        },
    //        new ApiResource("basket_api")
    //        {
    //            Scopes = new List<string>
    //            {
    //                AuthScopes.BasketApiScope
    //            },
    //        }
    //    };

    public static IEnumerable<Client> Clients(ConfigurationManager configuration) =>
        new Client[]
        {
            new Client
            {
                ClientId = "web_client_pkce",
                ClientName = "Web Client PKCE",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = { new Secret("secret".Sha256()) },
                RedirectUris = { $"{configuration["Api:WebClientUrl"]}/signin-oidc" },
                AllowedScopes = { AuthScopes.OpenIdScope, AuthScopes.ProfileScope, AuthScopes.WebClientScope },
                RequirePkce = true,
                RequireConsent = false
            },
            new Client
            {
                ClientId = "catalog_api",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) }
            },
            new Client
            {
                ClientId = "catalog_swagger_ui",
                ClientName = "Catalog Swagger UI",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = { $"{configuration["Api:CatalogUrl"]}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{configuration["Api:CatalogUrl"]}/swagger/" },
                AllowedScopes = { AuthScopes.WebClientScope, AuthScopes.CatalogApiScope }
            },
            new Client
            {
                ClientId = "basket_api",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { AuthScopes.CatalogApiScope }
            },
            new Client
            {
                ClientId = "basket_swagger_ui",
                ClientName = "Basket Swagger UI",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = { $"{configuration["Api:BasketUrl"]}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{configuration["Api:BasketUrl"]}/swagger/" },
                AllowedScopes = { AuthScopes.WebClientScope, AuthScopes.BasketApiScope }
            },
        };
}