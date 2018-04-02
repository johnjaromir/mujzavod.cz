using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Models.DropDown
{
    public class RaceSubCategoryDropDownModel : IDropDownModel
    {
        readonly int raceCategoryId;
        public RaceSubCategoryDropDownModel(int raceCategoryId)
        {
            this.raceCategoryId = raceCategoryId;
        }

        public IList<SelectListItem> items => new Code.Repository.RaceSubCategoryRepository().GetAll()
            .Where(x=>x.RaceCategoryId == raceCategoryId)
            .Select(x=> new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
    }
}