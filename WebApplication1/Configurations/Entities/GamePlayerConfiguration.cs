using BakAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Configurations.Entities
{
    public class GamePlayerConfiguration : IEntityTypeConfiguration<GamePlayer>
    {
        public void Configure(EntityTypeBuilder<GamePlayer> builder)
        {
            builder.HasKey(gp => new { gp.GameId, gp.PlayerId });
            builder.HasOne(gp => gp.Game).WithMany(g => g.GamePlayers).HasForeignKey(gp => gp.GameId);
            builder.HasOne(gp => gp.Player).WithMany(g => g.GamePlayers).HasForeignKey(gp => gp.PlayerId);
        }

    }
}
