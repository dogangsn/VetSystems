﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewCloud.Account.Domain.Common;

namespace BrewCloud.Account.Domain.Entities
{
    public class Abilitygroup : BaseEntity
    {
        public string Groupname { get; set; }
        public Guid EnterprisesId { get; set; }
        public virtual Enterprise Enterprises { get; set; }
    }
}
