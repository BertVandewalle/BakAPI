using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public class RankDTO
    {
        public int Id { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public ICollection<PlayerDTO> Players { get; set; }

    }
}
