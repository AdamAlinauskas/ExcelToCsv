using System;
using System.Data;
using System.Linq;

namespace Utility
{
    public static class DataTableExtentionMethods
    {
        public static string ToCsv(this DataTable table)
        {
            var format = string.Join(",", Enumerable.Range(0, table.Columns.Count).Select(i => string.Format("{{{0}}}", i)));
            return string.Join(Environment.NewLine, table.Rows.OfType<DataRow>().Select(i => string.Format(format, i.ItemArray)));
        }
    }
}
