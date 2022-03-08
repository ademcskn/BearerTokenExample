using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(BearerTokenExample.Startup))]

namespace BearerTokenExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration configuration = new HttpConfiguration();
            Configure(app);
            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);
        }

        private void Configure(IAppBuilder app) 
        {
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/getToken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10),
                AllowInsecureHttp = true,
                Provider = new AuthorizeServerProvider()
            };
            app.UseOAuthAuthorizationServer(option);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
