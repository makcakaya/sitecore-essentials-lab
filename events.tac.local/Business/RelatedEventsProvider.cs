using events.tac.local.Models;
using System.Collections.Generic;
using System.Linq;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public sealed class RelatedEventsProvider
    {
        private readonly IRenderingContext _context;

        public RelatedEventsProvider(IRenderingContext context)
        {
            _context = context;
        }

        public RelatedEventsProvider() : this(SitecoreRenderingContext.Create())
        {
        }

        public IEnumerable<NavigationItem> GetRelatedEvents()
        {
            return _context.ContextItem
                 .GetMultilistFieldItems("relatedEvents")
                 .Select(i => new NavigationItem(i.DisplayName, i.Url));
        }
    }
}