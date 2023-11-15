﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Vet.Application.Models.Customers;
using VetSystems.Vet.Domain.Entities;

namespace VetSystems.Vet.Application.Models.Appointments
{
    public class AppointmentsDto
    {
        [NotMapped]
        public Guid recId { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public string note { get; set; } = string.Empty;
        public string doctorId { get; set; } = string.Empty;
        public string customerId { get; set; }

    }
}