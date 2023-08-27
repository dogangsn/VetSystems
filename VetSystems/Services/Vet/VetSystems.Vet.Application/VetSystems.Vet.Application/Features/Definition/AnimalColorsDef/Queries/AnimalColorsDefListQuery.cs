﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Shared.Dtos;
using VetSystems.Shared.Service;
using VetSystems.Vet.Application.Models.Definition.AnimalColorsDef;
using VetSystems.Vet.Domain.Contracts;

namespace VetSystems.Vet.Application.Features.Definition.AnimalColorsDef.Queries
{
    public class AnimalColorsDefListQuery : IRequest<Response<List<AnimalColorsDefListDto>>>
    {
    }

    public class AnimalColorsDefListQueryHandler : IRequestHandler<AnimalColorsDefListQuery, Response<List<AnimalColorsDefListDto>>>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AnimalColorsDefListQueryHandler(IIdentityRepository identityRepository, IUnitOfWork uow, IMapper mapper)
        {
            _identityRepository = identityRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<List<AnimalColorsDefListDto>>> Handle(AnimalColorsDefListQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<AnimalColorsDefListDto>>();
            try
            {
                string query = "Select * from vetAnimalColorsDef  With(NOLOCK)";
                var _data = _uow.Query<AnimalColorsDefListDto>(query).ToList();
                response = new Response<List<AnimalColorsDefListDto>>
                {
                    Data = _data,
                    IsSuccessful = true,
                };
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                //response.Errors = ex.ToString();
            }

            return response;
        }
    }
}
