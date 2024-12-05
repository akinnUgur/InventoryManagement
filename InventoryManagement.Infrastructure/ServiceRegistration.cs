using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Interfaces.Base;
using InventoryManagement.Core.Settings;
using InventoryManagement.Infrastructure.Contexts;
using InventoryManagement.Infrastructure.Repositories;
using InventoryManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ApplicationDb"));

            #region Repositories

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();


            #endregion



            services.Configure<MailSettings>(options =>
            {
                configuration.GetSection("MailSettings");
            });


            #region Services
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<Core.Interfaces.Base.IObserver<Order>, EmailObserver>();

            #endregion
        }
    }
}
