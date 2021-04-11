using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Model
{
    public class GarageDbContext : DbContext
    {
        public GarageDbContext(DbContextOptions<GarageDbContext>options): base(options)
        {

        }
        //public DbSet<Car_Info> Car_Info { get; set; }
        public DbSet<Garage> Garage { get; set; }
        //public DbSet<Service> Service  { get; set; }
        //public DbSet<Service_of_Garage> Service_Of_Garage { get; set; }
        //public  DbSet<Special_Service>  Special_Service { get; set; }
        //public DbSet<Special_Service_of_Garage> Special_Service_Of_Garages { get; set; }
        //public DbSet<Type_of_Car> Type_Of_Car { get; set; }
        //public DbSet<User> User  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Garage>().HasKey(k => k.G_Id);
        }
    }
}
