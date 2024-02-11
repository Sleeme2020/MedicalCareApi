using Microsoft.Extensions.DependencyInjection;
using AbstractSeviceBase;
using System.Reflection;
namespace ExtentionMyService
{
    public static class MyService
    {
        public static IServiceCollection AddMyService(this IServiceCollection services,Assembly assem)
        {
            
            foreach (var service in GetService(assem)) 
            {
                services.AddScoped(service);            
            }

            return services;
        }

        public static Type[] GetService(Assembly assem)
        {
            Type baseType = typeof(AbstractBaseServise<>);
            var asem= assem;
            var derivedTypes = baseType.Assembly.ExportedTypes.Where(t => t.BaseType == baseType).ToArray();
            return derivedTypes;
        }

    }
}
