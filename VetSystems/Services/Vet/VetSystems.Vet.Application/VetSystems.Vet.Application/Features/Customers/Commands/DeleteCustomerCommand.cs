﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Shared.Dtos;

namespace VetSystems.Vet.Application.Features.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<Response<bool>>
    {

    }


}