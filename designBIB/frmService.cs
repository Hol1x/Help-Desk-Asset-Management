using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using designBIB.Properties;
using MetroFramework.Forms;
using OfficeOpenXml;
using static System.Console;

namespace designBIB
{
    public partial class FrmService : MetroForm
    {
        public FrmService()
        {
            InitializeComponent();
        }

        private class Row
        {
            public string Servicenummer { get; set; }
            public string Servicestalle { get; set; }
            public string Kontaktinformation { get; set; }
            public string Serienummer { get; set; }
            public string Anmalningsdatum { get; set; }
            public string Leveransdatum { get; set; }
            public string User { get; set; }
            public string Felbestrivning { get; set; }
            public string Atgard { get; set; }
            public string Extra { get; set; }
            public string Skickad { get; set; }
            public string Fardig { get; set; }
        }

        private static void Print(Row obj)
        {
            WriteLine(obj.ToString());
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            
           
            using (var fs = new FileStream(Settings.Default.FileNameService,
               FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
                var xDoc = XDocument.Load(fs);

                var items = (from r in xDoc.Elements("DocumentElement").Elements("Row")
                                   select new Row
                                   {
                                       Servicenummer = (string)r.Element("Servicenummer") + "",
                                       Servicestalle = (string)r.Element("Servicestalle") + "",
                                       Kontaktinformation = (string)r.Element("Kontaktinformation"),
                                       Serienummer = (string)r.Element("Serienummer"),
                                       Anmalningsdatum = (string)r.Element("Anmalningsdatum"),
                                       Leveransdatum = (string)r.Element("Leveransdatum"),
                                       User = (string)r.Element("User"),
                                       Felbestrivning = (string)r.Element("Felbeskrivning"),
                                       Atgard = (string)r.Element("Atgard"),
                                       Extra = (string)r.Element("Extra"),
                                       Skickad = (string)r.Element("Skickad"),
                                       Fardig = (string)r.Element("Fardig")

                                   }).ToList();

                fs.SetLength(0);
                xDoc.Save(fs);
                items.ForEach(Print);
                var list = new BindingList<Row>(items);
                var converter = new ListtoDataTableConverter();
                var dt = converter.ToDataTable(list);
                dataGridView1.DataSource = dt;
                var dataTable = (DataTable) dataGridView1.DataSource;
                if (dataTable == null) return;
                dataTable.DefaultView.RowFilter = "Fardig LIKE \'%Unchecked%\'";
            }
        }


        private void Save_button_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()

        {
            const string path = @"service.xml";
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
                dt.Columns.Add(hasHeader ? firstRowCell.Text : $"Column {firstRowCell.Start.Column}");
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
                Filter = Resources.DialogFileFormat,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            try {
                // Create an ExcelPackage from file
                using (var pck = new ExcelPackage(new FileInfo(openFileDialog.FileName))) {
                    // Get the first worksheet
                    var ws = pck.Workbook.Worksheets.First();
                    // Convert the worksheet to a DataTable and set it as data source of a DataGridView
                    dataGridView1.DataSource = WorksheetToDataTable(ws, chkHasHeader.Checked);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(@"Importing data from Excel file failed. Exception: " + ex.Message, @"Error");
            }
        }

        private void chkHasHeader_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("pressed");
            var results = dataGridView1.SelectedRows
                           .Cast<DataGridViewRow>()
                           .Select(x => Convert.ToString(x.Cells[0].Value));
            var result = results.ToArray();
            foreach (var value in result) {
                WriteLine(value);
            }
            var selectedRows = new List<string>();
            WriteLine(selectedRows.Count);
            selectedRows.AddRange(from DataGridViewRow r in dataGridView1.SelectedRows select r.Cells[0].Value.ToString());
            foreach (var value in selectedRows) {
                WriteLine(value);
            }
        }

        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter =
                $"Fardig LIKE '%{(metroToggle1.Checked ? "Unchecked" : "Checked")}%'";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter = $"Serienummer LIKE '%{textBox1.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter = $"User LIKE '%{textBox2.Text}%'";
        }
    }
}
