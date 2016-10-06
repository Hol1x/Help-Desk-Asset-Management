using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace designBIB
{
    internal class ListtoDataTableConverter
    {
        public DataTable ToDataTable<T>(BindingList<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props) dataTable.Columns.Add(prop.Name);
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++) values[i] = props[i].GetValue(item, null);
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}