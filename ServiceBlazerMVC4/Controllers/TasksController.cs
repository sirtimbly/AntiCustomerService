using System.Web.Mvc;

namespace ServiceBlazerMVC4.Controllers
{
    public class TasksController : Controller
    {
        //
        // GET: /Tasks/

        public ActionResult Index()
        {
            return View();
        }
    }
}
