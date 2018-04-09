using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridRow : Helpers.Grid.IGridRow
    {
        readonly MujZavod.Data.Models.RaceCategoryUser raceCategoryUser;

        public RaceRunnersGridRow(MujZavod.Data.Models.RaceCategoryUser raceCategoryUser)
        {
            this.raceCategoryUser = raceCategoryUser;
        }

        public string Id => raceCategoryUser.Id.ToString();

        [DisplayName("Číslo běžce")]
        public string RunnerNumber => raceCategoryUser.RunnerNumber.ToString();
        [DisplayName("Podkategorie")]
        public string SubCategory => raceCategoryUser.RaceSubCategory?.Name;
        [DisplayName("Jméno")]
        public string FirstName => raceCategoryUser.ApplicationUser.FirstName;
        [DisplayName("Příjmení")]
        public string LastName => raceCategoryUser.ApplicationUser.LastName;
        [DisplayName("Pohlaví")]
        public string Gender => raceCategoryUser.ApplicationUser.EGender.Name;
        [DisplayName("Datum narození")]
        public string BirthDate => raceCategoryUser.ApplicationUser.BirthDate.ToShortDateString();
        [DisplayName("Zaplaceno")]
        public bool IsPaid => raceCategoryUser.IsPaid;
        [DisplayName("Celkový čas")]
        public string TotalTime => raceCategoryUser.RaceRoundUsers.Count > 0 ? raceCategoryUser.RaceRoundUsers?.Max(x => x.Time).ToString() : string.Empty;

        public string Actions
        {
            get
            {
                string ret = "";

                

                ret += new Helpers.MzButton()
                {
                    innerHtml = "Smazat",
                    cssClass = "pull-right btn-sm m-l-1",
                    mzButtonType = Helpers.MzButton.MzButtonType.DELETE,
                    js = "MujZavod.Confirm('Opravdu si přejete smazat zvodníka?', function() { MujZavod.DoAction('/Race/RemoveRaceCategoryUser?id=" + Id + "', function () { MujZavod.Grids['RaceRunnersGrid_" + raceCategoryUser.RaceCategoryId + "'].refresh(); }); } );"
                };


                

                if (raceCategoryUser.RaceCategory.Race.Date < DateTime.Now)
                {
                    ret += new Helpers.MzButton()
                    {
                        innerHtml = "Upravit časy",
                        cssClass = "pull-right btn-sm m-l-1",
                        mzButtonType = Helpers.MzButton.MzButtonType.EDIT,
                        js = "new MujZavod.Modal().loadFromUrl('/Race/EditUserTimes?runnerId=" + Id + "', function (modal) { MujZavod.Grids['RaceRunnersGrid_" + raceCategoryUser.RaceCategoryId + "'].refresh(); modal.close(); });"


                    };
                }


                // editujeme jen neregistrovany
                if (raceCategoryUser.ApplicationUser.Roles?.Count() == 0)
                {
                    ret += new Helpers.MzButton()
                    {
                        innerHtml = "Upravit",
                        cssClass = "pull-right btn-sm m-l-1",
                        mzButtonType = Helpers.MzButton.MzButtonType.EDIT,
                        js = "new MujZavod.Modal().loadFromUrl('/Race/SubCategoryUserEdit?id=" + Id + "', function (modal) { MujZavod.Grids['RaceRunnersGrid_" + raceCategoryUser.RaceCategoryId + "'].refresh(); modal.close(); });"
                    };
                }

                
                return ret;
            }
        }
    }
}