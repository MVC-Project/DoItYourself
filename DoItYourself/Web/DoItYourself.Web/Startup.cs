using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(DoItYourself.Web.Startup))]

namespace DoItYourself.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
