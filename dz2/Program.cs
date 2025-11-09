using dz2;
using Microsoft.Extensions.DependencyInjection;

public static class Program
{
    public static void Main()
    {
        var services = DIConatiner.Init();

        var menu = new Menu(services.GetRequiredService<IAccountFacade>(),
            services.GetRequiredService<ICategoryFacade>(),
            services.GetRequiredService<IOperationFacade>());
        
        menu.Launch();
    }

}