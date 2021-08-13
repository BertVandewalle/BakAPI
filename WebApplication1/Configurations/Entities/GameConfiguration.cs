using BakAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Configurations.Entities
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
           // builder.Property(p => p.GreScore).HasComputedColumnSql("[GreDefScore] + [GreOffScore]",stored:true);
           // builder.Property(p => p.RedScore).HasComputedColumnSql("GENERATED (Games.RedDefScore + Games.RedDefScore)", stored:true);
            builder.HasOne<Player>(g => g.RedDef).WithMany(p => p.GamesRedDef).HasForeignKey(g => g.RedDefId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Player>(g => g.RedOff).WithMany(p => p.GamesRedOff).HasForeignKey(g => g.RedOffId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Player>(g => g.GreDef).WithMany(p => p.GamesGreDef).HasForeignKey(g => g.GreDefId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Player>(g => g.GreOff).WithMany(p => p.GamesGreOff).HasForeignKey(g => g.GreOffId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}

