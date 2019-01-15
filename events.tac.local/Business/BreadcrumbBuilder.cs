using events.tac.local.Models;
using System.Collections.Generic;
using System.Linq;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public sealed class BreadcrumbBuilder
    {
        private readonly IRenderingContext _renderingContext;

        public BreadcrumbBuilder(IRenderingContext renderingContext)
        {
            _renderingContext = renderingContext;
        }

        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create())
        {
        }

        public IEnumerable<NavigationItem> Build()
        {
            var homeItem = _renderingContext?.HomeItem;
            var contextItem = _renderingContext?.ContextItem;

            return homeItem == null || contextItem == null ?
                Enumerable.Empty<NavigationItem>() :
                contextItem.GetAncestors()
                    .Where(i => homeItem.IsAncestorOrSelf(i))
                    .Select(i => new NavigationItem(i.DisplayName, i.Url, false))
                    .Concat(new[]
                    {
                        new NavigationItem(contextItem.DisplayName, contextItem.Url, true)
                    });
        }
    }
}