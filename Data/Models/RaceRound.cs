﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class RaceRound:BaseEntity
    {
        public RaceRound()
        {
            RaceRoundUsers = new HashSet<RaceRoundUser>();
        }
        public string Name { get; set; }
        public double Distance { get; set; }
        public int RaceCategoryId { get; set; }
        public RaceCategory RaceCategory { get; set; }


        public ICollection<RaceRoundUser> RaceRoundUsers { get; set; }
    }
}
