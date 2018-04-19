using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Runner
{
    public class RunnerRaceGridRow : Helpers.Grid.IGridRow
    {
        readonly MujZavod.Data.Models.RaceCategoryUser raceCategoryUser;

        public RunnerRaceGridRow(MujZavod.Data.Models.RaceCategoryUser raceCategoryUser)
        {
            this.raceCategoryUser = raceCategoryUser;
        }

        public string Id => raceCategoryUser.Id.ToString();

        [DisplayName("Název závodu")]
        public string Name => raceCategoryUser.RaceCategory.Race.Name;

        [DisplayName("Číslo závodníka")]
        public string RunnerNumber => raceCategoryUser.RunnerNumber.ToString();

        [DisplayName("Výsledný čas")]
        public string TotalTime => raceCategoryUser.RaceRoundUsers.Count() > 0 ? raceCategoryUser.RaceRoundUsers?.Max(x=>x.Time).ToString() : string.Empty;

        [DisplayName("Kategorie")]
        public string Category => raceCategoryUser.RaceCategory.Name;

        [DisplayName("Pořadí")]
        public string Order => raceCategoryUser.OrderInCategory?.ToString();

        [DisplayName("Podkategorie")]
        public string SubCategory => raceCategoryUser.RaceSubCategory.Name;

        [DisplayName("Pořadí v mé kategorii")]
        public string OrderInSubCategory => raceCategoryUser.OrderInSubCategory?.ToString();
        
        public string Actions
        {
            get
            {
                string ret = "";


                ret += new Helpers.MzButton()
                {
                    mzButtonType = Helpers.MzButton.MzButtonType.DETAIL,
                    cssClass = "pull-right",
                    href = "/RaceRegistration/Index/" + raceCategoryUser.RaceCategory.Race.RaceKey,
                    innerHtml = "Detail"
                };
                
                return ret;
            }
        }
    }
}