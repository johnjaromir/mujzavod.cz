﻿using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceRepository : BaseRepository<Race>
    {
        protected override string dbSetContextName => "Races";

        
        public override IQueryable<Race> GetAll()
        {
            var query = base.GetAll();

            var actUser = new ApplicationUserRepository().GetActAu();
            query = query.Where(x => x.OrganizerId == actUser.OrganizerId);

            return query;
        }
        
    }
}
