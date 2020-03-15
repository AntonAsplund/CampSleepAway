using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund.Database
{
    public class CampSleepAwayContext : DbContext
    {
        public CampSleepAwayContext()
        {
            this.Database.Connection.ConnectionString = "Data Source=DESKTOP-6MGRJ4I\\SQLEXPRESS02; Initial Catalog = CampSleepAway_AntonAsplund; Integrated Security = True";
        }

        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<CamperHistory> CamperHistories { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<CounselorHistory> CounselorHistories { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<NextOfKinHistory> NextOfKinHistories { get; set; }

        public DbSet<NextOfKinCheckInCheckOut> NextOfKinCheckInCheckOuts { get; set; }
        public DbSet<CabinsCounselor> CabinsCounselors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Camper>()
                .Property(Ca => Ca.CabinID)
                .IsOptional();

            modelBuilder.Entity<NextOfKin>()
                .Property(N => N.CamperID)
                .IsRequired();
            modelBuilder.Entity<CabinsCounselor>()
                .Property(CC => CC.CabinID)
                .IsRequired();
            modelBuilder.Entity<CabinsCounselor>()
                .Property(CC => CC.CounselorID)
                .IsRequired();
        }



    }
}
