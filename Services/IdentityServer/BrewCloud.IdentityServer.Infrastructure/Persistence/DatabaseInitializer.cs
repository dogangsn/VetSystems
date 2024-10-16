﻿using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewCloud.IdentityServer.Infrastructure.Persistence
{
    public class DatabaseInitializer
    {
        public static void Initialize(IApplicationBuilder app, ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            InitializeTokenServerConfigurationDatabase(app);

            context.SaveChanges();
        }
 
        private static void InitializeTokenServerConfigurationDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
               scope.ServiceProvider.GetRequiredService<PersistedGrantDataContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDataContext>();
                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    var clients = context.Clients.ToList();
                    var newClients = Config.Clients.Where(r => !clients.Any(x => x.ClientId == r.ClientId)).ToList();
                    if (newClients.Any())
                    {
                        foreach (var client in newClients)
                        {
                            context.Clients.Add(client.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    var identityResource = context.IdentityResources.ToList();
                    var newResource = Config.IdentityResources.Where(r => !identityResource.Any(x => x.Name == r.Name)).ToList();
                    if (newResource.Any())
                    {
                        foreach (var resource in newResource)
                        {
                            context.IdentityResources.Add(resource.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.ApiResources)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                else
                {
                    var apiResources = context.ApiResources.ToList();
                    var newApiResources = Config.ApiResources.Where(r => !apiResources.Any(x => x.Name == r.Name)).ToList();
                    if (newApiResources.Any())
                    {
                        foreach (var resource in newApiResources)
                        {
                            context.ApiResources.Add(resource.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
