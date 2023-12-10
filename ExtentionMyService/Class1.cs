using Microsoft.Extensions.DependencyInjection;
namespace ExtentionMyService
{
    public static class MyService
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            

            return services;
        }
    }
}
