using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class FrmProdukter : MetroForm
    {
        public FrmProdukter()
        {
            InitializeComponent();
        }

        public class Row
        {
            public string Serienummer { get; set; }
            public string Modell { get; set; }
            public string Marke { get; set; }
            public string Owner { get; set; }
            public string Fortackning { get; set; }
        }

        private void Print(Row obj)
        {
            Console.WriteLine(obj.ToString());
        }

        private DataTable Loader()
        {
            using (FileStream fs = new FileStream(@"produkter.xml",
               FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                XDocument xDoc = XDocument.Load(fs);

                List<Row> items = (from r in xDoc.Elements("DocumentElement").Elements("Row")
                                   select new Row
                                   {
                                       Serienummer = (string)r.Element("Serienummer") + "",
                                       Modell = (string)r.Element("Modell") + "",
                                       Marke = (string)r.Element("Marke"),
                                       Owner = (string)r.Element("Owner"),
                                       Fortackning = (string)r.Element("Fortäckning")

                                   }).ToList();

                fs.SetLength(0);
                xDoc.Save(fs);
                items.ForEach(Print);
                var list = new BindingList<Row>(items);
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable dt = converter.ToDataTable(list);
                return dt;
                }
            }
        async void Activatee() {
            dataGridView1.DataSource = await Task.Run(() => Loader());
        }

        private void frmProdukter_Load(object sender, EventArgs e)
        {


                Activatee();
            /*    var xmlfile = @"‪produkter.xml";
                var doc = XDocument.Load(xmlfile);
                //var node = doc.Descendants().Where(n => n.Value == metroTextBox1.Text);
                //metroComboBox2.DataSource = node.ToList();
                var itemType = doc.Root.Elements("Row")
                       .Where(i => string.IsNullOrWhiteSpace((string)i.Element("Owner")))
                       ;
                int counter = 0;
                foreach (var ex in itemType) {
                    counter++;
                }
                txtLediaDatorer.Text = counter.ToString();

    */
            
        }


        private void Save_button_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()

        {
            const string path = @"produkter.xml";
            var ds = dataGridView1.DataSource as DataTable;
            ds?.WriteXml(path);
        }
        private DataTable WorksheetToDataTable(ExcelWorksheet ws, bool hasHeader = true)
        {
            DataTable dt = new DataTable(ws.Name);
            int totalCols = ws.Dimension.End.Column;
            int totalRows = ws.Dimension.End.Row;
            int startRow = hasHeader ? 2 : 1;
            DataRow dr;
            foreach (var firstRowCell in ws.Cells[1, 1, 1, totalCols]) {
                dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }

            for (int rowNum = startRow; rowNum <= totalRows; rowNum++) {
                var wsRow = ws.Cells[rowNum, 1, rowNum, totalCols];
                dr = dt.NewRow();
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
                Filter = Resources.DialogFileFormat,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    // Create an ExcelPackage from file
                    using (var pck = new ExcelPackage(new FileInfo(openFileDialog.FileName))) {
                        // Get the first worksheet
                        ExcelWorksheet ws = pck.Workbook.Worksheets.First();
                        // Convert the worksheet to a DataTable and set it as data source of a DataGridView
                        dataGridView1.DataSource = WorksheetToDataTable(ws, chkHasHeader.Checked);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(@"Importing data from Excel file failed. Exception: " + ex.Message, @"Error");
                }
            }
        }

        private void chkHasHeader_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool _buttonPressed;
        private void checker_Click(object sender, EventArgs e)
        {
            _buttonPressed = !_buttonPressed;
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter = _buttonPressed ? "Owner Is Null" : string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("pressed");
            var results = dataGridView1.SelectedRows
                           .Cast<DataGridViewRow>()
                           .Select(x => Convert.ToString(x.Cells[0].Value));
            var result = results.ToArray();
            foreach (var value in result) {
                Console.WriteLine(value);
            }
            var selectedRows = new List<string>();
            Console.WriteLine(selectedRows.Count);
            selectedRows.AddRange(from DataGridViewRow r in dataGridView1.SelectedRows select r.Cells[0].Value.ToString());
            foreach (var value in selectedRows) {
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
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter = $"Serienummer LIKE '%{textBox1.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter = $"Owner LIKE '%{textBox2.Text}%'";
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var headerText =
                dataGridView1.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (headerText.Equals("Owner"))
            {
            

            // Confirm that the cell is not empty.
            const string xmlfile3 = @"Elever.xml";
            var doc2 = XDocument.Load(xmlfile3);
                // ReSharper disable once RedundantJumpStatement
            if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString())) return;

                if (!string.IsNullOrEmpty(
                    doc2.Root?.Elements("Row")
                        .Where(i => (string) i.Element("Id") == e.FormattedValue.ToString())
                        .Select(i => (string) i.Element("Id"))
                        .FirstOrDefault())) return;
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    Resources
                        .FrmProdukter_dataGridView1_CellValidating_Stämmer_inte_överens_med_något_användar_ID__kolla_stavningen_eller_lägg_till_användare;
                MessageBox.Show(
                    Resources
                        .FrmProdukter_dataGridView1_CellValidating_Stämmer_inte_överens_med_något_användar_ID__kolla_stavningen_eller_lägg_till_användare,
                    @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else if (headerText.Equals("Serienummer"))
            {
                if (dataGridView1.Rows.Cast<DataGridViewRow>().Where(row => row.Index != e.RowIndex & !row.IsNewRow).Any(row => row.Cells[0].Value.ToString() == e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText =
                        "Duplicate value not allowed";
                    MessageBox.Show(
                    @"Serienummer finns redan",
                    @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    var dialogResult = MessageBox.Show(@"Vill du visa Serienummret nu?", @"Hjälp", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            var savedValue = e.FormattedValue.ToString();
                            
                            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $"Serienummer LIKE '%{savedValue}%'";

                            break;
                        case DialogResult.No:
                            //do something else
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                            break;
                        case DialogResult.Cancel:
                            break;
                        case DialogResult.Abort:
                            break;
                        case DialogResult.Retry:
                            break;
                        case DialogResult.Ignore:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    return;
                }
                dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
            
            // Confirm that the cell is not empty.
            const string xmlfile3 = @"Produkter.xml";
                var doc2 = XDocument.Load(xmlfile3);

                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString())) return;

                
//                if (!string.IsNullOrEmpty(
//                    doc2.Root?.Elements("Row")
//                        .Where(i => (string) i.Element("Serienummer") == e.FormattedValue.ToString())
//                        .Select(i => (string) i.Element("Serienummer"))
//                        .FirstOrDefault())) return;
//                dataGridView1.Rows[e.RowIndex].ErrorText = "Serienummer Error";
//                MessageBox.Show(
//                    @"Serienummer Error",
//                    @"Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                e.Cancel = true;
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
