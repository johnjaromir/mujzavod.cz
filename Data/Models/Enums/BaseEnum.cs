using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models.Enums
{
    public abstract class BaseEnum : BaseEntity
    {
        public string Name { get; set; }

        
    }
}
