using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Extensions
{
    public static class RaceExtensions
    {
        public static bool CanPublish(this Data.Models.Race race, out List<string> err)
        {
            err = new List<string>();

            if (race.RaceCategories.Count == 0)
                err.Add("Závod musí obsahovat alepoň jendu kategorii");

            var categoriesWithoutSub = race.RaceCategories.Where(x => x.RaceSubCategories.Count == 0).Select(x => x.Name);
            if (categoriesWithoutSub.Count() > 0)
                err.AddRange(categoriesWithoutSub.Select(x => $"Kategorie {x} nemá žádnou podkategorii"));

            var raceCategoriesWithoutRound = race.RaceCategories.Where(x => x.RaceRounds.Count == 0).Select(x => x.Name);
            if (raceCategoriesWithoutRound.Count() > 0)
                err.AddRange(raceCategoriesWithoutRound.Select(x => $"Kategorie {x} nemá vyplněn žádný měřený úsek"));

            return err.Count == 0;
        }
    }
}
