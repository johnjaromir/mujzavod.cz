using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceRoundRepository : BaseRepository<RaceRound>
    {
        protected override string dbSetContextName => "RaceRounds";

        public override IQueryable<RaceRound> GetAll()
        {
            return base.GetAll().Include(x => x.RaceCategory.Race);
        }
    }
}
