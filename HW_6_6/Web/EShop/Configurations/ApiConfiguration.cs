﻿namespace EShop.Configurations;

public sealed class ApiConfiguration
{
    public string CatalogUrl { get; set; }

    public string CatalogPath { get; set; }

    public int SessionCookieLifetimeMinutes { get; set; }    

    public string CallbackUrl { get; set; }

    public string IdentityUrl { get; set; }

    public string RedirectUri { get; set; }
    
    public string PostLogoutRedirectUri { get; set; }
}