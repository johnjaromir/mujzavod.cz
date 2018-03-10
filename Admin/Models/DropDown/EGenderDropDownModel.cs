using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Models.DropDown
{
    public class EGenderDropDownModel : IDropDownModel
    {
        public IList<SelectListItem> items => new Code.Repository.EGenderRepository().GetAll()
            .Select(x=> new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
    }
}