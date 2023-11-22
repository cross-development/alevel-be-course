using System.Security.Principal;

namespace EShop.Services.Interfaces;

public interface IIdentityParser<out T>
{
    T Parse(IPrincipal principal);
}