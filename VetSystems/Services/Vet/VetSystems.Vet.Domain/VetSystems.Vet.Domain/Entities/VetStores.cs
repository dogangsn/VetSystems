﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Vet.Domain.Common;

namespace VetSystems.Vet.Domain.Entities
{
    public class VetStores : BaseEntity, IAggregateRoot
    {

        [NotMapped]
        public int RecId { get; set; }
        public bool Active { get; set; } = true;
        public string DepotCode { get; set; } = string.Empty;
        public string DepotName { get; set; } = string.Empty;
    }
}
