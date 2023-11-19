using MedicalCareApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedicalCareApi.DB
{
    public class AppDBModel:DbContext
    {
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseType> DiseaseTypes { get; set; }


        public AppDBModel(DbContextOptions<AppDBModel> options):base(options) 
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
