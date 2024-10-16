﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewCloud.Shared.Dtos;
using BrewCloud.Shared.Service;
using BrewCloud.Vet.Application.Models.PetHotels.Accomodation;
using BrewCloud.Vet.Application.Models.PetHotels.Rooms;
using BrewCloud.Vet.Domain.Contracts;

namespace BrewCloud.Vet.Application.Features.PetHotels.Accomodation.Queries
{
    public class GetAccomodationListQuery : IRequest<Response<List<AccomodationListDto>>>
    {
        public Guid? CustomerId { get; set; }
    }

    public class GetAccomodationListQueryHandler : IRequestHandler<GetAccomodationListQuery, Response<List<AccomodationListDto>>>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAccomodationListQueryHandler(IIdentityRepository identityRepository, IUnitOfWork uow, IMapper mapper)
        {
            _identityRepository = identityRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<List<AccomodationListDto>>> Handle(GetAccomodationListQuery request, CancellationToken cancellationToken)
        {
            var response = Response<List<AccomodationListDto>>.Success(200);
            try
            {
                #region old
                //string query = "SELECT        vetcustomers.firstname + ' ' + vetcustomers.lastname AS customerName, vetrooms.roomname, vetaccomodation.roomid, vetaccomodation.customerid, vetaccomodation.patientsid, vetaccomodation.checkindate,  "
                //                    + "                          vetaccomodation.checkoutdate, vetaccomodation.accomodation, vetaccomodation.remark, vetaccomodation.createdate, vetaccomodation.updatedate, vetaccomodation.createusers, vetaccomodation.type,  "
                //                    + "                          vetaccomodation.id "
                //                    + " FROM            vetaccomodation LEFT OUTER JOIN "
                //                    + "                          vetrooms ON vetaccomodation.roomid = vetrooms.id LEFT OUTER JOIN "
                //                    + "                          vetcustomers ON vetaccomodation.customerid = vetcustomers.id "
                //                    + " WHERE        (vetaccomodation.deleted = 0)"; 
                #endregion
                string query = "SELECT        CASE WHEN vetaccomodation.customerid = '00000000-0000-0000-0000-000000000000' THEN 'Misafir' ELSE vetcustomers.firstname + ' ' + vetcustomers.lastname END AS customerName, vetpatients.name as patientname,"
                + " vetrooms.roomname, vetaccomodation.roomid, vetaccomodation.customerid, vetaccomodation.patientsid, "
                + " vetaccomodation.checkindate, "
                + "                          vetaccomodation.checkoutdate, vetaccomodation.accomodation, "
                + " 						 vetaccomodation.remark, "
                + " 						 vetaccomodation.createdate, "
                + " 						 vetaccomodation.updatedate, vetaccomodation.createusers, "
                + " 						 vetaccomodation.type, "
                + "                          vetaccomodation.id, vetrooms.price, vetrooms.pricingtype, isnull(vetaccomodation.islogout, 0) as  islogout"
                + " FROM            vetaccomodation LEFT OUTER JOIN"
                + "                          vetrooms ON vetaccomodation.roomid = vetrooms.id LEFT OUTER JOIN"
                + "                          vetcustomers ON vetaccomodation.customerid = vetcustomers.id LEFT OUTER JOIN "
                + " 						 vetpatients ON vetaccomodation.patientsid = vetpatients.id"
                + " WHERE        (vetaccomodation.deleted = 0)";
                if (request.CustomerId != Guid.Empty)
                {
                    query += " and (vetaccomodation.customerid = @customerid)";
                }
                else
                {
                    query += "  and (isnull(vetaccomodation.islogout, 0) = 0) ";
                }

                response.Data = _uow.Query<AccomodationListDto>(query , new { customerid = request.CustomerId});
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
    }
}
