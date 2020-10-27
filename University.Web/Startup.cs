using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using University.BL.Data;



namespace University.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configura el db Context para que sea usado como una unica estancia por request.
            app.CreatePerOwinContext(UniversityContext.Create);
        }
    }
}
