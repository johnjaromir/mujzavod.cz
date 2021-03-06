﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class RaceCategoryUser:BaseEntity
    {
        public RaceCategoryUser()
        {
            RaceRoundUsers = new HashSet<RaceRoundUser>();
        }

        public string ApplicationUserId { get; set; }
        public virtual Identity.ApplicationUser ApplicationUser { get; set; }

        public int RaceCategoryId { get; set; }
        public virtual RaceCategory RaceCategory { get; set; }

        public int? RaceSubCategoryId { get; set; }
        public virtual RaceSubCategory RaceSubCategory { get; set; }

        public int? RunnerNumber { get; set; }
        public bool IsPaid { get; set; }


        public int? OrderInCategory { get; set; }
        public int? OrderInSubCategory { get; set; }


        public virtual ICollection<Models.RaceRoundUser> RaceRoundUsers { get; set; }
    }
}
