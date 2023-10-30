﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystems.Shared.Dtos;
using VetSystems.Shared.Service;
using VetSystems.Vet.Application.Features.Definition.UnitDefinitions.Commands;
using VetSystems.Vet.Domain.Contracts;

namespace VetSystems.Vet.Application.Features.SaleBuy.Commands
{
    public class DeleteSaleBuyCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteSaleBuyCommandHandler : IRequestHandler<DeleteSaleBuyCommand, Response<bool>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IIdentityRepository _identity;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSaleBuyCommandHandler> _logger;
        private readonly IRepository<Vet.Domain.Entities.VetSaleBuyOwner> _saleBuyOwnerRepository;
        private readonly IRepository<Vet.Domain.Entities.VetSaleBuyTrans> _saleBuyTransRepository;
        private readonly IIdentityRepository _identityRepository;

        public DeleteSaleBuyCommandHandler(IUnitOfWork uow, IIdentityRepository identity, IMapper mapper, ILogger<DeleteSaleBuyCommandHandler> logger, IRepository<Domain.Entities.VetSaleBuyOwner> saleBuyOwnerRepository, IRepository<Domain.Entities.VetSaleBuyTrans> saleBuyTransRepository, IIdentityRepository identityRepository)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _identity = identity ?? throw new ArgumentNullException(nameof(identity));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _saleBuyOwnerRepository = saleBuyOwnerRepository ?? throw new ArgumentNullException(nameof(saleBuyOwnerRepository));
            _saleBuyTransRepository = saleBuyTransRepository ?? throw new ArgumentNullException(nameof(saleBuyTransRepository));
            _identityRepository = identityRepository ?? throw new ArgumentNullException(nameof(identityRepository));
        }

        public async Task<Response<bool>> Handle(DeleteSaleBuyCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>
            {
                ResponseType = ResponseType.Ok,
                Data = true,
                IsSuccessful = true
            };
            try
            {
                var salebuyOwner = await _saleBuyOwnerRepository.GetByIdAsync(request.Id);
                if (salebuyOwner == null)
                {
                    _logger.LogWarning($"Untis update failed. Id number: {request.Id}");
                    return Response<bool>.Fail("Property update failed", 404);
                }
                salebuyOwner.Deleted = true;
                salebuyOwner.DeletedDate = DateTime.Now;
                salebuyOwner.DeletedUsers = _identityRepository.Account.UserName;

                //Trans satırların silinmesi gerekmektedir.

                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }



}
