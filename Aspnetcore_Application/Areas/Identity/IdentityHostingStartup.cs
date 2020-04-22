﻿using System;
using Aspnetcore_Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Aspnetcore_Application.Areas.Identity.IdentityHostingStartup))]
namespace Aspnetcore_Application.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Aspnetcore_ApplicationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Aspnetcore_ApplicationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<Aspnetcore_ApplicationContext>();
            });
        }
    }
}