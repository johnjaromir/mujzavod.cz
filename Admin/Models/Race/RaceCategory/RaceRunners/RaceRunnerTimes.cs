using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnerTimes
    {
        public int RaceRunnerId { get; set; }
        public List<RaceRunnersTimeRound> RaceRunnersTimeRounds { get; set; }

        public RaceRunnerTimes()
        {

        }

        public RaceRunnerTimes(Data.Models.RaceCategoryUser raceCategoryUser)
        {
            if (raceCategoryUser != null)
            {
                RaceRunnerId = raceCategoryUser.Id;
                RaceRunnersTimeRounds = raceCategoryUser.RaceCategory.RaceRounds.Select(x => new RaceRunnersTimeRound()
                {
                    RoundId = x.Id,
                    Name = x.Name,
                    Time = raceCategoryUser.RaceRoundUsers.FirstOrDefault(y=>y.RaceRoundId == x.Id)?.Time
                }).ToList();
            }
        }
    }

    public class RaceRunnersTimeRound
    {
        public int RoundId { get; set; }
        public string Name { get; set; }
        public TimeSpan? Time { get; set; }
    }
}