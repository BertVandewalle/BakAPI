using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakAPI.Data;

namespace BakAPI.Configurations.Entities
{
    public class DuoConfiguration : IEntityTypeConfiguration<Duo>
    {
        public void Configure(EntityTypeBuilder<Duo> builder)
        {
            builder.HasOne<Player>(g => g.DefPlayer).WithMany(p => p.DefDuos).HasForeignKey(g => g.DefPlayerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Player>(g => g.OffPlayer).WithMany(p => p.OffDuos).HasForeignKey(g => g.OffPlayerId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
