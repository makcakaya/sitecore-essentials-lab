﻿using System.Collections.Generic;

namespace events.tac.local.Models
{
    public sealed class EventsList
    {
        public IEnumerable<EventDetails> Events { get; set; }
        public int TotalResultCount { get; set; }
        public int PageSize { get; set; }
    }
}