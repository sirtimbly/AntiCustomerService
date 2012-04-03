using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceBlazerMVC4.Controllers
{
    public partial class ServiceBlazerMVC4Controller : DbDataController<ServiceBlazerMVC4.Models.ServiceBlazerMVC4Context>
    {
        // Any code added here will apply to all entity types managed by this data controller
    }

    // This provides context-specific route registration
    public class ServiceBlazerMVC4RouteRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "ServiceBlazerMVC4"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
			RouteTable.Routes.MapHttpRoute(
                "ServiceBlazerMVC4", // Route name
                "api/ServiceBlazerMVC4/{action}", // URL with parameters
                new { controller = "ServiceBlazerMVC4" } // Parameter defaults
            );
        }
    }
}
