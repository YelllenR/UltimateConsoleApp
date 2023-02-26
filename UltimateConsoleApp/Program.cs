//Setting up configuration of dependancy injection for building application
using HelloWorldHelper.BussinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimateConsoleApp;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;


try
{
    services.GetRequiredService<App>().Run(args); 
}
catch(Exception exception)
{
    Console.WriteLine(exception.Message);
}
//In order to create a new hostBuilder, it is needed to invoke the IhostBuilder and configure it. 
static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IMessages, Messages>();
            services.AddSingleton<App>();
        });
}