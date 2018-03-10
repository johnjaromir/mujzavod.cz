using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class OrganizerRepository : BaseRepository<Organizer>
    {
        protected override string dbSetContextName => "Organizers";

        
    }
}
