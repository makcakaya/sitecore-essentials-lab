using events.tac.local.Business;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationBuilder _builder;

        public NavigationController(NavigationBuilder builder)
        {
            _builder = builder;
        }

        public NavigationController() : this(new NavigationBuilder())
        {
        }

        public ActionResult Index()
        {
            return View(_builder.Build());
        }
    }
}