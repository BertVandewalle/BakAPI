using BakAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Configurations.Entities
{
    public class RankConfiguration : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            int step = 175;
            string[] divisions = { "Bronze", "Silver", "Gold", "Platinum", "Diamond", "Master", "GrandMaster" };
            string[] subDivisions = { "V", "IV", "III", "II", "I" };
            int numberOfRanks = divisions.Length * subDivisions.Length;
            for (int i = 0; i < numberOfRanks; i++)
            {
                if (i == numberOfRanks - 1)
                {
                    builder.HasData(new Rank
                    {
                        Id = i + 1,
                        Division = divisions[i / subDivisions.Length],
                        SubDivision = subDivisions[i % subDivisions.Length],
                        LowerBound = i * step,
                        UpperBound = int.MaxValue
                    });
                }
                else
                {

                    builder.HasData(new Rank
                    {
                        Id = i + 1,
                        Division = divisions[i / subDivisions.Length],
                        SubDivision = subDivisions[i % subDivisions.Length],
                        LowerBound = i * step,
                        UpperBound = (i + 1) * step
                    });
                }
            }
        }
    }
}

