using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceRoundUsersRepository : BaseRepository<RaceRoundUser>
    {
        protected override string dbSetContextName => "RaceRoundUsers";
    }
}
