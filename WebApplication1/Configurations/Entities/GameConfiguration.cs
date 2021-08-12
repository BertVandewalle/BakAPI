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
            builder.Property(p => p.GreScore).HasComputedColumnSql("[GreDefScore] + [GreOffScore]");
            builder.Property(p => p.RedScore).HasComputedColumnSql("[RedDefScore] + [RedOffScore]");
            builder.HasOne<Player>(g => g.RedDef).WithMany(p => p.GamesRedDef).HasForeignKey(g => g.RedDefId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Player>(g => g.RedOff).WithMany(p => p.GamesRedOff).HasForeignKey(g => g.RedOffId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}

