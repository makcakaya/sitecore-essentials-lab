using events.tac.local.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Mvc.Presentation;
using System.Linq;

namespace events.tac.local.Business
{
    public sealed class EventsProvider
    {
        private const int PageSize = 4;

        public EventsList GetEventsList(int pageNo)
        {
            var contextItem = RenderingContext.Current.ContextItem;
            var indexName = "events_" + contextItem.Database.Name.ToLower() + "_index";
            var index = ContentSearchManager.GetIndex(indexName);
            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<EventDetails>()
                    .Where(i => i.Paths.Contains(contextItem.ID))
                    .Where(i => i.Language == contextItem.Language.Name)
                    .Page(pageNo, PageSize)
                    .GetResults();

                return new EventsList()
                {
                    Events = results.Hits.Select(h => h.Document).ToArray(),
                    PageSize = PageSize,
                    TotalResultCount = results.TotalSearchResults
                };
            }
        }
    }
}