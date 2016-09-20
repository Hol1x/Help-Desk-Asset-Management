using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace designBIB
{
    internal class ListtoDataTableConverter
    {
        public DataTable ToDataTable<T>(BindingList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props) {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items) {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++) {
                    //inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}