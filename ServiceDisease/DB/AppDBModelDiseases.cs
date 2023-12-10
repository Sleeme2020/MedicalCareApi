using ModelsDisease;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AbstractSeviceBase;

namespace ServiceDiseases
{
    public class AppDBModelDiseases : AppDBModel
    {
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseType> DiseaseTypes { get; set; }


        public AppDBModelDiseases(DbContextOptions<AppDBModel> options):base(options) 
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
