using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakAPI.Configurations.Entities;

namespace BakAPI.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    { 
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Rank> Ranks { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new RankConfiguration());
            builder.ApplyConfiguration(new GoalConfiguration());

            builder.ApplyConfiguration(new RoleConfiguration());


        }
    }
}
