using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core
{
    public static class ServiceExtentions
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR( cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));   
        }
    }
}
