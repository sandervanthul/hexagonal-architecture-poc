using CompositionRoot;

namespace QuotesReader.Infrastructure.Web.Extensions;

public static class RegisterExtensions
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        MainComponent.SetupDependencyInjection<WebAdapter>(services);
    }
}