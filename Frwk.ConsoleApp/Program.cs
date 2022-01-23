using Frwk.AppService;
using Fwrk.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var _calculadora = serviceProvider.GetService<ICalculadora>();
        await _calculadora.Inicializar();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICalculadoraAppService, CalculadoraAppService>();
        services.AddScoped<ICalculadora, Calculadora>();
    }
}