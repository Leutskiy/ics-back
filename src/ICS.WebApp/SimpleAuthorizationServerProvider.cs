using ICS.Domain.Data.Repositories.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ICS.WebApp
{
    public sealed class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserRepository _userRepository;

        public SimpleAuthorizationServerProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // validate the client Id and secret against database or from configuration file
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await _userRepository.Get(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                context.Rejected();
                return;
            }

            var userId = $"{user.Id}";
            var profileId = user.ProfileId.HasValue ? $"{user.ProfileId.Value}" : string.Empty;

            var oAuthClaimIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie/*context.Options.AuthenticationType*/);
            oAuthClaimIdentity.AddClaim(new Claim("UserId", userId));
            oAuthClaimIdentity.AddClaim(new Claim("ProfileId", profileId));

            //var claimPrincipal = new ClaimsPrincipal(oAuthClaimIdentity);
            //HttpContext.Current.Request.GetOwinContext().Authentication.SignIn(oAuthClaimIdentity);
            context.Validated(oAuthClaimIdentity);

            /*ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(oAuthClaimIdentity.Claims, CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, cookiesClaimIdentity);

            context.Validated(cookiesClaimIdentity);*/

            /*
            oAuthClaimIdentity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
            oAuthClaimIdentity.AddClaim(new Claim(ClaimTypes.Email, "test@server.com"));
            oAuthClaimIdentity.AddClaim(new Claim(ClaimTypes.Authentication, "true"));*/


            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            //context.Request.Context.Authentication.SignIn(newoAuthClaimIdentity);
            ///*context.Request.Context.Authentication.User.AddIdentity(oAuthClaimIdentity);*/
            //context.Validated(oAuthClaimIdentity);

            //// Setting Claim Identities for OAUTH 2 protocol
            ///*ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(oAuthClaimIdentity.Claims, CookieAuthenticationDefaults.AuthenticationType);*/

            //// Setting user authentication
            //AuthenticationProperties properties = CreateProperties(user.AccountName);
            //AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, properties);

            //// Grant access to authorize user
            //context.Validated(ticket);
            ///*context.Request.Context.Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            //context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
            //context.Request.Context.Authentication.User.AddIdentity(cookiesClaimIdentity);*/
        }

        #region Create Authentication properties method

        /// <summary>
        /// Create Authentication properties method
        /// </summary>
        /// <param name="userName">User name parameter</param>
        /// <returns>Returns authenticated properties</returns>
        public static AuthenticationProperties CreateProperties(string userName)
        {
            // Settings.  
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };

            // Return info
            return new AuthenticationProperties(data)
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            };
        }

        #endregion

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }
        public override async Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            string uri = context.Request.Uri.ToString();
        }
    }
}