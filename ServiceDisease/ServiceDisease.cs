using ModelsDisease;

using Microsoft.EntityFrameworkCore;
using Infrastruct;
using AbstractSeviceBase;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceDiseases
{
    public static class MyExtentionDisease
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            services.AddDbContext<AppDBModelDiseases>();
            services.AddTransient<IServiceModel<Disease>, ServiceDisease>();

            return services;
        }
    }



    public class ServiceDisease : AbstractBaseServise<Disease>
    {
        AppDBModel _appDB;
        public ServiceDisease(AppDBModelDiseases _appDB) : base(_appDB)
        {

        }

        public IEnumerable<Disease> getDisease()
        {
            return base.GetValues();
        }

        public Disease? UpdDisease(Disease disease)
        {
            return base.UpdValue(disease.Id, disease);
        }

        public Disease? AddDisease(Disease disease)
        {
            return base.setValue(disease);
        }

        public Disease getDisease(Guid Id)
        {
            return base.GetValue(Id);
        }

        
    }
}
