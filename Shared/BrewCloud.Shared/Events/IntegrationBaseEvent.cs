﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BrewCloud.Shared.Events
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;

        }
        public IntegrationBaseEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;

        }
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
