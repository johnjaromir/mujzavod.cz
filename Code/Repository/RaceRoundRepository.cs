using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceRoundRepository : BaseRepository<RaceRound>
    {
        protected override string dbSetContextName => "RaceRounds";


    }
}
