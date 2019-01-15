using events.tac.local.Business;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public sealed class BreadcrumbController : Controller
    {
        private readonly BreadcrumbBuilder _builder;

        public BreadcrumbController(BreadcrumbBuilder builder)
        {
            _builder = builder;
        }

        public BreadcrumbController() : this(new BreadcrumbBuilder())
        {
        }

        public ActionResult Index()
        {
            return View(_builder.Build());
        }
    }
}