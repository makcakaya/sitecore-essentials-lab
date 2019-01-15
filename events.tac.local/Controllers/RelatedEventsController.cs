using events.tac.local.Business;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        private readonly RelatedEventsProvider _provider;

        public RelatedEventsController(RelatedEventsProvider provider)
        {
            _provider = provider;
        }

        public RelatedEventsController() : this(new RelatedEventsProvider())
        {
        }

        public ActionResult Index()
        {
            return View(_provider.GetRelatedEvents());
        }
    }
}