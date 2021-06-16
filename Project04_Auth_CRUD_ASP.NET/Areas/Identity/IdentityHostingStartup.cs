using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project04_Auth_CRUD_ASP.NET.Data;

[assembly: HostingStartup(typeof(Project04_Auth_CRUD_ASP.NET.Areas.Identity.IdentityHostingStartup))]
namespace Project04_Auth_CRUD_ASP.NET.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}