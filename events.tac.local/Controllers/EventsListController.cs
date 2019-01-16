﻿using events.tac.local.Business;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventsListController : Controller
    {
        private readonly EventsProvider _provider;

        public EventsListController(EventsProvider provider)
        {
            _provider = provider;
        }

        public EventsListController() : this(new EventsProvider())
        {
        }

        public ActionResult Index(int page = 1)
        {
            return View(_provider.GetEventsList(page - 1));
        }
    }
}