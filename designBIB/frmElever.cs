using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using designBIB.Properties;
using MetroFramework.Forms;
using OfficeOpenXml;

namespace designBIB
{
    public partial class FrmElever : MetroForm
    {
        private readonly Logs _log = new Logs();
        private string _oldValue;
        private string _newValue;

        public FrmElever()
        {
            InitializeComponent();
        }

        private class Row
        {
            public string Fornamn { get; set; }
            public string Efternamn { get; set; }
            public string Klass { get; set; }
            public string Id { get; set; }
        }

        private static void Print(Row obj)
        {
            Console.WriteLine(obj.ToString());
        }


        private async void Activatee()
        {
            metroProgressBar1.Value = 20;
            dataGridView1.DataSource = await Task.Run(() => Loader());
            metroProgressBar1.Value = 100;
        }
        private DataTable Loader() {
            using (var fs = new FileStream(@"elever.xml",
               FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                var xDoc = XDocument.Load(fs);

                var items = (from r in xDoc.Elements("DocumentElement").Elements("Row")
                                   select new Row
                                   {
                                       Fornamn = (string)r.Element("Fornamn") + "",
                                       Efternamn = (string)r.Element("Efternamn") + "",
                                       Klass = (string)r.Element("Klass"),
                                       Id = (string)r.Element("Id")

                                   }).ToList();

                fs.SetLength(0);
                xDoc.Save(fs);
                items.ForEach(Print);
                var list = new BindingList<Row>(items);
                var converter = new ListtoDataTableConverter();
                var dt = converter.ToDataTable(list);
                return dt;
            }
        }

        private void frmElever_Load(object sender, EventArgs e)
        {
            //await. Loader();
            Activatee();
        }


        private void Save_button_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()

        {
            var path = @"elever.xml";
            var ds = dataGridView1.DataSource as DataTable;
            ds?.WriteXml(path);
        }
        private DataTable WorksheetToDataTable(ExcelWorksheet ws, bool hasHeader = true)
        {
            var dt = new DataTable(ws.Name);
            var totalCols = ws.Dimension.End.Column;
            var totalRows = ws.Dimension.End.Row;
            var startRow = hasHeader ? 2 : 1;
            foreach (var firstRowCell in ws.Cells[1, 1, 1, totalCols]) {
                dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }

            for (var rowNum = startRow; rowNum <= totalRows; rowNum++) {
                var wsRow = ws.Cells[rowNum, 1, rowNum, totalCols];
                var dr = dt.NewRow();
                foreach (var cell in wsRow) {
                    dr[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        private void btnCheckKlasser_Click(object sender, EventArgs e)
        {

            var openFileDialog = new OpenFileDialog
            {
                Filter = Resources.FrmElever_btnCheckKlasser_Click_Excel_File____xlsx____xlsx,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            try {
                // Create an ExcelPackage from file
                using (var pck = new ExcelPackage(new FileInfo(openFileDialog.FileName))) {
                    // Get the first worksheet
                    var ws = pck.Workbook.Worksheets.First();
                    // Convert the worksheet to a DataTable and set it as data source of a DataGridView
                    ((DataTable)dataGridView1.DataSource).Merge(WorksheetToDataTable(ws, chkHasHeader.Checked));
                    //dataGridView1.DataSource = WorksheetToDataTable(ws, chkHasHeader.Checked);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(@"Importing data from Excel file failed. Exception: " + ex.Message, @"Error");
            }
        }

        private void chkHasHeader_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checker_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // Console.WriteLine("pressed");
            var results = dataGridView1.SelectedRows
                           .Cast<DataGridViewRow>()
                           .Select(x => Convert.ToString(x.Cells[0].Value));
            var result = results.ToArray();
            foreach (string value in result) {
                Console.WriteLine(value);
            }
            List<string> selectedRows = new List<string>();
            Console.WriteLine(selectedRows.Count);
            foreach (DataGridViewRow r in dataGridView1.SelectedRows) {
                selectedRows.Add(r.Cells[0].Value.ToString());
            }
            foreach (string value in selectedRows) {
                Console.WriteLine(value);
            }
        }

        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Id LIKE '%{0}%'", textBox1.Text);
        }
        public static bool CheckUserinAd(string domain, string username)
        {
            using (var domainContext = new PrincipalContext(ContextType.Domain, domain)) {
                using (var user = new UserPrincipal(domainContext)) {
                    user.SamAccountName = username;

                    using (var pS = new PrincipalSearcher()) {
                        pS.QueryFilter = user;

                        using (var results = pS.FindAll()) {
                            if (results.Any()) {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            _log.Logger(e.FormattedValue.ToString());
            string headerText =
    dataGridView1.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Id")) return;

            //CheckUserinAD("learnet.se",e.FormattedValue.ToString());
            // Confirm that the cell is not empty.
            if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString())) {
            }
            else if (string.IsNullOrEmpty(e.FormattedValue.ToString())) {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Company Name must not be empty";
                MessageBox.Show(@"Det går inte att lägga till en användare ut en unik identifierare (Schoolsoft användarnamn)", @"Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _oldValue = (string) dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _newValue = (string) dataGridView1[e.ColumnIndex, e.RowIndex].Value;

            if (_newValue != _oldValue)
            {
                _log.Logger("changed value: " + _oldValue + " To: "+ _newValue);
            }
        }
    }
}
