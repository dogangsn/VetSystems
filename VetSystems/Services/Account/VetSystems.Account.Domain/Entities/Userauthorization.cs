﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Account.Domain.Common;

namespace VetSystems.Account.Domain.Entities
{
    public class Userauthorization : BaseEntity
    {
        public Guid Recid { get; set; }
        public Guid UsersId { get; set; }
        public Guid PropertyId { get; set; }
        public Guid RoleId { get; set; }
        public Guid EnterprisesId { get; set; }

        public virtual Enterprise Enterprises { get; set; }
    }
}
