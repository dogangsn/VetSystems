﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BrewCloud.Shared.Events
{
    public class EmailData
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
