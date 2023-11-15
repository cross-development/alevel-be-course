namespace Infrastructure.Identity;

public static class AuthScopes
{
    // Base scopes
    public const string OpenIdScope = "openid";
 
    public const string ProfileScope = "profile";

    // Custom scopes
    public const string CatalogApiScope = "catalog_api";

    public const string BasketApiScope = "basket_api";

    public const string WebClientScope = "web_client";
}