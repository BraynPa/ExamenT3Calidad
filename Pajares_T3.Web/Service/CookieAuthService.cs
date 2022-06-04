using Microsoft.AspNetCore.Authentication;
using Pajares_T3.Web.Bd;
using Pajares_T3.Web.Models;
using System.Security.Claims;

namespace Pajares_T3.Web.Service
{
    public interface ICookieAuthService
    {
        void SetHttpContext(HttpContext httpContext);
        public void Login(ClaimsPrincipal claim);
        public Claim ObtenerClaim();
        Usuario LoggedUser();
    }


    public class CookieAuthService : ICookieAuthService
    {
        private HttpContext httpContext;
        private IVeterinariaContext context;

        public CookieAuthService(IVeterinariaContext context)
        {

            this.context = context;
        }
        public void SetHttpContext(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public void Login(ClaimsPrincipal claim)
        {
            httpContext.SignInAsync(claim);

        }

        public Claim ObtenerClaim()
        {
            var claim = httpContext.User.Claims.FirstOrDefault();
            return claim;
        }
        
        public Usuario LoggedUser()
        {

            var claim = httpContext.User.Claims.FirstOrDefault();

            var user = context._usuario.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
