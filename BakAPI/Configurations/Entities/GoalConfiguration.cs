using BakAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Configurations.Entities
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasOne<Player>(g => g.Player).WithMany(p => p.Goals).HasForeignKey(g => g.PlayerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Game>(g => g.Game).WithMany(g => g.Goals).HasForeignKey(g => g.GameId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

