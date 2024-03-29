﻿using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VetSystems.IdentityServer.Infrastructure.Entities;
using VetSystems.IdentityServer.Infrastructure.Services.Interface;
using VetSystems.Shared.Dtos;

namespace VetSystems.IdentityServer.Infrastructure.Services
{
    public class ProfileService : IdentityServer4.Services.IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IAccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _claimsFactory = claimsFactory;
            _accountService = accountService;
            _userManager = userManager;
        }

        public Task<Response<string>> CheckUserAccount(ApplicationUser user, string address, string clientId)
        {
            throw new NotImplementedException();
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var service = GetService();
            await service.GetProfileDataAsync(context);
        }

        public VetSystems.IdentityServer.Infrastructure.Services.Interface.IProfileService GetService()
        {
            VetSystems.IdentityServer.Infrastructure.Services.Interface.IProfileService service;
            service = new AdminProfileService(_claimsFactory, _accountService, _userManager);
            return service;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
