using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Helpers.Grid
{
    public interface IGridViewModel<T> where T : IGridRow
    {

        
        string Id { get; }
        string Name { get; }
        string Url { get; }

        // todo, radkovani etc?
    }
}