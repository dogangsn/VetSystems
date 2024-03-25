﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetSystems.Vet.Application.Models.Settings.SmsParameters
{
    public class SmsParametersDto
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public int SmsIntegrationType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
