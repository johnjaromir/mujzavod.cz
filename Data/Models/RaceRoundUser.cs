using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class RaceRoundUser:BaseEntity
    {
        public string UserId { get; set; }
        public Identity.ApplicationUser User { get; set; }
        public int RaceRoundId { get; set; }
        public RaceRound RaceRound { get; set; }

        public TimeSpan Time { get; set; }
    }
}
