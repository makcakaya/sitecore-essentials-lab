using events.tac.local.Models;
using System.Collections.Generic;
using System.Linq;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public sealed class NavigationBuilder
    {
        private readonly IRenderingContext _context;

        public NavigationBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public NavigationBuilder() : this(SitecoreRenderingContext.Create())
        {
        }

        public NavigationMenuItem Build()
        {
            var root = _context?.DatasourceOrContextItem;

            return new NavigationMenuItem
                (
                    root?.DisplayName,
                    root?.Url,
                    root != null && _context?.ContextItem != null ? Build(root, _context.ContextItem) : null
                );
        }

        private IEnumerable<NavigationMenuItem> Build(IItem node, IItem current)
        {
            return node
                .GetChildren()
                .Select(i => new NavigationMenuItem
                (
                    i.DisplayName,
                    i.Url,
                    i.IsAncestorOrSelf(current) ? Build(i, current) : null
                ));
        }
    }
}