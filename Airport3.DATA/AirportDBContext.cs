using Airport.DATA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DATA
{
    public class AirportDBContext : DbContext
    {
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }

        public AirportDBContext() : base("Data Source=DESKTOP-0HLV6ID\\MSSQLSERVER03;Initial Catalog=AirportsDB;Integrated Security=true")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>()
                .HasMany(x => x.Pilots)
                .WithMany(x => x.Flights);

            modelBuilder.Entity<Flight>() 
                .HasRequired(x => x.Plane)
                .WithMany(x => x.Flights)
                .HasForeignKey(x => x.PlaneId);
        }
    }
}
