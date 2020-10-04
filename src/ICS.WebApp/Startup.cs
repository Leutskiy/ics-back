using ICS.Domain.Data.Repositories.Contracts;
using ICS.WebApp.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using StructureMap;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(ICS.WebApp.Startup))]

namespace ICS.WebApp
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            HttpConfiguration config = new HttpConfiguration();

            //Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(CorsOptions.AllowAll);

            var container = StructuremapWebApi.Start(config);

            ConfigureOAuth(app, container);

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            //Use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            /*app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5.0),
            });*/

            var userRepository = container.GetInstance<IUserRepository>();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!
                AllowInsecureHttp = true,
                //The Path for generating the Token
                TokenEndpointPath = new PathString("/token"),
                //Setting the Token Expired Time (1 day)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //Simple authorization server provider class will validate the user credentials
                Provider = new SimpleAuthorizationServerProvider(userRepository)
            };

            //Token Generation
            
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            /*AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;*/

            // Enable the application to use bearer tokens to authenticate users 
            // app.UseOAuthBearerTokens(OAuthServerOptions); new OAuthBearerAuthenticationOptions()

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.  
            /*app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));*/
        }
    }
}