using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Data
{
    public class Rank
    {
        public int Id { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public virtual ICollection<Player> Players { get; set; }

    }
}
