using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Organizer
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {

        }
        public RegisterViewModel registerViewModel { get; set; }
        public OrganizerViewModel organizerViewModel { get; set; }
    }
}