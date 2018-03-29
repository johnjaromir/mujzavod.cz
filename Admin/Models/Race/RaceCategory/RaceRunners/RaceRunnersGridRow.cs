﻿using System;
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

        public string Id => raceCategoryUser.ApplicationUser.Id;

        [DisplayName("Číslo běžce")]
        public string RunnerNumber => raceCategoryUser.RunnerNumber.ToString();
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

        public string Actions
        {
            get
            {
                string ret = "";


                // editujeme jen neregistrovany
                if (raceCategoryUser.ApplicationUser.Roles?.Count() == 0)
                {
                    ret += new Helpers.MzButton()
                    {
                        innerHtml = "Upravit",
                        cssClass = "pull-right",
                        mzButtonType = Helpers.MzButton.MzButtonType.EDIT,
                        js = "new MujZavod.Modal().loadFromUrl('/Race/SubCategoryUserEdit?id=" + Id + "', function (modal) { MujZavod.Grids['RaceRunnersGrid_" + raceCategoryUser.RaceCategoryId + "_" + raceCategoryUser.RaceSubCategoryId + "'].refresh(); modal.close(); });"
                    };
                }
                return ret;
            }
        }
    }
}