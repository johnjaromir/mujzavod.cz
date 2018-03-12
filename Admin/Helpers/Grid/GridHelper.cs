using MujZavod.Admin.Helpers.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Helpers
{
    public static class GridHelper
    {

        public static MvcHtmlString MzGrid<T>(this HtmlHelper helper, IGridViewModel<T> gridViewModel) where T:IGridRow
        {
            
            string head = "<thead><tr>" + string.Join("\n", getColumnNames(typeof(T)).Select(x => "<th>" + x + "</th>")) + "</tr></thead>";
            string table = $"<table class='table-primary table stripped' id='{gridViewModel.Id}' width='100%'>{head}</table>";

            string columns = Newtonsoft.Json.JsonConvert.SerializeObject(getColumns(typeof(T))); 
            string script = $"<script>new MujZavod.Grid({{Id: '{gridViewModel.Id}', ajax: '{gridViewModel.Url}', columns: {columns}, name: '{gridViewModel.Name}'}});</script>";
            return new MvcHtmlString($"{table} {script}");
        }


        private static IList<string> getColumnNames(Type t)
        {
            List<string> ret = new List<string>();

            foreach (var prop in t.GetProperties())
            {
                try
                {
                    ret.Add(prop.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single().DisplayName);
                }
                catch
                {
                    ret.Add(prop.Name);
                }
            }
            return ret;
        }

        private static IList<GridData> getColumns(Type t)
        {
            return t.GetProperties().Select(x => new GridData() { data = x.Name }).ToList();
            
        }


        public class GridData
        {
            public object data;
        }



        public static GridData ToGridData<T>(this IEnumerable<T> enumerable, Func<T, object> getRowFunc)
        {
            return new GridData() { data = enumerable.Select(x => getRowFunc(x)) };
        }

        public static GridData ToGridData<T>(this IQueryable<T> querayble, Func<T, object> getRowFunc)
        {
            return querayble.AsEnumerable().ToGridData(getRowFunc);
        }

    }
}