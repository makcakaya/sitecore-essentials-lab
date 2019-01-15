using System.Collections.Generic;

namespace events.tac.local.Models
{
    public sealed class NavigationMenuItem : NavigationItem
    {
        public NavigationMenuItem(string title, string url, IEnumerable<NavigationMenuItem> children)
            : base(title, url, false)
        {
            Children = children;
        }

        public IEnumerable<NavigationMenuItem> Children { get; set; }
    }
}