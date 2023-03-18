﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VetSystems.IdentityServer.Infrastructure.Persistence;
using VetSystems.IdentityServer.Infrastructure.Services.Interface;
using VetSystems.Shared.Accounts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VetSystems.IdentityServer.Infrastructure.Services
{
    internal class AccountService : IAccountService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AccountService(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _configuration = configuration;
        }


        public async Task<SignupDto> GetAccountByIdForClaims(string id)
        {
            var result = await (from ac in _dbContext.Accounts
                                where ac.UserId == id
                                select new SignupDto
                                {
                                    Email = ac.User.Email,
                                    FirstName = ac.FirstName,
                                    LastName = ac.LastName,
                                    Id = ac.UserId,
                                    IsLicenceAccount = ac.IsLicenceAccount,
                                    CompanyId = ac.CompanyId,
                                    RoleId = ac.RoleId,
                                    //TenantId = ac.TenantId,
                                    //AccountType = ac.AccountType,
                                    //AuthorizeEnterprise = ac.AuthorizeEnterprise,
                                    //ConnectionDb = sb.ConnectionString,
                                    //Host = sb.Host ?? "",
                                    //UseSafeListControl = sb.UseSafeListControl,
                                    //SubscriptionType = sb.SubscriptionType
                                }).FirstOrDefaultAsync();

            //var result = await _dbContext.Accounts.FirstOrDefaultAsync(r => r.UserId == id);
            if (result != null)
            {
            }

            return result;
        }
    }
}