using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Web.UI.WebControls;
using System;
using System.Web;

namespace events.tac.local.Models
{
    public sealed class EventDetails : SearchResultItem
    {
        public string ContentHeading { get; set; }
        public string ContentIntro { get; set; }
        public DateTime StartDate { get; set; }

        public HtmlString EventImage => new HtmlString(FieldRenderer.Render(GetItem(), "EventImage", "DisableWebEditing=true&mw=150"));
    }
}