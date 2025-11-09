using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace dz2
{
    public class DIConatiner
    {
        public static ServiceProvider Init()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IBankFactory, BankFactory>();

            services.AddSingleton<IAccountStorage, AccountStorage>();
            services.AddSingleton<ICategoryStorage, CategoryStorage>();
            services.AddSingleton<IOperationStorage, OperationStorage>();

            services.AddSingleton<IAccountFacade, AccountFacade>();
            services.AddSingleton<ICategoryFacade, CategoryFacade>();
            services.AddSingleton<IOperationFacade, OperationFacade>();

            return services.BuildServiceProvider();
        }
    }
}
