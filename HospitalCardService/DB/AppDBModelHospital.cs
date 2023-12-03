using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HospitalCard;
using DisiesHistory;
using AbstractSeviceBase;

namespace HospitalCardService
{



   
    public class AppDBModelHospital : AppDBModel
    {
        public DbSet<HistoryDisies>  HistoryDisies { get; set; }
        public DbSet<HospitalCard.HospitalCard>  HospitalCards { get; set; }
        public DbSet<DisiesItem> DisiesItems { get; set; }

        public AppDBModelHospital(DbContextOptions<AppDBModel> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }


    }
}
